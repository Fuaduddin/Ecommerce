using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Admin.Panel.Controllers
{
    public class SuperAdminDashboardController : Controller
    {
        // GET: SuperAdminDashboard
        public ActionResult DashBoard()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("login", "login");
        }
    }
}