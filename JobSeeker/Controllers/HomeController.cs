using System.Linq;
using System.Web.Mvc;
using JobSeeker.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Net;
using System.Data.Entity;


namespace JobSeeker.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(context.Categories.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application Description page.";

            return View();
        }

        public ActionResult Details(int id)
        {
            Session["id"] = id;
            var job = context.Jobs.Find(id);
            if (job == null)
                return HttpNotFound();
            return View(job);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult Apply()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Apply(string Message)
        {
            if (Message != null)
            {
                var userId = User.Identity.GetUserId();
                var jobId = (int)Session["id"];

                //check if the job id is for a valid job
                var result = context.JobApplications.Where(p => p.Id == jobId && p.UserId == userId).ToList();

                if (result.Count == 0)
                {
                    var application = new JobApplication();
                    application.JobId = jobId;
                    application.UserId = userId;
                    application.Message = Message;
                    application.ApplicationDate = DateTime.Now;

                    context.JobApplications.Add(application);
                    context.SaveChanges();
                    ViewBag.Result = "Application Was Sent Successfully";
                    return View();
                }
                else
                {
                    ViewBag.Result = "Application Was Sent Already";
                    return View();
                }
            }
            else
            {
                ViewBag.Result = "You Can Not Send An Empty Application Message";
                return View();
            }

        }

        [Authorize]
        public ActionResult GetJobsByUserId()
        {
            var userId = User.Identity.GetUserId();
            var jobs = context.JobApplications.Where(p => p.UserId == userId);
            return View(jobs.ToList());
        }

        [Authorize]
        public ActionResult ApplicationDetails(int id)
        {
            var job = context.JobApplications.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        [Authorize]
        public ActionResult EditApplication(int id)
        {
            var job = context.JobApplications.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditApplication(JobApplication job)
        {
            if (ModelState.IsValid)
            {
                job.ApplicationDate=DateTime.Now;
                context.Entry(job).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("GetJobsByUserId");
            }
            return View(job);
        }

        public ActionResult CancelApplication(int id)
        {
            var job = context.JobApplications.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("CancelApplication")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteApplication(int id)
        {
            var job = context.JobApplications.Find(id);
            context.JobApplications.Remove(job);
            context.SaveChanges();
            return RedirectToAction("GetJobsByUserId");
        }

        [Authorize]
        public ActionResult GetJobsByPublisher()
        {
            var UserID = User.Identity.GetUserId();
            var jobs = from app in context.JobApplications
                       join job in context.Jobs
                       on app.JobId equals job.Id
                       where job.UserID == UserID
                       select app;
            var grouped = from j in jobs
                          group j by j.job.JobTitle
                          into gr
                          select new JobsViewModel
                          {
                              JobTitle = gr.Key,
                              Items = gr
                          };
            
            if (jobs == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return View(grouped.ToList());
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string searchName)
        {
            if (searchName == null || searchName == "")
                return HttpNotFound();
            var result = context.Jobs.Where(p => p.JobTitle.Contains(searchName)
            || p.JobDescription.Contains(searchName)
            || p.Category.CategoryName.Contains(searchName)
            || p.Category.Description.Contains(searchName));
            return View(result.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}