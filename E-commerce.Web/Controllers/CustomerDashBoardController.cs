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
            CustomerViewModel customerorder = new CustomerViewModel();
            var customer = GetCustomerDetails();
            customerorder.totalpage = pagecount(10,0, customer.CustomerId);
            var OrderItemList= perpageshowdata(1,10,0, customer.CustomerId);
            customerorder.CustomerWiseOrderList = GetCart(OrderItemList);
            customerorder.DashBoard = UserDashboardDetails(customer.CustomerId);
            return View("DashBoard", customerorder);
        }
        public ActionResult ViewAllOrder()
        {
            var customer = GetCustomerDetails();
            CustomerViewModel customerorder = new CustomerViewModel();
            customerorder.totalpage = pagecount(10, 0, customer.CustomerId);
            var OrderItemList = perpageshowdata(1, 10, 0, customer.CustomerId);
            customerorder.CustomerWiseOrderList = GetCart(OrderItemList);
            return View("ViewAllOrder", customerorder);
        }
        public ActionResult CancleOrder(int id)
        {
            if(id>0)
            {
                if(OrderManager.DeleteShipment(id) && OrderManager.DeleteOrderItem(id) && OrderManager.DeletePayment(id))
                {
                    if(OrderManager.DeleteOrder(id))
                    {
                        ViewData["Message"] = "Your data have been deleted";
                    }
                    else
                    {
                        ViewData["Message"] = "!!!!!! Error !!!!!!!";
                    }
                }
            }
            return View("ViewAllOrder");
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
            var allorders = OrderManager.GetSIngleCustomerOrder(CustomerID);
            dashboard.TotalOrder= allorders.Count();
            dashboard.TotalDueAssignment = allorders.Select(x=>x.OrderDeliveryUpdate==0).Count();
            dashboard.TotalCompleteAssignment = allorders.Select(x => x.OrderDeliveryUpdate == 1).Count();
            return dashboard;
        }

        private int pagecount(int perpagedata, int OrderUpdate, int CustomerID)
        {
            IEnumerable<OrderModel> OrderList = OrderManager.GetSIngleCustomerOrder(OrderUpdate);
            return Convert.ToInt32(Math.Ceiling(OrderList.Select(x=>x.OrderDeliveryUpdate== OrderUpdate && x.CustomerID== CustomerID).Count() / (double)perpagedata));
        }

        private List<OrderModel> perpageshowdata(int pageindex, int pagesize, int OrderUpdate, int CustomerID )
        {
            IEnumerable<OrderModel> OrderList = OrderManager.GetSIngleCustomerOrder(OrderUpdate);
            return OrderList.Where(x=>x.OrderDeliveryUpdate== OrderUpdate && x.CustomerID == CustomerID).Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }

        private JsonResult Getpaginatiotabledata(int pageindex, int pagesize, int OrderUpdate, int CustomerID)
        {
            CustomerViewModel OrderListitem = new CustomerViewModel();
             var OrderItemList= perpageshowdata(pageindex, pagesize, OrderUpdate, CustomerID);
            OrderListitem.CustomerWiseOrderList= GetCart(OrderItemList);
            OrderListitem.totalpage = pagecount(pagesize, OrderUpdate, CustomerID);
            var result = JsonConvert.SerializeObject(OrderListitem);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        private JsonResult GetSingleOrderDetails(int OrderID)
        {
            CartModel cartmodel = new CartModel();
           cartmodel.Shipment = OrderManager.GetSIngleShipment(OrderID);
           cartmodel.Payment = OrderManager.GetSInglePayment(OrderID);
           cartmodel.OrderItem = OrderManager.GetSIngleOrderItem(OrderID);
           cartmodel.Order = OrderManager.GetSingleOrderDetails(OrderID); ;
            var result = JsonConvert.SerializeObject(cartmodel);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        private JsonResult GetSearcOrder(string OrderOfficialID, int OrderUpdate)
        {
            CustomerViewModel OrderListitem = new CustomerViewModel();
            var OrderItemList = OrderManager.GetAllCustomerOrder();
            //OrderListitem.CustomerWiseOrderList = GetCart(OrderItemList.Where(x=>x.OrderDeliveryUpdate== OrderUpdate && x.CustomerID== && x.OrderOfficialId);
            var result = JsonConvert.SerializeObject(OrderListitem);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        private List<CartModel> GetCart(List<OrderModel> OrderList)
        {
            List<CartModel> cart = new List<CartModel>();
            foreach (var Order in OrderList)
            {
                CartModel cartmodel = new CartModel();
                cartmodel.Shipment = OrderManager.GetSIngleShipment(Order.OrderId);
                cartmodel.Payment = OrderManager.GetSInglePayment(Order.OrderId);
                cartmodel.OrderItem = OrderManager.GetSIngleOrderItem(Order.OrderId);
                cartmodel.Order = Order;
                cart.Add(cartmodel);
            }
            return cart;
        }
        private CustomerModel GetCustomerDetails()
        {
            return  (CustomerModel)Session["CustomerDetails"];
        }
    }
}

