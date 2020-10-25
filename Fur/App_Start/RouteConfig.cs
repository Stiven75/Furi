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
                 name: "admin",
                 url: "{controller}",
                  defaults: new { controller = "Home", action = "Index" },
                 constraints: new { controller = "Admin", action = "Index" });


            


            routes.MapRoute("Basket", "{controller}/{action}", new { controller = "Home", action = "Index" }, new { Controller = "Basket", Action = "Basket" });


            routes.MapRoute(
                name: "Product",
                url: "{controller}/{action}/url-{id}",
               defaults: new { controller = "Home", action = "Index" },
                                constraints: new { controller = "^Product.*", action = "^Index$" });

            routes.MapRoute("Category", "{controller}/{stol}", new { controller = "Home", action = "Index" }, new { Controller = "Category", Action = "Index" });


            routes.MapRoute("CategoryAll", "{controller}", new { controller = "Home", action = "Index" }, new { Controller = "Category", Action = "Index" });



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

            routes.MapRoute(
                    name: "GetProduct",
                    url: "{controller}/{action}",
                    defaults: new { controller = "Home", action = "Index" },
                    constraints: new { controller = "Product", action = "GetProduct" });


            routes.MapRoute(
                name: "OrderFinaly",
                url: "{controller}/{action}/{OrderId}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { controller = "Order", action = "Finaly" });


            routes.MapRoute(
                name: "Client",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { controller = "Client", action = "Index" });


            routes.MapRoute(
                name: "ClientOrderItem",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { controller = "Client", action = "ItemOrder" });




            #region admin

            routes.MapRoute(
                 name: "UpdateCategory",
                 url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                 constraints: new { controller = "Admin", action = "UpdateCategory" });

            routes.MapRoute(
                 name: "AddCategory",
                 url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                 constraints: new { controller = "Admin", action = "AddCategory" });


            routes.MapRoute(
                 name: "AdminCategory",
                 url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                 constraints: new { controller = "Admin", action = "Category" });

            routes.MapRoute(
                 name: "CategoryPartial",
                 url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                 constraints: new { controller = "Admin", action = "CategoryPartial" });

            routes.MapRoute(
                 name: "DeleteCategory",
                 url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                 constraints: new { controller = "Admin", action = "DeleteCategory" });



            

            routes.MapRoute(
             name: "UpdateColor",
             url: "{controller}/{action}",
            defaults: new { controller = "Home", action = "Index" },
             constraints: new { controller = "Admin", action = "UpdateColor" });

            routes.MapRoute(
                 name: "AddColor",
                 url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                 constraints: new { controller = "Admin", action = "AddColor" });


            routes.MapRoute(
                 name: "AdminColor",
                 url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                 constraints: new { controller = "Admin", action = "Color" });

            routes.MapRoute(
                 name: "ColorPartial",
                 url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                 constraints: new { controller = "Admin", action = "ColorPartial" });

            routes.MapRoute(
                 name: "DeleteColor",
                 url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                 constraints: new { controller = "Admin", action = "DeleteColor" });



            routes.MapRoute(
           name: "UpdateSize",
           url: "{controller}/{action}",
          defaults: new { controller = "Home", action = "Index" },
           constraints: new { controller = "Admin", action = "UpdateSize" });

            routes.MapRoute(
                 name: "AddSize",
                 url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                 constraints: new { controller = "Admin", action = "AddSize" });


            routes.MapRoute(
                 name: "AdminSize",
                 url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                 constraints: new { controller = "Admin", action = "Size" });

            routes.MapRoute(
                 name: "SizePartial",
                 url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                 constraints: new { controller = "Admin", action = "SizePartial" });

            routes.MapRoute(
                 name: "DeleteSize",
                 url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                 constraints: new { controller = "Admin", action = "DeleteSize" });



            routes.MapRoute(
      name: "UpdateProduct",
      url: "{controller}/{action}",
     defaults: new { controller = "Home", action = "Index" },
      constraints: new { controller = "Admin", action = "UpdateProduct" });

            routes.MapRoute(
                 name: "AddProduct",
                 url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                 constraints: new { controller = "Admin", action = "AddProduct" });


            routes.MapRoute(
                 name: "AdminProduct",
                 url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                 constraints: new { controller = "Admin", action = "Products" });

            routes.MapRoute(
                 name: "ProductPartial",
                 url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                 constraints: new { controller = "Admin", action = "ProductsPartial" });

            routes.MapRoute(
                 name: "DeleteProduct",
                 url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                 constraints: new { controller = "Admin", action = "DeleteProduct" });


            routes.MapRoute(
                name: "EditProduct",
                url: "{controller}/{action}/{ProductId}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { controller = "Admin", action = "EditProduct" });

            routes.MapRoute(
                name: "OffersPartial",
                url: "{controller}/{action}/{ProductId}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { controller = "Admin", action = "OffersPartial" });

            routes.MapRoute(
                name: "UpProductSTR",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { controller = "Admin", action = "UpProductSTR" });
            routes.MapRoute(
                name: "UploadImg",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { controller = "Admin", action = "UploadImg" });

            routes.MapRoute(
                name: "AddOffer",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { controller = "Admin", action = "AddOffer" });




            routes.MapRoute(
                name: "UpOffer",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { controller = "Admin", action = "UpOffer" });



            routes.MapRoute(
                name: "DelOffer",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { controller = "Admin", action = "DelOffer" });


            #endregion

            routes.MapRoute("Default", "{controller}/{action}", new { controller = "Home", action = "Index" }, new { Controller = "Home" });

        }
    }
}
