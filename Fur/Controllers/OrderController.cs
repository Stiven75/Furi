using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fur.Models;
using System.Data.Entity;


namespace Fur.Controllers
{
    public class OrderController : Controller
    {
        LampContext db = new LampContext();
        public ActionResult Index()
        {
            var Bas = db.Baskets.Include(b => b.Product);
        
            return View(Bas);
        }
        public ActionResult Delivery()
        {
            var f = db.Deliveries;
            return PartialView(f);
        }
        public ActionResult Variant()
        {
            var Ba = db.Variants;
            try
            {
                ViewData["maxime"] = db.Orders.Max(b => b.Id);
            }
            catch { ViewData["maxime"] = 0; }
            ViewData["maxime"] = Convert.ToInt32(ViewData["maxime"]) + 1;
            return PartialView(Ba);
        }
        public ActionResult Sum()
        {
            try
            {
                ViewData["sum"] = db.Baskets.Sum(b => b.Price);
            }
            catch { ViewData["sum"] = 0; }
            return PartialView();
        }
        public ActionResult Final()
        {

            try
            {
                ViewData["maxime"] = db.Orders.Max(b => b.Id);
                ViewData["maxime"] = db.Orders.Max(b => b.Id);
                ViewData["maxime"] = db.Orders.Max(b => b.Id);
            }
            catch { ViewData["maxime"] = 0; }
            return View();
        }



        public ActionResult Solder(string imua, string nomer)
        {
                int k = nomer.Length;
                int v = Convert.ToInt32(nomer.Remove(0, k - 1));
                nomer = nomer.Remove(k - 1, 1);
                int d = Convert.ToInt32(nomer.Remove(0, k - 2));
                nomer = nomer.Remove(k - 2, 1);
             Order g = new Order();
             g.Name = imua;
             g.Telefon = nomer;
             g.VariantId = v;
             g.DeliveryId = d;
             db.Orders.Add(g);
             db.SaveChanges();

            return View();
        }
        public ActionResult Goodi(string ind, string art)
        {
            string sum = art.Remove(0, 7);
            art = art.Remove(7, art.Length - 7);

              Good g = new Good();
              g.OrderId = Convert.ToInt32(ind);
              g.Price = sum;
              g.Artikul = art;
              db.Goods.Add(g);
              db.SaveChanges();

            return View();
        }
    }
}