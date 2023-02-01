using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce.Model;

namespace E_Commerce.Admin.Panel.Controllers
{
    public class DeliveryController : Controller
    {
        // GET: Delivery
        public ActionResult AddZone()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddZone(DeliveryChargeModel delivery)
        {

            return View();
        }
    }
}