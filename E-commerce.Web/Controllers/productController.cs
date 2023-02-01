using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_commerce.Web.Controllers
{
    public class productController : Controller
    {
        // GET: product
        public ActionResult categoryproduct()
        {
            return View();
        }
        public ActionResult singleproduct()
        {
            return View();
        }
    }
}