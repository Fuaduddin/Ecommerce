﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Admin.Panel.Controllers
{
    public class AdminDashboardController : Controller
    {
        // GET: AdminDashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}