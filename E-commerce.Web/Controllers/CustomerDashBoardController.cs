using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce.BusinessLayer;
using E_Commerce.Model;
using Newtonsoft.Json;

namespace E_commerce.Web.Controllers
{
    public class CustomerDashBoardController : Controller
    {
        // GET: CustomerDashBoard
        public ActionResult DashBoard()
        {
            CustomerModel customer =(CustomerModel) Session["CustomerDetails"];
            //SupplierModel supplier = (SupplierModel)Session["SupplierDetails"];
            //SupplierandDeliveryManViewModel supplierdetails = new SupplierandDeliveryManViewModel();
            //supplierdetails.TotalCompleteAssng = DashBoardManager.GettotalCompleteAssing(supplier.SupplierId);
            //supplierdetails.DueAssng = DashBoardManager.GettotalDueAssing(supplier.SupplierId);
            //supplierdetails.TotalAssng = DashBoardManager.GettotalAssignAssing(supplier.SupplierId);
            //return View("DashBoard", supplierdetails);
            return View("DashBoard");
        }
        public ActionResult ViewRecentOrderDetails()
        {
            //SupplierModel supplier = (SupplierModel)Session["SupplierDetails"];
            //SupplierandDeliveryManViewModel supplierdetails = new SupplierandDeliveryManViewModel();
            //supplierdetails.ViewSupplierAssignmentList = DashBoardManager.ViewAssignmentAssginment(supplier.SupplierId);
            //return View("ViewAssignmentAssginment", supplierdetails);
            return View();
        }
        public ActionResult ViewAllOrder()
        {
            //SupplierModel supplier = (SupplierModel)Session["SupplierDetails"];
            //SupplierandDeliveryManViewModel supplierdetails = new SupplierandDeliveryManViewModel();
            //supplierdetails.ViewSupplierAssignmentList = DashBoardManager.ViewAllCompleteAssignment(supplier.SupplierId);
            //return View("ViewAllCompleteAssignment", supplierdetails);
            return View();

        }
        public ActionResult ViewAllRecentOrder()
        {
            //SupplierModel supplier = (SupplierModel)Session["SupplierDetails"];
            //SupplierandDeliveryManViewModel supplierdetails = new SupplierandDeliveryManViewModel();
            //supplierdetails.ViewSupplierAssignmentList = DashBoardManager.ViewAllCompleteAssignment(supplier.SupplierId);
            //return View("ViewAllCompleteAssignment", supplierdetails);
            return View();

        }
        public ActionResult GetSingleOrderDeails(int id)
        {
            //SupplierandDeliveryManViewModel assignment = new SupplierandDeliveryManViewModel();
            //assignment.UpdateAssignment = DashBoardManager.GetSingleSupplierAssing(id);
            //return View("UpdateAssignment", assignment);
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("login", "login");
        }

        // Common For Every Indivual Customer

        private DashBoardModel UserDashboardDetails(int CustomerID)
        {
            DashBoardModel dashboard = new DashBoardModel();

            return dashboard;
        }




        }
    }

