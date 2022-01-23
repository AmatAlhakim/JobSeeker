using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Threading;
using System.Globalization;

namespace JobSeeker
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void ApplicationAquirRequestState(object sender, EventArgs e)
        {
           /* string culture = "ar";*/
            HttpCookie culture = HttpContext.Current.Request.Cookies["Language"];
            if (culture != null && culture.Value != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(culture.Value);
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture.Value);
            }
            
        }
    }
}
