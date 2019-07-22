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

        public ActionResult Index()
        {
            IEnumerable<Lamp> Lamps = db.Lamps;
            ViewBag.Lamps = Lamps;
            IEnumerable<Bat> Bats = db.Bats;
            ViewBag.Bats = Bats;

            return View();
        }
        [HttpPost]
        public ActionResult Index(string Stol)
        {
            ViewData["s"] = Stol;
            return Index();
        }
    
                    
       [HttpGet]
        public ActionResult products(int Id)
        {
           

            ViewData["Nomer"] = Id;
            return View(db.Lamps);
        }

    }
}