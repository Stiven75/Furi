using Fur.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fur.Models;


namespace Fur.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {

            var Orders = OrderService.GetOrder();


            return View(Orders);
        }



        public ActionResult ItemOrder(int OrderId)
        {

            var Order = OrderService.GetOrder().Where(x => x.Id == OrderId).ToList();

            Order orderResponse = new Order();
            if (Order.Count() != 0)
            {
                orderResponse = Order.First();
            }


            orderResponse.goods = GoodService.GetBasketsByOrderId(orderResponse.Id).ToList();


            return PartialView(orderResponse);
        }
    }
}