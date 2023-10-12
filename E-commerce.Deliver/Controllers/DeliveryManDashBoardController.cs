using System;
using System.Collections.Generic;
using System.Drawing.Printing;
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
            deliverymandetails.DeliverymanAssignmentList = perpageshowdataDeliveryManDueAssng(1,10, deliveryman.DeliverManId);
            deliverymandetails.totalpage = pagecountDeliveryManDueAssng(10, deliveryman.DeliverManId);
            return View("DashBoard", deliverymandetails);
        }
        public ActionResult ViewAllAssignment()
        {
            var deliveryman = GetCustomerDetails();
            SupplierandDeliveryManViewModel deliverymandetails = new SupplierandDeliveryManViewModel();
            deliverymandetails.Commondashboarddetails = DashBoardDetails(deliveryman.DeliverManId);
            deliverymandetails.DeliverymanAssignmentList = perpageshowdataDeliveryManCompleteAssng(1, 10, deliveryman.DeliverManId);
            deliverymandetails.totalpage = pagecountDeliveryManCompleteAssng(10, deliveryman.DeliverManId);
            return View("ViewAllAssignment");
        }
        public ActionResult UpdateAssignment(int id)
        {
            if(id>0)
            {
                if (GetCartFullDetailsUpdate(id))
                {
                    ViewData["Message"] = "Your data have  been Updated";
                }
                else
                {
                    ViewData["Message"] = "Your data have not been Updated";
                }
            }
            var deliveryman = GetCustomerDetails();
            var assigenments = AssignmentManager.GetAllAssignmentDeliveryMan();
            SupplierandDeliveryManViewModel deliverymandetails = new SupplierandDeliveryManViewModel();
            deliverymandetails.Commondashboarddetails = DashBoardDetails(deliveryman.DeliverManId);
            deliverymandetails.DeliverymanAssignmentList = perpageshowdataDeliveryManDueAssng(1, 10, deliveryman.DeliverManId);
            deliverymandetails.totalpage = pagecountDeliveryManDueAssng(10, deliveryman.DeliverManId);
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
        private bool GetCartFullDetailsUpdate(int id)
        {
            bool Updated = true;
            var AssignmentDelivery = AssignmentManager.GetAllAssignmentDeliveryMan();
            try
            {
                SupplierandDeliveryManViewModel Cart = new SupplierandDeliveryManViewModel();
                Cart.CartDetails= OrderDetails(id);
                Cart.CartDetails.Order.OrderDeliveryUpdate =1 ;
                Cart.CartDetails.Payment.OrderPaymentDate = DateTime.Now ;
                // Cart.CartDetails.Payment.o =;
                Cart.CartDetails.Shipment.ShipmentUpdate=1 ;
                Cart.DeliveryManAssingment =(DeliveryManAssignmentModel) AssignmentDelivery.Select(x => x.OrderID == id);
                Cart.DeliveryManAssingment.AssigentmentUpdate = 1 ;
                OrderManager.CompleteOrder(Cart.CartDetails.Order);
                OrderManager.CompletePayment(Cart.CartDetails.Payment);
                OrderManager.CompleteShipment(Cart.CartDetails.Shipment);
                foreach (var product in Cart.CartDetails.OrderItem)
                {
                    var productdetails = ProductManager.GetSingleProduct(product.Product);
                    productdetails.ProductQuantity = productdetails.ProductQuantity - productdetails.ProductQuantity;
                    ProductManager.UpdateProduct(productdetails);
                }  
            }
            catch (Exception ex)
            {
                Updated = false;
            }
            return Updated;
        }
        private CartModel OrderDetails(int id)
        {
            CartModel Cart = new CartModel();
            var DeliveryManDetails = GetCustomerDetails();
            Cart.Order = OrderManager.GetSingleOrderDetails(id);
            Cart.Payment = OrderManager.GetSInglePayment(Cart.Order.OrderId);
            Cart.Shipment = OrderManager.GetSIngleShipment(Cart.Order.OrderId);
            Cart.OrderItem = OrderManager.GetSIngleOrderItem(Cart.Order.OrderId);
            return Cart;
        }
        public int pagecountDeliveryManDueAssng(int perpagedata, int DeliveryManID)
        {
            var assigenments = AssignmentManager.GetAllAssignmentDeliveryMan();
            List<DeliveryManAssignmentModel> AppointmentList = assigenments.Where(x => x.DeliveryManeID == DeliveryManID && x.AssigentmentUpdate == 0).ToList();
            return Convert.ToInt32(Math.Ceiling(AppointmentList.Count() / (double)perpagedata));
        }
        public List<DeliveryManAssignmentModel> perpageshowdataDeliveryManDueAssng(int pageindex, int pagesize, int DeliveryManID)
        {
            var assigenments = AssignmentManager.GetAllAssignmentDeliveryMan();
            List<DeliveryManAssignmentModel> AppointmentList = assigenments.Where(x => x.DeliveryManeID == DeliveryManID && x.AssigentmentUpdate == 0).ToList();
            return AppointmentList.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        public JsonResult GetpaginatiotabledataDeliveryManDueAssng(int pageindex, int pagesize)
        {
            AdminViewModel AppointmentList = new AdminViewModel();
            var DeliveryManAssngDetails = GetCustomerDetails();
            AppointmentList.DeliverymanAssignmentList = perpageshowdataDeliveryManDueAssng(pageindex, pagesize, DeliveryManAssngDetails.DeliverManId);
            AppointmentList.totalpage = pagecountDeliveryManDueAssng(pagesize, DeliveryManAssngDetails.DeliverManId);
            var AppointmentListitem = JsonConvert.SerializeObject(AppointmentList);
            return Json(AppointmentListitem, JsonRequestBehavior.AllowGet);
        }
        public int pagecountDeliveryManCompleteAssng(int perpagedata, int DeliveryManID)
        {
            var assigenments = AssignmentManager.GetAllAssignmentDeliveryMan();
            List<DeliveryManAssignmentModel> AppointmentList = assigenments.Where(x => x.DeliveryManeID == DeliveryManID && x.AssigentmentUpdate == 1).ToList();
            return Convert.ToInt32(Math.Ceiling(AppointmentList.Count() / (double)perpagedata));
        }
        public List<DeliveryManAssignmentModel> perpageshowdataDeliveryManCompleteAssng(int pageindex, int pagesize, int DeliveryManID)
        {
            var assigenments = AssignmentManager.GetAllAssignmentDeliveryMan();
            List<DeliveryManAssignmentModel> AppointmentList = assigenments.Where(x => x.DeliveryManeID == DeliveryManID && x.AssigentmentUpdate == 1).ToList();
            return AppointmentList.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }
        public JsonResult GetpaginatiotabledataCompleteAssng(int pageindex, int pagesize)
        {
            AdminViewModel AppointmentList = new AdminViewModel();
            var DeliveryManAssngDetails = GetCustomerDetails();
            AppointmentList.DeliverymanAssignmentList = perpageshowdataDeliveryManCompleteAssng(pageindex, pagesize, DeliveryManAssngDetails.DeliverManId);
            AppointmentList.totalpage = pagecountDeliveryManCompleteAssng(pagesize, DeliveryManAssngDetails.DeliverManId);
            var AppointmentListitem = JsonConvert.SerializeObject(AppointmentList);
            return Json(AppointmentListitem, JsonRequestBehavior.AllowGet);
        }
    }
}