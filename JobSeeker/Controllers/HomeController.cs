using JobSeeker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
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
    }
}