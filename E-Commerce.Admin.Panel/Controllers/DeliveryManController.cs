using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Admin.Panel.Controllers
{
    public class DeliveryManController : Controller
    {
        // GET: DeliveryMan
        public ActionResult AddNewDeliveryMan()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewDeliveryMan()
        {
            return View();
        }
    }
}