using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fur.Models;
using System.Data.Entity;

namespace Fur.Controllers
{
    public class BasketController : Controller
    {
        // GET: Basket
        LampContext db = new LampContext();

        public ActionResult Basket()
        {
            //.Include(b => b.Product.Offer).Include(b=>b.Product.Offer.Color).Include(b=>b.Product.Offer.Size)
            var Baskets = db.Baskets.Include(b=>b.Product).Include(b => b.Product.Offer).Include(b=>b.Product.Category).Include(b => b.Product.Photo);
            return PartialView(Baskets);
        }

        public ActionResult Sold(string ProductId,string Articul)
        {
            string sum = Articul.Remove(0, 7);
            Articul = Articul.Remove(7, Articul.Length-7);
            ViewData["grom"]="fario";
            Basket d = new Basket();
            d.ProductId = Convert.ToInt32(ProductId);
            d.Articul = Articul;
            d.Price = Convert.ToInt32(sum);
            db.Baskets.Add(d);
            db.SaveChanges();
            var Baskets = db.Baskets.Include(b => b.Product).Include(b => b.Product.Offer).Include(b => b.Product.Category).Include(b => b.Product.Photo);
            return PartialView(Baskets);
        }
        public ActionResult Del(int Id)
        {
            try
            {
                ViewData["grom"] = "red";
                Basket b = new Basket { Id = Id };
                db.Entry(b).State = EntityState.Deleted;
                db.SaveChanges();
            }
            catch { }
            return RedirectToAction($"~/Home/Index");
        }




        public ActionResult Max()
        {
            try
            {
                ViewData["max"] = db.Baskets.Max(b => b.Id);
            }
            catch { }
            return PartialView();
        }


    }
}