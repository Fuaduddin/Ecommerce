﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Admin.Panel.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult ViewAllOrder()
        {
            return View();
        }
        public ActionResult CancleOrder()
        {
            return View();
        }
    }
}