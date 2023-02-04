using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce.BusinessLayer;
using E_Commerce.Model;

namespace E_Commerce.Admin.Panel.Controllers
{
    public class DeliverySettingsController : Controller
    {
        // GET: Delivery
        public ActionResult AddDeliveryCost()
        {
            AdminViewModel deliverycharge = new AdminViewModel();
            deliverycharge.deliverycharge = new DeliveryCharge();
            return View(deliverycharge);
        }
        [HttpPost]
        public ActionResult AddDeliveryCost(DeliveryCharge charge)
        {
          
            if (charge.DeliveryChargeid > 0)
            {
                bool updte =  DeliverySettingsManager.UpdateDeliveryCost(charge);
                return View("AddDeliveryCost");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    long add = DeliverySettingsManager.AddNewDeliveryCost(charge);
                    return View("AddDeliveryCost");
                }
                else
                {
                    return View("AddDeliveryCost");
                }
            }
          
        }
        public ActionResult DeletedDeliveryCost(int id)
        {
            if (DeliverySettingsManager.DeleteDeliveryCost(id))
            {
                return View("AddDeliveryCost");
            }
            else
            {
                return View("AddDeliveryCost");
            }
          
        }
        public ActionResult GetSingleDeliveryChargeDeliveryCost(int id)
        {
            AdminViewModel deliverycharge = new AdminViewModel();
            deliverycharge.deliverycharge = DeliverySettingsManager.GetSingleDeliveryCost(id);
            return View("AddDeliveryCost", deliverycharge);
        }
        public ActionResult AddArea()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddArea(Area delivery)
        {

            return View();
        }
        public ActionResult DeleteArea()
        {

            return View();
        }
        public ActionResult GetSingleArea()
        {

            return View();
        }
        public ActionResult AddZone()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddZone(Zone delivery)
        {

            return View();
        }
        public ActionResult DeleteZone(Zone delivery)
        {

            return View();
        }
        public ActionResult GetsingleZone(Zone delivery)
        {

            return View();
        }
    }
}