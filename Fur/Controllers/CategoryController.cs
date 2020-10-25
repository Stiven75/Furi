using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Fur.Models;
using Fur.Service;

namespace Fur.Controllers
{
    
    public class CategoryController : Controller
    {
       // LampContext db = new LampContext();
        [Route("{controller}/{stol}")]
        public ActionResult Index(string? Stol)
        {

            if (Stol != null)
            {
                var Category = CategoryService.GetCategory().Where(x => x.Name == Stol.ToString()).ToList();

                if (Category.Count != 0)
                {
                    ViewData["CategoryId"] = Category.First().Id;
                }
                else
                {
                    ViewData["CategoryId"] = 0;
                }

            }
            else
            {
                ViewData["CategoryId"] = 0;
            }



            //var Products = db.Products.Include(p => p.Category).Include(p => p.Offer).Include(p => p.Photo);//.Include(p => p.Baskets);
            var Products = ProductService.GetProducts().ToList();
            
            
            
            return View(Products);
        }
    }
}