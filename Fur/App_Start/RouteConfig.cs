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



            routes.MapRoute(
                name: "Product",
                url: "{controller}/{action}/url-{id}",
               defaults: new { controller = "Product", action = "Index" },
                                constraints: new { controller = "^Product.*", action = "^Index$" });
            routes.MapRoute(
                name: "Category",
                url: "{controller}/{stol}",
               defaults: new { controller = "Category", action = "Index" },
                constraints: new { controller = "^Category.*", action = "Index" });


            
                routes.MapRoute(
                name: "Color",
                url: "{controller}/{action}/{art}/{souz}",
               defaults: new { controller = "Product", action = "Color" },
                constraints: new { controller = "^Product.*", action = "^Color$" });
                        routes.MapRoute(
                 name: "Cat",
                 url: "{controller}/{action}",
                 defaults: new { controller = "Home", action = "Index" });
            
        }
    }
}
