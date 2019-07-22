using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fur.Models;

namespace Fur.Controllers
{
    public class HomeController : Controller
    {
        LampContext db = new LampContext();
        СategoryContext dk = new СategoryContext();
        public ActionResult Index()
        {
           
                           
            IEnumerable<Сategory> Сategories = dk.Сategories;
            ViewBag.Сategories = Сategories;
            return View(db.Lamps);
        }
        [HttpGet]
        public ActionResult Index(string Stol)
        {
            ViewData["s"] = Stol;
            return Index();
        }


    }
}