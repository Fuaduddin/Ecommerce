using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using E_Commerce.BusinessLayer;
using E_Commerce.Model;
using Newtonsoft.Json;

namespace E_Commerce.Admin.Panel.Controllers
{
    public class AdminDashboardController : Controller
    {
        // GET: AdminDashboard
        public ActionResult DashBoard()
        {
            var admindetails = Admindetails();
            var dashboarddetails = GetAdminDashBoardDetails(admindetails.AdminId);
            return View("DashBoard");
        }
        public ActionResult ViewAllCompleteAssignment()
        {
            AdminViewModel adminAllCompleteAssignmentlist = new AdminViewModel();
            var admindetails = Admindetails();
            adminAllCompleteAssignmentlist.AdminAssignmentList = GetAllAssingmentDetails(admindetails.AdminId, 1);
            return View("ViewAllCompleteAssignment", adminAllCompleteAssignmentlist);
        }
        public ActionResult ViewAllDueAssignment()
        {
            AdminViewModel adminAllCompleteAssignmentlist = new AdminViewModel();
            var admindetails = Admindetails();
            adminAllCompleteAssignmentlist.AdminAssignmentList = GetAllAssingmentDetails(admindetails.AdminId, 0);
            return View("ViewAllDueAssignment", adminAllCompleteAssignmentlist);
        }
        public ActionResult GetSingleAssignment(int id)
        {
            AdminViewModel adminAllCompleteAssignmentlist = new AdminViewModel();
            adminAllCompleteAssignmentlist.AdminAssignmentList = AssignmentManager.GetAllAssignmentAppointment();
            adminAllCompleteAssignmentlist.AdminAssignment = (AdminAssignmentModel)(adminAllCompleteAssignmentlist.AdminAssignmentList.Where(x => x.AssigentmentAppointmentId == id).ToList())[0];
            return View("UpdateAssignment", adminAllCompleteAssignmentlist);
        }
        public ActionResult UpdateAssignment()
        {
            return View("UpdateAssignment");
        }
        [HttpPost]
        public ActionResult UpdateAssignment(AdminAssignmentModel admin)
        {
            if (admin.AssigentmentUpdate == 0)
            {
                if (DashBoardManager.UpdateAdminAppointment(admin.AdminId, 0, admin.AssigentmentFixedDate))
                {
                    var MailBody = EMailBody(admin.CustomerName, admin.AppointmentSubject, admin.AdminName, admin.AssigentmentFixedDate.ToString("dd/mm/yyyy"));
                    if(SendingMail(MailBody,admin.CustomerEmail))
                    {
                        ViewData["Message"] = "Your data have  been Updated";
                    }
                    else
                    {
                        ViewData["Message"] = "Your data have not been Updated";
                    }
                }
             
            }
            else
            {

                if (DashBoardManager.UpdateAdminAppointment(admin.AdminId, 1, admin.AssigentmentFixedDate))
                {
                    ViewData["Message"] = "Your data have  been Updated";
                }
                else
                {
                    ViewData["Message"] = "Your data have not been Updated";
                }
            }
            return View("UpdateAssignment");
        }
        public JsonResult GetAssigmentDetails(int assignmentid)
        {
            AdminAssignmentModel AdminAssignment = new AdminAssignmentModel();
            AdminAssignment = AssignmentManager.GetSingleAssignmentAppointment(assignmentid);
            var result = JsonConvert.SerializeObject(AdminAssignment);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // Email Sent Code Start
        private bool SendingMail(string Emailbody,string CustomerEmail)
        {
            bool isSent = true;
            try
            {
                //Send Email
                MailMessage Msg = new MailMessage();
                Msg.From = new MailAddress("fuaduddinador@gmail.com", "Aranoz");// replace with valid value
                Msg.Subject = "Appointment has been confirmed";
                Msg.To.Add(CustomerEmail); //replace with correct values
                Msg.Body = Emailbody;
                Msg.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("fuaduddinador@gmail.com", "01644443221");// replace with valid value
                smtp.EnableSsl = true;
                smtp.Timeout = 20000;
                smtp.Send(Msg);
            }
            catch
            {
                isSent = false;
            }
            return isSent;
        }
        private List<AdminAssignmentModel> GetAllAssingmentDetails(int id, int update)
        {
            var adminassingmentlist = AssignmentManager.GetAllAssignmentAppointment();
           return adminassingmentlist.Where(x => x.AdminId == id && x.AssingedUpdate == update).ToList();
        }
        private AdminModel Admindetails()
        {
            AdminModel admin = new AdminModel();
            if (Session["AdminDetails"] != null)
            {
                admin = (AdminModel)Session["AdminDetails"];
            }
            return admin;
        }
        private string EMailBody(string CustomerName,string AppointmentSubject,string AppoinmentWIth,string AppointmentDate)
        {
            string Emailbody = "";
            return  Emailbody = "Hi Mr/Mrs"+ CustomerName+"Your Appointment Subject:"+AppointmentSubject+
                "has been confirmed with"+ AppoinmentWIth+"on"+AppointmentDate;
            
        }
        private DashBoardModel GetAdminDashBoardDetails(int id)
        {
            DashBoardModel dashboard = new DashBoardModel();
            if (id > 0)
            {

            }
            return dashboard;
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("login", "login");
        }
    }
}