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
                bool updated =  DeliverySettingsManager.UpdateDeliveryCost(charge);
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
            AdminViewModel area = new AdminViewModel();
            area.area = new Area();
            return View(area);
        }
        [HttpPost]
        public ActionResult AddArea(Area area) 
        {
            if (area.ZoneId>0)
            {
                bool updated = DeliverySettingsManager.UpdateArea(area);
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    long added = DeliverySettingsManager.AddNewArea(area);
                }
                return View();
            }
          
        }
        public ActionResult DeleteArea(int id)
        {
            if (id<0)
            {
                bool deleted = DeliverySettingsManager.DeleteArea(id);
            }
            return View();
        }
        public ActionResult GetSingleArea(int id)
        {
            AdminViewModel area = new AdminViewModel();
            area.area = DeliverySettingsManager.GetSingleArea(id);
            return View();
        }
        public ActionResult AddZone()
        {
            AdminViewModel zone = new AdminViewModel();
            zone.zone = new Zone();
            return View(zone);
        }
        [HttpPost]
        public ActionResult AddZone(Zone zone)
        {
            if (zone.Placeid>0)
            {
              //  bool updated = DeliverySettingsManager.UpdateZone();
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    //long addded = DeliverySettingsManager.AddNewZone(zone);
                  
                }
                return View();
            }
           
        }
        public ActionResult DeleteZone(int id)
        {
            if (id>0)
            {
                bool deleted = DeliverySettingsManager.DeleteZone(id);
            }
            return View();
        }
        public ActionResult GetsingleZone(int id)
        {
            AdminViewModel zone = new AdminViewModel();
         //   zone.zone = DeliverySettingsManager.GetSingleZone(id);
            return View(zone);
        }
    }
}