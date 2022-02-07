using System.Linq;
using System.Web.Mvc;
using JobSeeker.Models;
using Microsoft.AspNet.Identity;
using System;

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
    }
}