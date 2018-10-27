using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HJ_Template_MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // ترتيب نوشتن اهميت دارد
            // و بايد دستورات استثناء ذيل، قبل از دستورات پيش فرض نوشته شوند

            routes.MapRoute(
               name: "Googooli",
               url: "L",
               defaults: new { controller = "Account", action = "Login"},
               namespaces: new[] { "HJ_Template_MVC.Controllers" }
           );

            //دستورات پيش فرض

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Users", action = "Create", id = UrlParameter.Optional },
                namespaces: new[] { "HJ_Template_MVC.Controllers" }
            );
        }
    }
}
