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

            routes.MapRoute("Basket", "{controller}/{action}", new { controller = "Home", action = "Index" }, new { Controller = "Basket", Action = "Basket" });


            routes.MapRoute(
                name: "Product",
                url: "{controller}/{action}/url-{id}",
               defaults: new { controller = "Home", action = "Index" },
                                constraints: new { controller = "^Product.*", action = "^Index$" });

            routes.MapRoute("Category", "{controller}/{stol}", new { controller = "Home", action = "Index" }, new { Controller = "Category", Action = "Index" });

            routes.MapRoute(
                name: "Json",
                url: "{controller}/{action}/",
               defaults: new { controller = "Home", action = "Index" },
                constraints: new { controller = "^Product.*", action = "^Color$" });
            routes.MapRoute(
                 name: "Baskets",
                 url: "{controller}/{action}/",
                defaults: new { controller = "Home", action = "Index" },
                 constraints: new { controller = "^Basket.*" });
            routes.MapRoute(
             name: "Orders",
             url: "{controller}/{action}/",
            defaults: new { controller = "Home", action = "Index" },
             constraints: new { controller = "^Order.*" });

            routes.MapRoute(
                 name: "Max",
                 url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                 constraints: new { controller = "Basket",action="Max" });


            routes.MapRoute("Default", "{controller}/{action}", new { controller = "Home", action = "Index" }, new { Controller = "Home" });

        }
    }
}
