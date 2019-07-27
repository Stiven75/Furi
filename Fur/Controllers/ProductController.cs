using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Fur.Models;

namespace Fur.Controllers
{
    [RoutePrefix("~/")]
    public class ProductController : Controller
    {

        // GET: Product
        LampContext db = new LampContext();
        [Route("~/Product/Index/url-{id}")]
        public ActionResult Index(int? Id)
        {
            ViewBag.Controller = "";
            ViewBag.Action = "";
            ViewBag.CustomVariable = "";
            var Products = db.Products.Include(p => p.Category).Include(p => p.Offer).Include(p => p.Photo);
            ViewData["Nomer"] = Id;
            return View(Products);
        }


        public ActionResult Color(string art,string souz)
        {
            try
            {
                string size = souz[1].ToString(), color = souz[0].ToString();

                ViewData["g"] = art;
                ViewData["color"] = color;
                ViewData["size"] = size;

            }
            catch  { }
            var Offers = db.Offers;
            //var Offers = db.Offers.Where(o => o.Color.Name.Contains(name)).ToList();
            return PartialView(Offers);
        }
    }

}