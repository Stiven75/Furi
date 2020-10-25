using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fur.Models;
using System.Data.Entity;
using Fur.Service;

namespace Fur.Controllers
{
    public class OrderController : Controller
    {
        //LampContext db = new LampContext();
        public ActionResult Index()
        {
            // var Bas = db.Baskets.Include(b => b.Offer);
            var Basket = BasketService.GetBasket();


            return View(Basket);
        }
        public ActionResult Delivery()
        {
          //  var f = db.Deliveries;
            return PartialView();
        }
        public ActionResult Variant()
        {
         //   var Ba = db.Variants;
            try
            {
               /// ViewData["maxime"] = db.Orders.Max(b => b.Id);
            }
            catch { ViewData["maxime"] = 0; }
            ViewData["maxime"] = Convert.ToInt32(ViewData["maxime"]) + 1;
            return PartialView();
        }
        public ActionResult Sum()
        {
            try
            {
               // ViewData["sum"] = db.Baskets.Sum(b => b.Price);
            }
            catch { ViewData["sum"] = 0; }
            return PartialView();
        }
        public ActionResult Finaly(int OrderId)
        {

            var Order = OrderService.GetOrder().Where(x => x.Id == OrderId).ToList();

            Order orderResponse = new Order();
            if (Order.Count() != 0)
            {
                orderResponse = Order.First();
            }


            orderResponse.goods = GoodService.GetBasketsByOrderId(orderResponse.Id).ToList();


            return View(orderResponse);
        }


        public JsonResult CreateOrder(Order OrderNew)
        {
            var Baskets = BasketService.GetBasket();
            var Order = OrderService.GetOrder();
            int NextOrderId = 0;
         
            if (Baskets.Count() == 0){ return Json(new { result = false,msg="Корзина пуста" }); }

            OrderNew.CostOrder = Baskets.Sum(x => x.Offer.Price * x.Count);
           
            if (Order.Count() == 0)
            {
                NextOrderId = 1;
            }
            else
            {
                NextOrderId = Order.Max(x => x.Id) + 1;
            }

            OrderService.InsUpOrder(OrderNew);

            var OrderCurent = OrderService.GetOrder().Where(x=>x.Id==NextOrderId).First();

            foreach (var BasketItem in Baskets)
            {
                GoodService.InsUpGoods(new Good() { 
                    ArtNo=BasketItem.Offer.ArtNo,
                    Count=BasketItem.Count,
                    OfferId=BasketItem.OfferId,
                    OrderId=OrderCurent.Id,
                    Price=BasketItem.Offer.Price    
                });

                BasketService.DelBasketById(BasketItem.Id);
            }




            return Json(new { result=true,msg="Заказ создан",OrderId= OrderCurent.Id});
        }



    }



}