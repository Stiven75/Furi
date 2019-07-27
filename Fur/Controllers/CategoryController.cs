using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Fur.Models;

namespace Fur.Controllers
{
    
    public class CategoryController : Controller
    {
        LampContext db = new LampContext();
        public ActionResult Index()
        {
            var Products = db.Products.Include(p => p.Category).Include(p => p.Offer);
            return View(Products);
        }
    }
}