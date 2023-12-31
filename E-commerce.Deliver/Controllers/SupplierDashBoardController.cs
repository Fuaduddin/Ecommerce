﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce.BusinessLayer;
using E_Commerce.Model;
using Newtonsoft.Json;


namespace E_commerce.Deliver.Controllers
{
    [Authorize]
    public class SupplierDashBoardController : Controller
    {
        // GET: SupplierDashBoard
        public ActionResult DashBoard()
        {
            var supplier = GetSupplierDetails();
            SupplierandDeliveryManViewModel supplierdetails = new SupplierandDeliveryManViewModel();
            supplierdetails.dashboarddetails = UserDashboardDetails(supplier.SupplierId);
            supplierdetails.totalpage = pagecountSupplierDueAssng(10, supplier.SupplierId);
            supplierdetails.ViewSupplierAssignmentList = perpageshowdataSupplierDueAssng(1,10, supplier.SupplierId);
            return View("DashBoard", supplierdetails);
        }
        public ActionResult ViewAssignmentAssginment()
        {
            var supplier = GetSupplierDetails();
            SupplierandDeliveryManViewModel supplierdetails = new SupplierandDeliveryManViewModel();
            supplierdetails.totalpage = pagecountSupplierCompleteAssng(10, supplier.SupplierId);
            supplierdetails.ViewSupplierAssignmentList = perpageshowdataSupplierCompleteAssng(1, 10, supplier.SupplierId);
            return View("ViewAssignmentAssginment", supplierdetails);
        }
        public ActionResult GetSingleAssignment(int id)
        {
            SupplierandDeliveryManViewModel assignment = new SupplierandDeliveryManViewModel();
            assignment.UpdateAssignment = DashBoardManager.GetSingleSupplierAssing(id);
            return View("UpdateAssignment", assignment);
        }
        public ActionResult AssignmentCompleteConfirmation(int id)
        {
            if(id>0)
            {
                if (UpdateProductQuantity(id))
                {
                    var AssignmentDetails = DashBoardManager.GetSingleSupplierAssing(id);
                    AssignmentDetails.AssignmentUpdate = 1;
                    if(DashBoardManager.UpdateSupplierAssing(AssignmentDetails.AssigentmentSupplierId, 1, AssignmentDetails.AssignmentTotalCost))
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
                    ViewData["Message"] = "Your data have not been Updated";
                }
            }
            var supplier = GetSupplierDetails();
            SupplierandDeliveryManViewModel supplierdetails = new SupplierandDeliveryManViewModel();
            supplierdetails.dashboarddetails = UserDashboardDetails(supplier.SupplierId);
            supplierdetails.totalpage = pagecountSupplierDueAssng(10, supplier.SupplierId);
            supplierdetails.ViewSupplierAssignmentList = perpageshowdataSupplierDueAssng(1, 10, supplier.SupplierId);
            return View("DashBoard", supplierdetails);
        }
        [HttpPost]
        public ActionResult UpdateAssignment(SupplierandDeliveryManViewModel assignment)
        {
            if (assignment.UpdateAssignment.AssignmentUpdate == 0)
            {
                if (DashBoardManager.UpdateSupplierAssing(assignment.UpdateAssignment.AssigentmentSupplierId, 0, assignment.UpdateAssignment.AssignmentTotalCost))
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
            if (UpdateAssignment.AssignmentUpdate == 0)
            {
                if (DashBoardManager.UpdateSupplierAssing(id, 3, 0))
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
        private SupplierModel GetSupplierDetails()
        {
            return (SupplierModel)Session["SupplierDetails"];
        }
        private DashBoardModel UserDashboardDetails(int SupplierID)
        {
            DashBoardModel dashboard = new DashBoardModel();
            dashboard.TotalSupplierAssignment = DashBoardManager.GettotalCompleteAssing(SupplierID);
            dashboard.TotalDueAssignment = DashBoardManager.GettotalDueAssing(SupplierID);
            dashboard.TotalCompleteAssignment = DashBoardManager.GettotalAssignAssing(SupplierID);
            return dashboard;
        } 
        private bool UpdateProductQuantity(int AssignmentID)
        {
            bool updated = true;
            try
            {
                var AssignmentDetails = DashBoardManager.GetSingleSupplierAssing(AssignmentID);
                var productdetails = ProductManager.GetSingleProduct(AssignmentDetails.ProductId);
                productdetails.ProductQuantity = productdetails.ProductQuantity + AssignmentDetails.ProductQuantity;
            }
            catch (Exception ex)
            {
                updated=false;
            }
            return updated;
        }
        public int pagecountSupplierDueAssng(int perpagedata, int SupllierID)
        {
            IEnumerable<ViewSupplierAssignmentModel> AppointmentList = DashBoardManager.ViewAssignmentAssginment(SupllierID);
            return Convert.ToInt32(Math.Ceiling(AppointmentList.Count() / (double)perpagedata));
        }
        public List<ViewSupplierAssignmentModel> perpageshowdataSupplierDueAssng(int pageindex, int pagesize,int SupllierID)
        {
            IEnumerable<ViewSupplierAssignmentModel> AppointmentList = DashBoardManager.ViewAssignmentAssginment(SupllierID);
            return AppointmentList.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        public JsonResult GetpaginatiotabledataSupplierDueAssng(int pageindex, int pagesize)
        {
            AdminViewModel AppointmentList = new AdminViewModel();
            var SupplierDetails = GetSupplierDetails();
            AppointmentList.ViewSupplierAssignmentList = perpageshowdataSupplierDueAssng(pageindex, pagesize, SupplierDetails.SupplierId);
            AppointmentList.totalpage = pagecountSupplierDueAssng(pagesize, SupplierDetails.SupplierId);
            var AppointmentListitem = JsonConvert.SerializeObject(AppointmentList);
            return Json(AppointmentListitem, JsonRequestBehavior.AllowGet);
        }
        public int pagecountSupplierCompleteAssng(int perpagedata, int SupllierID)
        {
            IEnumerable<ViewSupplierAssignmentModel> AppointmentList = DashBoardManager.ViewAssignmentAssginment(SupllierID);
            return Convert.ToInt32(Math.Ceiling(AppointmentList.Count() / (double)perpagedata));
        }
        public List<ViewSupplierAssignmentModel> perpageshowdataSupplierCompleteAssng(int pageindex, int pagesize, int SupllierID)
        {
            IEnumerable<ViewSupplierAssignmentModel> AppointmentList = DashBoardManager.ViewAssignmentAssginment(SupllierID);
            return AppointmentList.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        public JsonResult GetpaginatiotabledataCompleteAssng(int pageindex, int pagesize)
        {
            AdminViewModel AppointmentList = new AdminViewModel();
            var SupplierDetails = GetSupplierDetails();
            AppointmentList.ViewSupplierAssignmentList = perpageshowdataSupplierCompleteAssng(pageindex, pagesize, SupplierDetails.SupplierId);
            AppointmentList.totalpage = pagecountSupplierCompleteAssng(pagesize, SupplierDetails.SupplierId);
            var AppointmentListitem = JsonConvert.SerializeObject(AppointmentList);
            return Json(AppointmentListitem, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchdataSupplierDueAssignm(string serachvalue)
        {
            var SupplierDetails = GetSupplierDetails();
            List<ViewSupplierAssignmentModel> Assignmentlist = DashBoardManager.ViewAssignmentAssginment(SupplierDetails.SupplierId);
            var filterresult = Assignmentlist.Where(x => x.AssignmentUpdate == 0);
            var searchresult = filterresult.Select(x => x.AssignmentOfficialID.Contains(serachvalue)).ToList();
            var result = JsonConvert.SerializeObject(searchresult);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchdataSupplierCompleteAssignm(string serachvalue)
        {
            var SupplierDetails = GetSupplierDetails();
            List<ViewSupplierAssignmentModel> Assignmentlist = DashBoardManager.ViewAssignmentAssginment(SupplierDetails.SupplierId);
            var filterresult = Assignmentlist.Where(x => x.AssignmentUpdate == 1);
            var searchresult = filterresult.Select(x => x.AssignmentOfficialID.Contains(serachvalue)).ToList();
            var result = JsonConvert.SerializeObject(searchresult);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}