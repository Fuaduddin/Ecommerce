using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce.BusinessLayer;
using E_Commerce.Model;

namespace E_commerce.Web.Controllers
{
    public class indexController : Controller
    {
        // GET: index
        public ActionResult Index()
        {
            CustomerViewModel customer = new CustomerViewModel();
            customer.CategoryList = CategoryManager.GetAllCategory();
            customer.ProductList = ProductManager.GetAllProduct();
            customer.LetestProductList = E_commereceWebManager.GetLatestAllProduct();
            return View("Index", customer);
        }
        public ActionResult contact()
        {
            CustomerViewModel contact = new CustomerViewModel();
            contact.Email=new EmailModel();
            contact.Appointment=new AppointmentModel();
            return View("contact", contact);
        }
        [HttpPost]
        public ActionResult contact(EmailModel email)
        {
           email.SentDate= DateTime.Now;
           email.Updatemessage = 0;
           var sentemail= ContactManager.AddNewEmail(email);
          if(sentemail>0)
           {
                ModelState.Clear();
                ViewData["Message"] = "We will contact with you shortly";
           }
            return View();
        }
        [HttpPost]
        public ActionResult AddnewAppopintment(AppointmentModel appointment)
        {
            appointment.AppointDate =DateTime.Now;
            appointment.AssingedUpdate = 0;
            var sentemail = ContactManager.AddNewAppointment(appointment);
            if (sentemail > 0)
            {
                ModelState.Clear();
                ViewData["Message"] = "We will contact with you shortly";
            }
            return View("contact");
        }
    }
}