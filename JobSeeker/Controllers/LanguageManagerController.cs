using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Threading;

namespace JobSeeker.Controllers
{
    public class LanguageManagerController : Controller
    {
        // GET: LanguageManager
        public ActionResult Index()
        {
            return View();
        }

        
        // Add a method
        [HttpPost]
        public ActionResult Change(string lang)
        {
            if (lang != null)
            {

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            }
            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = lang;
            Response.Cookies.Add(cookie);

            return View("Index");
        }
    }
}                                                                                       