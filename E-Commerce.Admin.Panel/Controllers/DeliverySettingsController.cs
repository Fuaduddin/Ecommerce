using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce.BusinessLayer;
using E_Commerce.Model;
using Newtonsoft.Json;

namespace E_Commerce.Admin.Panel.Controllers
{
    public class DeliverySettingsController : Controller
    {
        // GET: Delivery
        //Delivery Charge
        public ActionResult AddDeliveryCost()
        {
            AdminViewModel deliverycharge = new AdminViewModel();
            deliverycharge.deliverycharge = new DeliveryCharge();
            deliverycharge.deliverychargeList = perpageshowdata(1,10);
            deliverycharge.totalpage = pagecount(10);
            return View(deliverycharge);
        }
        [HttpPost]
        public ActionResult AddDeliveryCost(AdminViewModel charge)
        {
          
            if (charge.deliverycharge.DeliveryChargeid > 0)
            {
                bool updated =  DeliverySettingsManager.UpdateDeliveryCost(charge.deliverycharge);
                AdminViewModel deliverycharge = new AdminViewModel();
                deliverycharge.deliverychargeList = perpageshowdata(1, 10);
                deliverycharge.totalpage = pagecount(10);
                deliverycharge.deliverycharge = new DeliveryCharge();
                return View("AddDeliveryCost", deliverycharge);
            }
            else
            {
                    AdminViewModel deliverycharge = new AdminViewModel();
                    deliverycharge.deliverychargeList = perpageshowdata(1, 10);
                    deliverycharge.totalpage = pagecount(10);
                    charge.deliverycharge.PreviousDeliveryChargeAmount = 0;
                    deliverycharge.deliverycharge = new DeliveryCharge();
                    long add = DeliverySettingsManager.AddNewDeliveryCost(charge.deliverycharge);
                    return View("AddDeliveryCost", deliverycharge);
            }
          
        }
        public ActionResult DeletedDeliveryCost(int id)
        {
            if (DeliverySettingsManager.DeleteDeliveryCost(id))
            {
                AdminViewModel deliverycharge = new AdminViewModel();
                deliverycharge.deliverychargeList = perpageshowdata(1, 10);
                deliverycharge.totalpage = pagecount(10);
                return View("AddDeliveryCost", deliverycharge);
            }
            else
            {
                AdminViewModel deliverycharge = new AdminViewModel();
                deliverycharge.deliverychargeList = perpageshowdata(1, 10);
                deliverycharge.totalpage = pagecount(10);
                return View("AddDeliveryCost", deliverycharge);
            }
          
        }
        public ActionResult GetSingleDeliveryChargeDeliveryCost(int id)
        {
            AdminViewModel deliverycharge = new AdminViewModel();
            deliverycharge.deliverycharge = DeliverySettingsManager.GetSingleDeliveryCost(id);
            deliverycharge.deliverychargeList = perpageshowdata(1, 10);
            deliverycharge.totalpage = pagecount(10);
            return View("AddDeliveryCost", deliverycharge);
        }
        public int pagecount(int perpagedata)
        {
            IEnumerable<DeliveryCharge> deliverycharge = DeliverySettingsManager.GetAllDeliveryCost();
            return Convert.ToInt32(Math.Ceiling(deliverycharge.Count() / (double)perpagedata));
        }

        public List<DeliveryCharge> perpageshowdata(int pageindex, int pagesize)
        {
            IEnumerable<DeliveryCharge> deliverycharge = DeliverySettingsManager.GetAllDeliveryCost();
            return deliverycharge.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }

