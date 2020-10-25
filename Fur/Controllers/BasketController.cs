using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fur.Models;
using Fur.Service;

namespace Fur.Controllers
{
    public class BasketController : Controller
    {
        // GET: Basket
        //LampContext db = new LampContext();

        public ActionResult Basket()
        {

            var Basket = BasketService.GetBasket();
            
            
            return PartialView(Basket);
        }
        public JsonResult Sold(int OfferId)
        {
            int Count = 1;
            int Id = 0;
            var Basket = BasketService.GetBasketByOfferId(OfferId);

            if (Basket != null)
            {
                Count=Basket.Count;
                Id = Basket.Id;
                Count++;
            }
            BasketService.InsUpBasket(new Models.Basket() {Id= Id, OfferId= OfferId,Count= Count });

           return Json(true);
        }

        [HttpGet]
        public ActionResult Del(int Id)
        {

            BasketService.DelBasketById(Id);

            return RedirectToAction($"../Home/Index");
        }
        public ActionResult Max()
        {
            try
            {
                ViewData["Max"] = BasketService.GetBasket().ToList().Sum(x=>x.Count);
            }
            catch { }
            return PartialView();
        }
        public ActionResult Count()
        {
            try
            {
                ViewData["Count"] = BasketService.GetBasket().ToList().Sum(x=>x.Count);
            }
            catch { }
            return PartialView();
        }

    }
}