using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fur.Models;
using System.Data.Entity;
using Fur.Controllers;
using Fur.Service;

namespace Fur.Controllers
{
    [RoutePrefix("~/")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(string Stol)
        {
            ViewData["s"] = Stol;
            return Redirect($"~/Category/{Stol}");
        }
    }
}