        public JsonResult Getpaginatiotabledata(int pageindex, int pagesize)
        {
            List<DeliveryCharge> deliverychargelist = perpageshowdata(pageindex, pagesize);
            var result = JsonConvert.SerializeObject(deliverychargelist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //Zone
        public ActionResult AddZone()
        {
            AdminViewModel zone = new AdminViewModel();
            zone.zone = new Zone();
            zone.deliverychargeList = DeliverySettingsManager.GetAllDeliveryCost();
            zone.viewzone = perpageshowdatazone(1, 10);
            zone.totalpage = pagecountzone(10);
            return View(zone);
        }
        [HttpPost]
        public ActionResult AddZone(Zone zone, string division)
        {
            if (zone.Placeid > 0)
            {
                zone.PlaceName = division;
                bool updated = DeliverySettingsManager.UpdateZone(zone);
                AdminViewModel zoneitem = new AdminViewModel();
                zoneitem.zone = new Zone();
                zoneitem.deliverychargeList = DeliverySettingsManager.GetAllDeliveryCost();
                zoneitem.totalpage = pagecountzone(10);
                zoneitem.viewzone = perpageshowdatazone(1, 10);
                return View("AddZone", zoneitem);
            }
            else
            {

                zone.PlaceName = division;
                long addded = DeliverySettingsManager.AddNewZone(zone);
                AdminViewModel zoneitem = new AdminViewModel();
                zoneitem.zone = new Zone();
                zoneitem.deliverychargeList = DeliverySettingsManager.GetAllDeliveryCost();
                zoneitem.totalpage = pagecountzone(10);
                zoneitem.viewzone = perpageshowdatazone(1, 10);
                return View("AddZone", zoneitem);
            }

        }
        public ActionResult DeleteZone(int id)
        {
            if (id > 0)
            {
                bool deleted = DeliverySettingsManager.DeleteZone(id);
            }
            AdminViewModel zoneitem = new AdminViewModel();
            zoneitem.deliverychargeList = DeliverySettingsManager.GetAllDeliveryCost();
            zoneitem.totalpage = pagecountzone(10);
            zoneitem.viewzone = perpageshowdatazone(1, 10);
            return View("AddZone", zoneitem);
        }
        public ActionResult GetsingleZone(int id)
        {
            AdminViewModel zone = new AdminViewModel();
            zone.zone = DeliverySettingsManager.GetSingleZone(id);
            zone.deliverychargeList = DeliverySettingsManager.GetAllDeliveryCost();
            zone.totalpage = pagecountzone(10);
            zone.viewzone = perpageshowdatazone(1, 10);
            return View("AddZone", zone);
        }
        public int pagecountzone(int perpagedata)
        {
            IEnumerable<viewZone> deliverycharge = DeliverySettingsManager.GetAllZone();
            return Convert.ToInt32(Math.Ceiling(deliverycharge.Count() / (double)perpagedata));
        }

        public List<viewZone> perpageshowdatazone(int pageindex, int pagesize)
        {
            IEnumerable<viewZone> deliverycharge = DeliverySettingsManager.GetAllZone();
            return deliverycharge.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }

        public JsonResult Getpaginatiotabledatazone(int pageindex, int pagesize)
        {
            List<viewZone> deliverychargelist = perpageshowdatazone(pageindex, pagesize);
            var result = JsonConvert.SerializeObject(deliverychargelist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //area
        public ActionResult AddArea()
        {
            AdminViewModel area = new AdminViewModel();
            area.area = new Area();
            area.areaList = perpageshowdataarea(1, 10);
            area.totalpage = pagecountarea(10);
            area.viewzone = DeliverySettingsManager.GetAllZone();
            return View(area);
        }
        [HttpPost]
        public ActionResult AddArea(Area area, string districts)
        {
            area.DevisionName = districts;
            long added = DeliverySettingsManager.AddNewArea(area);
            AdminViewModel areaitem = new AdminViewModel();
            areaitem.areaList = perpageshowdataarea(1, 10);
            areaitem.totalpage = pagecountarea(10);
            areaitem.viewzone = DeliverySettingsManager.GetAllZone();
            return View("AddArea", areaitem);
        }
            public ActionResult DeleteArea(int id)
          { 
              if (id>0) 
              {
               bool deleted = DeliverySettingsManager.DeleteArea(id);
              }
            AdminViewModel areaitem = new AdminViewModel();
            areaitem.areaList = perpageshowdataarea(1, 10);
            areaitem.totalpage = pagecountarea(10);
            areaitem.viewzone = DeliverySettingsManager.GetAllZone();
            return View("AddArea", areaitem);
        }
            public int pagecountarea(int perpagedata)
        {
            IEnumerable<Area> deliverycharge = DeliverySettingsManager.GetAllArea();
            return Convert.ToInt32(Math.Ceiling(deliverycharge.Count() / (double)perpagedata));
        }

        public List<Area> perpageshowdataarea(int pageindex, int pagesize)
        {
            IEnumerable<Area> deliverycharge = DeliverySettingsManager.GetAllArea();
            return deliverycharge.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }

        public JsonResult Getpaginatiotabledataarea(int pageindex, int pagesize)
        {
            List<Area> deliverychargelist = perpageshowdataarea(pageindex, pagesize);
            var result = JsonConvert.SerializeObject(deliverychargelist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}