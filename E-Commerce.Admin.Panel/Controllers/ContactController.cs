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
   // [Authorize]
    public class ContactController : Controller
    {
        // GET: Contact
        // Email
        public ActionResult ViewAllEmail()
        {
            AdminViewModel email= new AdminViewModel();
            email.EmailList = perpageshowdata(1, 10);
            email.totalpage = pagecount(10);
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
        public int pagecount(int perpagedata)
        {
            IEnumerable<EmailModel> EmailList = ContactManager.GetAllEmail();
            return Convert.ToInt32(Math.Ceiling(EmailList.Count() / (double)perpagedata));
        }
        public List<EmailModel> perpageshowdata(int pageindex, int pagesize)
        {
            IEnumerable<EmailModel> EmailList = ContactManager.GetAllEmail();
            return EmailList.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        public JsonResult Getpaginatiotabledata(int pageindex, int pagesize)
        {
            AdminViewModel EmailList = new AdminViewModel();
            EmailList.EmailList = perpageshowdata(pageindex, pagesize);
            EmailList.totalpage = pagecount(pagesize);
            var EmailListitem = JsonConvert.SerializeObject(EmailList);
            return Json(EmailListitem, JsonRequestBehavior.AllowGet);
        }
       
        // Appointment
        public ActionResult ViewAllAppointment()
        {
            AdminViewModel AppointmentList = new AdminViewModel();
            AppointmentList.AppointmentList = perpageshowdataAppointment(1, 10);
            AppointmentList.totalpage = pagecount(10);
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
        //public JsonResult SearchAppointment(string SearchKeyword)
        //{
        //    List<AppointmentModel> emaillistitem = new List<AppointmentModel>();
        //    emaillistitem = ContactManager.SearchEmail(SearchKeyword);
        //    var result = JsonConvert.SerializeObject(emaillistitem);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult Filtermail(int SearchKeyword)
        //{
        //    List<EmailModel> emaillist = new List<EmailModel>();
        //    emaillist = ContactManager.FilterEmail(SearchKeyword);
        //    var result = JsonConvert.SerializeObject(emaillist);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
        public int pagecountAppointment(int perpagedata)
        {
            IEnumerable<AppointmentModel> AppointmentList = ContactManager.GetAllAppointment();
            return Convert.ToInt32(Math.Ceiling(AppointmentList.Count() / (double)perpagedata));
        }
        public List<AppointmentModel> perpageshowdataAppointment(int pageindex, int pagesize)
        {
            IEnumerable<AppointmentModel> AppointmentList = ContactManager.GetAllAppointment();
            return AppointmentList.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        public JsonResult GetpaginatiotabledataAppointment(int pageindex, int pagesize)
        {
            AdminViewModel AppointmentList = new AdminViewModel();
            AppointmentList.EmailList = perpageshowdata(pageindex, pagesize);
            AppointmentList.totalpage = pagecount(pagesize);
            var AppointmentListitem = JsonConvert.SerializeObject(AppointmentList);
            return Json(AppointmentListitem, JsonRequestBehavior.AllowGet);
        }
        // Review
        public ActionResult ViewAllReview()
        {
            AdminViewModel review = new AdminViewModel();
            review.totalpage = pagecountReview(10);
            review.ReviewList = perpageshowdataReview(1,10);
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
        public int pagecountReview(int perpagedata)
        {
            IEnumerable<ReviewModel> AppointmentList = ContactManager.GetAllReview();
            return Convert.ToInt32(Math.Ceiling(AppointmentList.Count() / (double)perpagedata));
        }
        public List<ReviewModel> perpageshowdataReview(int pageindex, int pagesize)
        {
            IEnumerable<ReviewModel> AppointmentList = ContactManager.GetAllReview();
            return AppointmentList.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        public JsonResult GetpaginatiotabledataReview(int pageindex, int pagesize)
        {
            AdminViewModel AppointmentList = new AdminViewModel();
            AppointmentList.ReviewList = perpageshowdataReview(pageindex, pagesize);
            AppointmentList.totalpage = pagecountReview(pagesize);
            var AppointmentListitem = JsonConvert.SerializeObject(AppointmentList);
            return Json(AppointmentListitem, JsonRequestBehavior.AllowGet);
        }
    }
}