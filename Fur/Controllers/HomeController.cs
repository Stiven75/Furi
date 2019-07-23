using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fur.Models;
using System.Data.Entity;

namespace Fur.Controllers
{
    public class HomeController : Controller
    {
        LampContext db = new LampContext();
        [Route("Category/Index")]
        public ActionResult Index()
        {
            var Products = db.Products.Include(p=>p.Category).Include(p => p.Offer);
            return View(Products);
        }
        [HttpPost]
        public ActionResult Index(string Stol)
        {
            ViewData["s"] = Stol;
            return Index();
        }

        
        public ActionResult Category()
        {
            return View(db.Categories);
        }
        /*[HttpGet]
         public ActionResult products(int Id)
         {

             IEnumerable<Bat> Bats = db.Bats;
             ViewBag.Bats = Bats;

             ViewData["Nomer"] = Id;
             return View(db.Lamps);
         }*/

    }
}