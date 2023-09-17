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
                if(DeliverySettingsManager.UpdateDeliveryCost(charge.deliverycharge))
                {
                    ViewData["Message"] = "Your data have been Updated";
                    ModelState.Clear();
                }
                else
                {
                    ViewData["Message"] = "Your data have not been Updated";
                }
                //AdminViewModel deliverycharge = new AdminViewModel();
                //deliverycharge.deliverychargeList = perpageshowdata(1, 10);
                //deliverycharge.totalpage = pagecount(10);
                //deliverycharge.deliverycharge = new DeliveryCharge();
                //return View("AddDeliveryCost", deliverycharge);
            }
            else
            {
                if (DeliverySettingsManager.AddNewDeliveryCost(charge.deliverycharge)>0)
                {
                    ViewData["Message"] = "Your data have been Added";
                    ModelState.Clear();
                }
                else
                {
                    ViewData["Message"] = "Your data have not been Added";
                }
                    //AdminViewModel deliverycharge = new AdminViewModel();
                    //deliverycharge.deliverychargeList = perpageshowdata(1, 10);
                    //deliverycharge.totalpage = pagecount(10);
                    //charge.deliverycharge.PreviousDeliveryChargeAmount = 0;
                    //deliverycharge.deliverycharge = new DeliveryCharge();
                    //return View("AddDeliveryCost", deliverycharge);
            }
            AdminViewModel deliverycharge = new AdminViewModel();
            deliverycharge.deliverychargeList = perpageshowdata(1, 10);
            deliverycharge.totalpage = pagecount(10);
            charge.deliverycharge.PreviousDeliveryChargeAmount = 0;
            deliverycharge.deliverycharge = new DeliveryCharge();
            return View("AddDeliveryCost", deliverycharge);

        }
        public ActionResult Multiedelete(int[] multidelete)
        {
            int i = 0;
            AdminViewModel delivery = new AdminViewModel();
            if (multidelete != null)
            {
                foreach (int multid in multidelete)
                {
                    DeliverySettingsManager.DeleteDeliveryCost(multid);
                    i++;
                }
            }
            if(multidelete.Length==i)
            {
                ViewData["Message"] = "Your data have  been Deleted";
                //delivery.deliverychargeList = perpageshowdata(1, 10);
                //delivery.totalpage = pagecount(10);
                //delivery.deliverycharge = new DeliveryCharge();
            }
            else
            {
                ViewData["Message"] = "Your data have not been Deleted";
                //delivery.deliverychargeList = perpageshowdata(1, 10);
                //delivery.totalpage = pagecount(10);
                //delivery.deliverycharge = new DeliveryCharge();
            }
            delivery.deliverychargeList = perpageshowdata(1, 10);
            delivery.totalpage = pagecount(10);
            delivery.deliverycharge = new DeliveryCharge();
            return View("AddDeliveryCost", delivery);
        }
        public ActionResult DeletedDeliveryCost(int id)
        {
            if (DeliverySettingsManager.DeleteDeliveryCost(id))
            {
                ViewData["Message"] = "Your data have been Deleted";
                //AdminViewModel deliverycharge = new AdminViewModel();
                //deliverycharge.deliverychargeList = perpageshowdata(1, 10);
                //deliverycharge.totalpage = pagecount(10);
                //return View("AddDeliveryCost", deliverycharge);
            }
            else
            {
                ViewData["Message"] = "Your data have not been Deleted";
                //AdminViewModel deliverycharge = new AdminViewModel();
                //deliverycharge.deliverychargeList = perpageshowdata(1, 10);
                //deliverycharge.totalpage = pagecount(10);
                //return View("AddDeliveryCost", deliverycharge);
            }
            AdminViewModel deliverycharge = new AdminViewModel();
            deliverycharge.deliverychargeList = perpageshowdata(1, 10);
            deliverycharge.totalpage = pagecount(10);
            return View("AddDeliveryCost", deliverycharge);

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
        public JsonResult SearchDeliveryCharge(string SearchKeyword)
        {
            List<DeliveryCharge> categorylist = DeliverySettingsManager.SearchDeliveryCost(SearchKeyword);
            var result = JsonConvert.SerializeObject(categorylist);
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
                if(DeliverySettingsManager.UpdateZone(zone))
                {
                    ViewData["Message"] = "Your data have been Updated";
                    ModelState.Clear();
                    //zoneitem.zone = new Zone();
                    //zoneitem.deliverychargeList = DeliverySettingsManager.GetAllDeliveryCost();
                    //zoneitem.totalpage = pagecountzone(10);
                    //zoneitem.viewzone = perpageshowdatazone(1, 10);
                }
                else
                {
                    ViewData["Message"] = "Your data have not been Updated";
                    //ModelState.Clear();
                    //zoneitem.zone = new Zone();
                    //zoneitem.deliverychargeList = DeliverySettingsManager.GetAllDeliveryCost();
                    //zoneitem.totalpage = pagecountzone(10);
                    //zoneitem.viewzone = perpageshowdatazone(1, 10);
                }
            }
            else
            {
                zone.PlaceName = division;
               // AdminViewModel zoneitem = new AdminViewModel();
                if (DeliverySettingsManager.AddNewZone(zone) > 0)
                {
                    ViewData["Message"] = "Your data have  been Added";
                    //ModelState.Clear();
                    //zoneitem.zone = new Zone();
                    //zoneitem.deliverychargeList = DeliverySettingsManager.GetAllDeliveryCost();
                    //zoneitem.totalpage = pagecountzone(10);
                    //zoneitem.viewzone = perpageshowdatazone(1, 10);
                    ModelState.Clear();
                }
                else
                {
                    ViewData["Message"] = "Your data have not been Added";
                    //ModelState.Clear();
                    //zoneitem.zone = new Zone();
                    //zoneitem.deliverychargeList = DeliverySettingsManager.GetAllDeliveryCost();
                    //zoneitem.totalpage = pagecountzone(10);
                    //zoneitem.viewzone = perpageshowdatazone(1, 10);
                }
            }
            AdminViewModel zoneitem = new AdminViewModel();
            zoneitem.zone = new Zone();
            zoneitem.deliverychargeList = DeliverySettingsManager.GetAllDeliveryCost();
            zoneitem.totalpage = pagecountzone(10);
            zoneitem.viewzone = perpageshowdatazone(1, 10);
            return View("AddZone", zoneitem);

        }
        public ActionResult MultiedeleteZone(int[] multidelete)
        {
            int i = 0;
            AdminViewModel delivery = new AdminViewModel();
            if (multidelete != null)
            {
                foreach (int multid in multidelete)
                {
                    DeliverySettingsManager.DeleteZone(multid);
                    i++;
                }
            }
            if(multidelete.Length==i)
            {
                ViewData["Message"] = "Your data have  been Deleted";
                //delivery.deliverychargeList = perpageshowdata(1, 10);
                //delivery.totalpage = pagecount(10);
            }
           else
            {
                ViewData["Message"] = "Your data have not been Deleted";
                //delivery.deliverychargeList = perpageshowdata(1, 10);
                //delivery.totalpage = pagecount(10);
            }
            delivery.deliverychargeList = perpageshowdata(1, 10);
            delivery.totalpage = pagecount(10);
            return View("AddZone", delivery);
        }
        public ActionResult DeleteZone(int id)
        {
            AdminViewModel zoneitem = new AdminViewModel();
            if(DeliverySettingsManager.DeleteZone(id))
            {
                ViewData["Message"] = "Your data have  been Deleted";
                //zoneitem.deliverychargeList = DeliverySettingsManager.GetAllDeliveryCost();
                //zoneitem.totalpage = pagecountzone(10);
                //zoneitem.viewzone = perpageshowdatazone(1, 10);
            }
            else
            {
                ViewData["Message"] = "Your data have not been Deleted";
                //zoneitem.deliverychargeList = DeliverySettingsManager.GetAllDeliveryCost();
                //zoneitem.totalpage = pagecountzone(10);
                //zoneitem.viewzone = perpageshowdatazone(1, 10);
            }
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
        public JsonResult SearchZone(string SearchKeyword)
        {
            List<DeliveryCharge> categorylist = DeliverySettingsManager.SearchDeliveryCost(SearchKeyword);
            var result = JsonConvert.SerializeObject(categorylist);
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
            //area.DevisionName = districts;
            //AdminViewModel areaitem = new AdminViewModel();
            if(DeliverySettingsManager.AddNewArea(area)>0)
            {
                ViewData["Message"] = "Your data have been Added";
                ModelState.Clear();
                //areaitem.areaList = perpageshowdataarea(1, 10);
                //areaitem.totalpage = pagecountarea(10);
                //areaitem.viewzone = DeliverySettingsManager.GetAllZone();
            }
            else
            {
                ViewData["Message"] = "Your data have not been Added";
                //ModelState.Clear();
                //areaitem.areaList = perpageshowdataarea(1, 10);
                //areaitem.totalpage = pagecountarea(10);
                //areaitem.viewzone = DeliverySettingsManager.GetAllZone();
            }
            area.DevisionName = districts;
            AdminViewModel areaitem = new AdminViewModel();
            areaitem.areaList = perpageshowdataarea(1, 10);
            areaitem.totalpage = pagecountarea(10);
            areaitem.viewzone = DeliverySettingsManager.GetAllZone();
            return View("AddArea", areaitem);
        }
        public ActionResult MultiedeleteArea(int[] multidelete)
        {
            int i = 0;
            AdminViewModel delivery = new AdminViewModel();
            if (multidelete != null)
            {
                foreach (int multid in multidelete)
                {
                    DeliverySettingsManager.DeleteArea(multid);
                    i++;
                }
            }
            if(multidelete.Length==i)
            {
                ViewData["Message"] = "Your data have been Deleted";
                //delivery.deliverychargeList = perpageshowdata(1, 10);
                //delivery.totalpage = pagecount(10);
            }
            else
            {
                ViewData["Message"] = "Your data have not been Deleted";
                //delivery.deliverychargeList = perpageshowdata(1, 10);
                //delivery.totalpage = pagecount(10);
            }
            delivery.deliverychargeList = perpageshowdata(1, 10);
            delivery.totalpage = pagecount(10);
            return View("AddArea", delivery);
        }
        public ActionResult DeleteArea(int id)
          {
            //AdminViewModel areaitem = new AdminViewModel();
            if(DeliverySettingsManager.DeleteArea(id))
            {
                ViewData["Message"] = "Your data have been Deleted";
                //areaitem.areaList = perpageshowdataarea(1, 10);
                //areaitem.totalpage = pagecountarea(10);
                //areaitem.viewzone = DeliverySettingsManager.GetAllZone();
            }
            else
            {
                ViewData["Message"] = "Your data have not been Deleted";
                //areaitem.areaList = perpageshowdataarea(1, 10);
                //areaitem.totalpage = pagecountarea(10);
                //areaitem.viewzone = DeliverySettingsManager.GetAllZone();
            }
            AdminViewModel areaitem = new AdminViewModel();
            areaitem.areaList = perpageshowdataarea(1, 10);
            areaitem.totalpage = pagecountarea(10);
            areaitem.viewzone = DeliverySettingsManager.GetAllZone();
            return View("AddArea", areaitem);
        }
        // For Area Filter, Pagenation,Search etc
        public int pagecountarea(int perpagedata)
        {
            IEnumerable<Area> area = DeliverySettingsManager.GetAllArea();
            return Convert.ToInt32(Math.Ceiling(area.Count() / (double)perpagedata));
        }

        public List<Area> perpageshowdataarea(int pageindex, int pagesize)
        {
            IEnumerable<Area> area = DeliverySettingsManager.GetAllArea();
            return area.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }

        public JsonResult Getpaginatiotabledataarea(int pageindex, int pagesize)
        {
            AdminViewModel arealist = new AdminViewModel();
            arealist.areaList = perpageshowdataarea(pageindex, pagesize);
            arealist.totalpage = pagecountarea(pagesize);
            var result = JsonConvert.SerializeObject(arealist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult Searchdatarea(string serachvalue)
        //{
        //    List<Area> categorylist = DeliverySettingsManager.se(serachvalue);
        //    var result = JsonConvert.SerializeObject(categorylist);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
    }
}