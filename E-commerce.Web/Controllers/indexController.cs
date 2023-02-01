using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce.Model;

namespace E_commerce.Web.Controllers
{
    public class indexController : Controller
    {
        // GET: index
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult contact( EmailModel email)
        {
            return View();
        }
    }
}