using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce.BusinessLayer;
using E_Commerce.Model;
using Newtonsoft.Json;

namespace E_Commerce.Admin.Panel.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {

        // GET: Customer
        public ActionResult ViewAllCustomer()
        {
            AdminViewModel Customer = new AdminViewModel();
            Customer.CustomerList = perpageshowdataCustomer(1, 10);
            Customer.totalpage = pagecountCustomer(10);
            return View("ViewAllCustomer", Customer);
        }
        public ActionResult DeleteCustomer(int CustomerID, int userid)
        {
            if (CustomerID > 0 && userid>0)
            {
                if(UserSettingManager.DeleteUser(userid))
                {
                    if (CustomerManager.DeleteCustomer(CustomerID))
                    {
                        AdminViewModel Customer = new AdminViewModel();
                        Customer.CustomerList = CustomerManager.GetAllCustomer();
                        ViewData["Message"] = "Your data have been deleted";
                    }
                    else
                    {
                        ViewData["Message"] = "Error While Deleting your data";
                    }
                }
                else
                {
                    ViewData["Message"] = "Error While Deleting your data";
                }
            }
            return View("ViewAllCustomer");
        }

        public int pagecountCustomer(int perpagedata)
        {
            var assigenments = CustomerManager.GetAllCustomer();
            return Convert.ToInt32(Math.Ceiling(assigenments.Count() / (double)perpagedata));
        }
        public List<CustomerModel> perpageshowdataCustomer(int pageindex, int pagesize)
        {

            var assigenments = CustomerManager.GetAllCustomer();
            return assigenments.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        public JsonResult GetpaginatiotabledataCustomer(int pageindex, int pagesize)
        {
            AdminViewModel AppointmentList = new AdminViewModel();
            AppointmentList.CustomerList = perpageshowdataCustomer(pageindex, pagesize);
            AppointmentList.totalpage = pagecountCustomer(pagesize);
            var AppointmentListitem = JsonConvert.SerializeObject(AppointmentList);
            return Json(AppointmentListitem, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchdataCustomer(string serachvalue)
        {
            var assigenments = CustomerManager.GetAllCustomer();
            var searchresult = assigenments.Select(x => x.CustomerName.Contains(serachvalue) || x.UserName.Contains(serachvalue) || x.CustomerPhoneNumber.Contains(serachvalue)).ToList();
            var result = JsonConvert.SerializeObject(searchresult);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}