using Fur.Models;
using Fur.Service;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fur.Controllers
{
    public class AdminController : Controller
    {

        ////LampContext db = new LampContext();
        //// GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        #region category
        public ActionResult Category()
        {

            return View();
        }

        [HttpPost]
        public JsonResult UpdateCategory(List<Category> categories)
        {
            //List<Category> categories
            try
            {
                foreach (var Categ in categories)
                {

                    CategoryService.InsUpCategory(Categ);
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;

            }


            return Json(new { result = "Данные сохранены" });
        }

        [HttpPost]
        public JsonResult AddCategory()
        {

            CategoryService.InsUpCategory(new Models.Category()
            {
                Id = 0,
                Name = null
            });



            return Json(new { result = "Категория добавлена" });
        }

        [HttpPost]
        public JsonResult DeleteCategory(List<Category> categories)
        {
            foreach (var category in categories)
            {
                CategoryService.DelCategory(category);
            }


            return Json(new { result = "Удаление произведено" });

        }


        public ActionResult CategoryPartial()
        {
            var Category = CategoryService.GetCategory();

            return PartialView(Category);
        }
        #endregion


        #region color
        public ActionResult Color()
        {

            return View();
        }

        [HttpPost]
        public JsonResult UpdateColor(List<Color> Colors)
        {
            try
            {
                foreach (var Color in Colors)
                {
                    ColorService.InsUpColor(Color);
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;

            }


            return Json(new { result = "Данные сохранены" });
        }

        [HttpPost]
        public JsonResult AddColor()
        {
            ColorService.InsUpColor(new Models.Color()
            {
                Id = 0,
                ColorCode = "#999999",
                Name = " "
            });

            //List<Category> categories
            //db.Database.ExecuteSqlCommand("INSERT INTO  [dbo].[Colors] (Id,[Name])  VALUES (@Id,@Name)",
            //    new SqlParameter("@Name", " "),
            //    new SqlParameter("@Id", db.Colors.Max(x => x.Id) + 1)
            //    );



            return Json(new { result = "Цвет добавлен" });
        }

        [HttpPost]
        public JsonResult DeleteColor(List<Color> Colors)
        {
            foreach (var color in Colors)
            {
                ColorService.DelColor(color);
            }


            return Json(new { result = "Удаление произведено" });

        }


        public ActionResult ColorPartial()
        {
            List<Color> Color = new List<Color>();

            var Colors = ColorService.GetColors();

            return PartialView(Colors);
        }


        #endregion


        #region size
        public ActionResult Size()
        {

            return View();
        }

        [HttpPost]
        public JsonResult UpdateSize(List<Size> Sizes)
        {
            //List<Category> categories
            try
            {
                foreach (var Size in Sizes)
                {
                    SizeService.InsUpSize(Size);


                    //db.Database.ExecuteSqlCommand("UPDATE [dbo].[Sizes] SET [Name]=@Name WHERE Id=@Id",
                    //    new SqlParameter("@Name", Size.Name),
                    //    new SqlParameter("@Id", Size.Id)
                    //    );
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;

            }


            return Json(new { result = "Данные сохранены" });
        }

        [HttpPost]
        public JsonResult AddSize()
        {
            //List<Category> categories

            SizeService.InsUpSize(new Models.Size()
            {

                Id = 0,
                Name = "",

            });




            return Json(new { result = "Размер добавлен" });
        }

        [HttpPost]
        public JsonResult DeleteSize(List<Size> Sizes)
        {
            foreach (var Size in Sizes)
            {

                SizeService.DelSize(Size);
            }


            return Json(new { result = "Удаление произведено" });

        }


        public ActionResult SizePartial()
        {

            var Sizes = SizeService.GetSize();

            return PartialView(Sizes);
        }
        #endregion 


        #region product
        public ActionResult Products()
        {

            return View();
        }

        [HttpPost]
        public JsonResult UpdateProduct(List<Product> Products)
        {
            //List<Category> categories
            try
            {
                foreach (var Product in Products)
                {
                    ProductService.InsUpProduct(Product);
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;

            }


            return Json(new { result = "Данные сохранены" });
        }

        [HttpPost]
        public JsonResult AddProduct()
        {
            //List<Category> categories

            ProductService.InsUpProduct(new Models.Product()
            {
                Id = 0,
                CategoryId = 0,
                Name = "Product",
                ArtNo = null,
                Enabled = false
            });





            return Json(new { result = "Товар добавлен" });
        }


        [HttpPost]
        public JsonResult DeleteProduct(List<Product> Products)
        {
            foreach (var Product in Products)
            {
                ProductService.DelProduct(Product);
            }
            return Json(new { result = "Удаление произведено" });

        }


        public ActionResult ProductsPartial()
        {

            var Products = ProductService.GetProducts();

            return PartialView(Products);
        }


        public ActionResult EditProduct(int ProductId)
        {
            var Product = ProductService.GetProductById(ProductId);

            return View(Product);
        }




        public JsonResult UpProductSTR(Product product)
        {
            var ProductOld = ProductService.GetProductById(product.Id);


            if (ProductOld == null)
            {
                return Json(new { result = 1 });
            }
            ProductOld.CategoryId = product.CategoryId;
            ProductOld.ArtNo = product.ArtNo;
            ProductOld.Enabled = product.Enabled;
            ProductOld.Name = product.Name;

            ProductService.InsUpProduct(ProductOld);

            return Json(1);


        }

        [HttpPost]
        public ActionResult UploadImg(HttpPostedFileBase upload, string ProductIdString)
        {
            int ProductId = int.Parse(ProductIdString);


            if (ProductId == 0)
            {
                return null;
            }





            var Product = ProductService.GetProductById(ProductId);

            if (upload != null)
            {        // получаем имя файла
                string fileName = Path.GetFileName(upload.FileName);
                try
                {
                    string fileNameold = fileName.Substring(0, fileName.LastIndexOf('.'));

                    fileName = fileName.Replace(fileNameold, Product.Id.ToString());

                    // сохраняем файл в папку Files в проекте
                    upload.SaveAs(Server.MapPath("~/img/" + fileName));// + fileName
                }
                catch (Exception ex)
                {
                    return Json(new { reslt = true });
                }
                Product.Photo = fileName;

                ProductService.InsUpProduct(Product);

            }


            return Redirect("/Admin/EditProduct/"+ Product.Id);

        }
        



        #endregion



        #region Offer

        public ActionResult OffersPartial(int ProductId)
        {
            return PartialView(OfferService.GetOffersByProductId(ProductId));
        }

        public JsonResult AddOffer(int ProductId)
        {

            var Product = ProductService.GetProductById(ProductId);

            if (Product == null)
            {
                return Json(new { result = false });
            }




            OfferService.InsUpOffer(new Offer()
            {
                Id = 0,
                ProductId = ProductId,
                ArtNo = Product.ArtNo + "-" + (Product.Offer.Count() + 1).ToString()


            });

            return Json(new { result = true });
        }

        public JsonResult UpOffer(List<Offer> Offers)
        {
            foreach (var Offer in Offers)
            {
                OfferService.InsUpOffer(Offer);
            }

            return Json(new { result = true });
        }

        public JsonResult DelOffer(List<Offer> Offers)
        {
            foreach (var Offer in Offers)
            {
                OfferService.DelOffer(Offer);
            }

            return Json(new { result = true });
        }



        #endregion
    }
}