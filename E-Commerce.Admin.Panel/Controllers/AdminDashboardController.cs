using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using E_Commerce.BusinessLayer;
using E_Commerce.Model;
using Newtonsoft.Json;
using E_Commerce.Admin.Panel.GlobalDashBoardSettings;

namespace E_Commerce.Admin.Panel.Controllers
{
    [Authorize]
    public class AdminDashboardController : Controller
    {
        // GET: AdminDashboard
        public ActionResult DashBoard()
        {
            AdminViewModel DashBoard= new AdminViewModel();
            DashBoard.DashBoard = GlobalDashBoardSettingsModel.DashboardInformation();
            DashBoard.DashBoard.Common = GetAdminDashBoardDetails();
            return View("DashBoard");
        }
        public ActionResult ViewAllCompleteAssignment()
        {
            AdminViewModel adminAllCompleteAssignmentlist = new AdminViewModel();
            adminAllCompleteAssignmentlist.AdminAssignmentList = perpageshowdataAdminCompleteAssng(1,10);
            adminAllCompleteAssignmentlist.totalpage = pagecountAdminCompleteAssng(10);
            return View("ViewAllCompleteAssignment", adminAllCompleteAssignmentlist);
        }
        public ActionResult ViewAllDueAssignment()
        {
            AdminViewModel adminAllCompleteAssignmentlist = new AdminViewModel();
            adminAllCompleteAssignmentlist.AdminAssignmentList = perpageshowdataAdminDueAssng(1, 10);
            adminAllCompleteAssignmentlist.totalpage = pagecountAdminDueAssng(10);
            return View("ViewAllDueAssignment", adminAllCompleteAssignmentlist);
        }
        public ActionResult GetSingleAssignment(int id)
        {
            AdminViewModel adminAllCompleteAssignmentlist = new AdminViewModel();
            adminAllCompleteAssignmentlist.AdminAssignmentList = AssignmentManager.GetAllAssignmentAppointment();
            adminAllCompleteAssignmentlist.AdminAssignment = (AdminAssignmentModel)(adminAllCompleteAssignmentlist.AdminAssignmentList.Where(x => x.AssigentmentAppointmentId == id).ToList())[0];
            return View("UpdateAssignment", adminAllCompleteAssignmentlist);
        }
        public ActionResult UpdateAssignment(int id)
        {
            if(id>0)
            {
                var AssignmentDetails=AssignmentManager.GetSingleAssignmentAppointment(id);
                if(DashBoardManager.UpdateAdminAppointment(AssignmentDetails.AdminId, 1, AssignmentDetails.AssigentmentFixedDate))
                {
                    ViewData["Message"] = "Your data have been Updated";
                }
                else
                {
                    ViewData["Message"] = "!!!! Error !!!!!!";
                }
            }
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
        public ActionResult MultieDeleteAssignment(int[] multidelete)
        {
            int i = 0;
            if (multidelete.Count()> 0)
            {
                
                var Assignemnts = AssignmentManager.GetAllAssignmentAppointment();
                foreach (int id in multidelete)
                {
                    var Assignmentdetails= (AdminAssignmentModel)(Assignemnts.Where(x => x.AssigentmentAppointmentId == id).ToList())[0];
                    DashBoardManager.UpdateAdminAppointment(Assignmentdetails.AdminId, 2, Assignmentdetails.AssigentmentFixedDate);
                    i++;
                }
            }
            if(multidelete.Count()==i)
            {
                ViewData["Message"] = "Your data have  been Updated";
            }
            else
            {
                ViewData["Message"] = "Your data have  not been Updated";
            }
            return View("ViewAllDueAssignment");
        }
        public JsonResult GetAssigmentDetails(int assignmentid)
        {
            AdminAssignmentModel AdminAssignment = new AdminAssignmentModel();
            AdminAssignment = AssignmentManager.GetSingleAssignmentAppointment(assignmentid);
            var result = JsonConvert.SerializeObject(AdminAssignment);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("login", "login");
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
        private List<AdminAssignmentModel> GetAllAssingmentDetails(int update)
        {
            var admindetails = Admindetails();
            var adminassingmentlist = AssignmentManager.GetAllAssignmentAppointment();
           return adminassingmentlist.Where(x => x.AdminId == admindetails.AdminId && x.AssingedUpdate == update).ToList();
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
        private string EMailBody(string CustomerName, string AppointmentSubject, string AppoinmentWIth, string AppointmentDate)
        {
            string Emailbody = "";
            return Emailbody = "Hi Mr/Mrs" + CustomerName + "Your Appointment Subject:" + AppointmentSubject +
                "has been confirmed with" + AppoinmentWIth + "on" + AppointmentDate;

        }
        private CommonDashBoardModel GetAdminDashBoardDetails()
        {
            var admindetails = Admindetails();
            var AppointmentList = AssignmentManager.GetAllAssignmentAppointment();
            return new CommonDashBoardModel()
            {
                TotalAssignment = AppointmentList.Select(x => x.AdminId == admindetails.AdminId).Count(),
                TotalCompleteAssignment = AppointmentList.Select(x => x.AdminId == admindetails.AdminId && x.AssigentmentUpdate == 1).Count(),
                TotalDueAssignment = AppointmentList.Select(x => x.AdminId == admindetails.AdminId && x.AssigentmentUpdate == 0).Count()
            };
        }


        // Other Feauture
        public int pagecountAdminDueAssng(int perpagedata)
        {
            var AdminDetails = Admindetails();
            var assigenments = AssignmentManager.GetAllAssignmentAppointment();
            List<AdminAssignmentModel> AppointmentList = assigenments.Where(x => x.AdminId == AdminDetails.AdminId && x.AssigentmentUpdate == 0).ToList();
            return Convert.ToInt32(Math.Ceiling(AppointmentList.Count() / (double)perpagedata));
        }
        public List<AdminAssignmentModel> perpageshowdataAdminDueAssng(int pageindex, int pagesize)
        {
            var AdminDetails = Admindetails();
            var assigenments = AssignmentManager.GetAllAssignmentAppointment();
            List<AdminAssignmentModel> AppointmentList = assigenments.Where(x => x.AdminId == AdminDetails.AdminId && x.AssigentmentUpdate == 0).ToList();
            return AppointmentList.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        public JsonResult GetpaginatiotabledataAdminDueAssng(int pageindex, int pagesize)
        {
            AdminViewModel AppointmentList = new AdminViewModel();
            AppointmentList.AdminAssignmentList = perpageshowdataAdminDueAssng(pageindex, pagesize);
            AppointmentList.totalpage = pagecountAdminDueAssng(pagesize);
            var AppointmentListitem = JsonConvert.SerializeObject(AppointmentList);
            return Json(AppointmentListitem, JsonRequestBehavior.AllowGet);
        }
        public int pagecountAdminCompleteAssng(int perpagedata)
        {
            var AdminDetails = Admindetails();
            var assigenments = AssignmentManager.GetAllAssignmentAppointment();
            List<AdminAssignmentModel> AppointmentList = assigenments.Where(x => x.AdminId == AdminDetails.AdminId && x.AssigentmentUpdate == 1).ToList();
            return Convert.ToInt32(Math.Ceiling(AppointmentList.Count() / (double)perpagedata));
        }
        public List<AdminAssignmentModel> perpageshowdataAdminCompleteAssng(int pageindex, int pagesize)
        {
            var AdminDetails = Admindetails();
            var assigenments = AssignmentManager.GetAllAssignmentAppointment();
            List<AdminAssignmentModel> AppointmentList = assigenments.Where(x => x.AdminId == AdminDetails.AdminId && x.AssigentmentUpdate == 0).ToList();
            return AppointmentList.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        public JsonResult GetpaginatiotabledataCompleteAssng(int pageindex, int pagesize)
        {
            AdminViewModel AppointmentList = new AdminViewModel();
            AppointmentList.AdminAssignmentList = perpageshowdataAdminCompleteAssng(pageindex, pagesize);
            AppointmentList.totalpage = pagecountAdminCompleteAssng(pagesize);
            var AppointmentListitem = JsonConvert.SerializeObject(AppointmentList);
            return Json(AppointmentListitem, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchdataAdminDueAssignm(string serachvalue)
        {
            var AdminDetails = Admindetails();
            var assigenments = AssignmentManager.GetAllAssignmentAppointment();
            List<AdminAssignmentModel> AppointmentList = assigenments.Where(x => x.AdminId == AdminDetails.AdminId && x.AssigentmentUpdate == 0).ToList();
            var filterresult = AppointmentList.Where(x => x.AssigentmentUpdate == 0);
            var searchresult = filterresult.Select(x => x.CustomerName.Contains(serachvalue) || x.CustomerEmail.Contains(serachvalue) || x.CustomerPhoneNumber.Contains(serachvalue)).ToList();
            var result = JsonConvert.SerializeObject(searchresult);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchdataAdminCompleteAssignm(string serachvalue)
        {
            var AdminDetails = Admindetails();
            var assigenments = AssignmentManager.GetAllAssignmentAppointment();
            List<AdminAssignmentModel> AppointmentList = assigenments.Where(x => x.AdminId == AdminDetails.AdminId && x.AssigentmentUpdate == 0).ToList();
            var filterresult = AppointmentList.Where(x => x.AssigentmentUpdate == 1);
            var searchresult = filterresult.Select(x => x.CustomerName.Contains(serachvalue) || x.CustomerEmail.Contains(serachvalue) || x.CustomerPhoneNumber.Contains(serachvalue)).ToList();
            var result = JsonConvert.SerializeObject(searchresult);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}