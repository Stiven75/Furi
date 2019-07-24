using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fur.Models;
using System.Data.Entity;
using Fur.Controllers;


namespace Fur.Controllers
{
    [RoutePrefix("~/")]
    public class HomeController : Controller
    {
        LampContext db = new LampContext();
        Category f = new Category();
        public ActionResult Index()
        {

            var Products = db.Products.Include(p => p.Category).Include(p => p.Offer);
            return View(Products);
        }        
        [HttpPost]
        public ActionResult Index(string Stol)
        {
            ViewData["s"] = Stol;
            return Index();
        }

        [HttpGet]
        public ActionResult product(int Id=5)
        {
             ViewData["Nomer"] = Id;
           return Content($"controller: Product | action: Index");
        }

    }
}