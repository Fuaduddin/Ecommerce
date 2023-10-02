using System;
using System.Collections.Generic;
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
            Customer.CustomerList = CustomerManager.GetAllCustomer();
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
    }
}