using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce.BusinessLayer;
using E_Commerce.Model;

namespace E_commerce.Web.Controllers
{
    public class loginController : Controller
    {
        // GET: login
        public ActionResult login()
        {
            return View();
        }
        public ActionResult registration()
        {
            CustomerViewModel customer = new CustomerViewModel();
            customer.Customer = new CustomerModel();
            return View(customer);
        }
        [HttpPost]
        public ActionResult registration(string division, string districts, CustomerModel customer, HttpPostedFileBase File)
        {
            return View();
        }
    }
}