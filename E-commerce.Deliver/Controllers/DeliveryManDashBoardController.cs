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
    [Authorize]
    public class DeliveryManDashBoardController : Controller
    {
        // GET: DeliveryManDashBoard
        public ActionResult DashBoard()
        {
            var deliveryman = GetCustomerDetails();
            var assigenments = AssignmentManager.GetAllAssignmentDeliveryMan();
            SupplierandDeliveryManViewModel deliverymandetails = new SupplierandDeliveryManViewModel();
            deliverymandetails.Commondashboarddetails = DashBoardDetails(deliveryman.DeliverManId);
            deliverymandetails.DeliverymanAssignmentList = assigenments.Where(x=>x.DeliveryManeID==deliveryman.DeliverManId && x.AssigentmentUpdate==0).ToList();
            return View("DashBoard");
        }
        public ActionResult ViewAllAssignment()
        {
            var deliveryman = GetCustomerDetails();
            var assigenments = AssignmentManager.GetAllAssignmentDeliveryMan();
            SupplierandDeliveryManViewModel deliverymandetails = new SupplierandDeliveryManViewModel();
            deliverymandetails.DeliverymanAssignmentList = assigenments.Where(x => x.DeliveryManeID == deliveryman.DeliverManId).ToList();
            return View("DashBoard");
        }
        public ActionResult ViewAllCompleteAssignment()
        {
            var deliveryman = GetCustomerDetails();
            var assigenments = AssignmentManager.GetAllAssignmentDeliveryMan();
            SupplierandDeliveryManViewModel deliverymandetails = new SupplierandDeliveryManViewModel();
            deliverymandetails.DeliverymanAssignmentList = assigenments.Where(x => x.DeliveryManeID == deliveryman.DeliverManId && x.AssigentmentUpdate == 1).ToList();
            return View("DashBoard");
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("login", "login");
        }
        private CommonDashBoardModel DashBoardDetails(int DeliveryManID)
        {
            var AssignmentDelivery = AssignmentManager.GetAllAssignmentDeliveryMan();
            return new CommonDashBoardModel()
            {
                TotalDueAssignment = AssignmentDelivery.Select(x => x.DeliveryManeID == DeliveryManID && x.AssigentmentUpdate == 0).Count(),
                TotalCompleteAssignment = AssignmentDelivery.Select(x => x.DeliveryManeID == DeliveryManID && x.AssigentmentUpdate == 1).Count(),
                TotalAssignment = AssignmentDelivery.Select(x => x.DeliveryManeID == DeliveryManID).Count()
            };
        }
        private DeliveryManModel GetCustomerDetails()
        {
            return (DeliveryManModel)Session["DeliveryManDetails"];
        }
    }
}