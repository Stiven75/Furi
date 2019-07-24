using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Routing.Constraints;

namespace Fur
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           // routes.MapRoute(
              //  name: "Default",
              //  url: "{controller}/{action}/{id}",
             //   defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
            routes.MapRoute(
                name: "default1",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" });
            routes.MapRoute(
                name: "Product",
                url: "{controller}/{action}/url-{id}",
                defaults: new { controller = "Product", action = "Index", },
                                constraints: new { controller = "^Product.*", action = "^Index$" });
            routes.MapRoute(
                name: "Category",
                url: "{controller}/{action}/{stol}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { controller = "^Home.*", action = "^Index$" });
        }
    }
}
