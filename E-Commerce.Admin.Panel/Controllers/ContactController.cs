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
    public class ContactController : Controller
    {
        // GET: Contact
        // Email
        public ActionResult ViewAllEmail()
        {
            AdminViewModel email= new AdminViewModel();
            email.EmailList = ContactManager.GetAllEmail();
            return View("ViewAllEmail",email);
        }
        public ActionResult DeleteEmail(int id)
        {
            AdminViewModel email = new AdminViewModel();
            if(ContactManager.DeleteEmail(id))
            {
                ViewData["Message"] = "Your data have been deleted";
            }
            else
            {
                ViewData["Message"] = "Your data not have  been deleted";
            }
            email.EmailList = ContactManager.GetAllEmail();
            return View("ViewAllEmail", email);
        }
        public ActionResult MultieDeleteEmail(int [] multidelete)
        {
            AdminViewModel email = new AdminViewModel();
            int i = 0;
            if (multidelete != null && multidelete.Length > 0)
            {
                foreach (int idItem in multidelete)
                {
                    ContactManager.DeleteEmail(idItem);
                    i++;
                }
            }
            if(multidelete.Length==i)
            {
                ViewData["Message"] = "Your data have been deleted";
            }
            else
            {
                ViewData["Message"] = "Your data not have  been deleted";
            }
            email.EmailList = ContactManager.GetAllEmail();
            return View("ViewAllEmail", email);
        }
        public JsonResult GetsingleEmail(int id)
        {
            int checkedid= 1;
            EmailModel email=new EmailModel();
            bool checkeditem = ContactManager.UpdateEmail(id, checkedid);
            if (checkeditem)
            {
                email = ContactManager.GetSingleEmail(id);  
            }
            var result = JsonConvert.SerializeObject(email);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchEmail(string SearchKeyword)
        {
            List<EmailModel> emaillistitem = new List<EmailModel>();
            emaillistitem = ContactManager.SearchEmail(SearchKeyword);
            var result = JsonConvert.SerializeObject(emaillistitem);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Filtermail(int SearchKeyword)
        {
            List<EmailModel> emaillist = new List<EmailModel>();
            emaillist = ContactManager.FilterEmail(SearchKeyword);
            var result = JsonConvert.SerializeObject(emaillist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // Appointment
        public ActionResult UpdateAppointment()
        {
            AdminViewModel AppointmentList = new AdminViewModel();
            AppointmentList.AppointmentList = ContactManager.GetAllAppointment();
            return View("ViewAllAppointment", AppointmentList);
        }
        public ActionResult ViewAllAppointment()
        {
            AdminViewModel AppointmentList = new AdminViewModel();
            AppointmentList.AppointmentList = ContactManager.GetAllAppointment();
            return View("ViewAllAppointment", AppointmentList);
        }
        public ActionResult DeleteAppointment(int id)
        {
            AdminViewModel AppointmentList = new AdminViewModel();
            if (ContactManager.DeleteAppointment(id))
            {
                ViewData["Message"] = "Your data have been deleted";
            }
            else
            {
                ViewData["Message"] = "Your data not have  been deleted";
            }
            AppointmentList.AppointmentList = ContactManager.GetAllAppointment();
            return View("ViewAllAppointment", AppointmentList);
        }
        public ActionResult GetsingleAppointment(int id)
        {
            AdminViewModel Appointment = new AdminViewModel();
            Appointment.Appointment = ContactManager.GetSingleAppointment(id);
           // Appointment.Admin=
            return View("UpdateAppointment", Appointment);
        }

        public JsonResult GetsingleAppointmentitem(int id)
        {
            int checkedid = 1;
            EmailModel email = new EmailModel();
            bool checkeditem = ContactManager.UpdateEmail(id, checkedid);
            if (checkeditem)
            {
                email = ContactManager.GetSingleEmail(id);
            }
            var result = JsonConvert.SerializeObject(email);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // Review
        public ActionResult ViewAllReview()
        {
            AdminViewModel review = new AdminViewModel();
            review.ReviewList = ContactManager.GetAllReview();
            return View("ViewAllReview", review);
        }
        public ActionResult DeleteReview(int id)
        {
            AdminViewModel review = new AdminViewModel();
            if (ContactManager.DeleteReview(id))
            {
                ViewData["Message"] = "Your data have been deleted";
            }
            else
            {
                ViewData["Message"] = "Your data not have  been deleted";
            }
            review.ReviewList = ContactManager.GetAllReview();
            return View("ViewAllEmail", review);
        }
    }
}