using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce.BusinessLayer;
using E_Commerce.Model;
using Newtonsoft.Json;

namespace E_commerce.Deliver.Controllers
{
    public class DeliveryManDashBoardController : Controller
    {
        // GET: DeliveryManDashBoard
        public ActionResult DashBoard()
        {
            DeliveryManModel deliveryman=(DeliveryManModel)Session["DeliveryManDetails"];
            return View("DashBoard");
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("login", "login");
        }

    }
}