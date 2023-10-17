using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce.Admin.Panel.GlobalDashBoardSettings;
using E_Commerce.Model;

namespace E_Commerce.Admin.Panel.Controllers
{
    [Authorize]
    public class SuperAdminDashboardController : Controller
    {
        
        // GET: SuperAdminDashboard
        public ActionResult DashBoard()
        {
            AdminViewModel DashBoard = new AdminViewModel();
            DashBoard.DashBoard = GlobalDashBoardSettingsModel.DashboardInformation();
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("login", "login");
        }
    }
}