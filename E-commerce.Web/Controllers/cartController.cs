using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce.Web.Controllers
{
    public class cartController : Controller
    {
        // GET: cart
        public ActionResult cart()
        {
            return View();
        }
        public ActionResult confirmation()
        {
            return View();
        }
    }
}