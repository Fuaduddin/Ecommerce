using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce.BusinessLayer;
using E_Commerce.Model;
using Newtonsoft.Json;


namespace E_commerce.Deliver.Controllers
{
    public class SupplierDashBoardController : Controller
    {
        // GET: SupplierDashBoard
        public ActionResult DashBoard()
        {
            SupplierModel supplier =(SupplierModel)Session["SupplierDetails"];
            SupplierandDeliveryManViewModel supplierdetails = new SupplierandDeliveryManViewModel();
            supplierdetails.dashboarddetails.TotalCompleteAssignment = DashBoardManager.GettotalCompleteAssing(supplier.SupplierId);
            supplierdetails.dashboarddetails.TotalDueAssignment = DashBoardManager.GettotalDueAssing(supplier.SupplierId);
            supplierdetails.dashboarddetails.TotalAssignment = DashBoardManager.GettotalAssignAssing(supplier.SupplierId);
            return View("DashBoard", supplierdetails);
        }
        public ActionResult ViewAssignmentAssginment()
        {
            SupplierModel supplier = (SupplierModel)Session["SupplierDetails"];
            SupplierandDeliveryManViewModel supplierdetails = new SupplierandDeliveryManViewModel();
            supplierdetails.ViewSupplierAssignmentList = DashBoardManager.ViewAssignmentAssginment(supplier.SupplierId);
            return View("ViewAssignmentAssginment", supplierdetails);
        }
        public ActionResult ViewAllCompleteAssignment()
        {
            SupplierModel supplier = (SupplierModel)Session["SupplierDetails"];
            SupplierandDeliveryManViewModel supplierdetails = new SupplierandDeliveryManViewModel();
            supplierdetails.ViewSupplierAssignmentList = DashBoardManager.ViewAllCompleteAssignment(supplier.SupplierId);
            return View("ViewAllCompleteAssignment", supplierdetails);
        }
        public ActionResult GetSingleAssignment(int id)
        {
            SupplierandDeliveryManViewModel assignment = new SupplierandDeliveryManViewModel();
            assignment.UpdateAssignment = DashBoardManager.GetSingleSupplierAssing(id);
            return View("UpdateAssignment", assignment);
        }
        public ActionResult UpdateAssignment()
        {
            
            return View("UpdateAssignment");
        }
        [HttpPost]
        public ActionResult UpdateAssignment(SupplierandDeliveryManViewModel assignment)
        {
            if(assignment.UpdateAssignment.AssignmentUpdate==0)
            {
                if (DashBoardManager.UpdateSupplierAssing(assignment.UpdateAssignment.AssigentmentSupplierId,0, assignment.UpdateAssignment.AssignmentTotalCost))
                {
                    ViewData["Message"] = "Your data have  been Updated";
                }
                else
                {
                    ViewData["Message"] = "Your data have not been Updated";
                }
            }
            else
            {
 
                if (DashBoardManager.UpdateSupplierAssing(assignment.UpdateAssignment.AssigentmentSupplierId, 1, assignment.UpdateAssignment.AssignmentTotalCost))
                {
                    ViewData["Message"] = "Your data have  been Updated";
                }
                else
                {
                    ViewData["Message"] = "Your data have not been Updated";
                }
            }
            return View("UpdateAssignment", assignment);
        }
        public ActionResult CancleAssignment(int id)
        {
           var UpdateAssignment = DashBoardManager.GetSingleSupplierAssing(id);
            if(UpdateAssignment.AssignmentUpdate == 0)
            {
                if (DashBoardManager.UpdateSupplierAssing(id, 3,0))
                {
                    ViewData["Message"] = "Your data have  been Updated";
                }
                else
                {
                    ViewData["Message"] = "You Cannot Cancel This Assignment";
                }
            }
            else
            {
                ViewData["Message"] = "You Cannot Cancel This Assignment";
            }
            return View("ViewAssignmentAssginment");
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("login", "login");
        }
    }
}