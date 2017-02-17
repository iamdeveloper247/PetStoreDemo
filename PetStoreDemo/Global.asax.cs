using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PetStoreDemo
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        //protected void Application_BeginRequest(Object sender, EventArgs e)
        //{
        //    if (!Request.Url.AbsolutePath.ToLower().Contains("login") && Request.HttpMethod != "POST")
        //    {
        //        try
        //        {
        //            var user = HttpContext.Current.Session["user"];
        //        }
        //        catch (System.NullReferenceException ex)
        //        {
        //            Response.RedirectToRoute("Default", new { controller = "Login", action = "Index" });
        //        }
                
        //    }
        //}

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
