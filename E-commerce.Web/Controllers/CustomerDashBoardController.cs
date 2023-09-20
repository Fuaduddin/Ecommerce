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
            CustomerViewModel customerorder = new CustomerViewModel();
            customerorder.DashBoard = UserDashboardDetails(customer.CustomerId);
            return View("DashBoard", customerorder);
        }
        public ActionResult ViewAllOrder()
        {
            CustomerViewModel customerorder= new CustomerViewModel();
            List<CartModel> cart = new List<CartModel>();
            CustomerModel customer = (CustomerModel)Session["CustomerDetails"];
            var OrderList = OrderManager.GetSIngleCustomerOrder(customer.CustomerId);
            foreach (var Order in OrderList) 
            {
                CartModel cartmodel = new CartModel();
                cartmodel.Shipment = OrderManager.GetSIngleShipment(Order.OrderId);
                cartmodel.Payment = OrderManager.GetSInglePayment(Order.OrderId);
                cartmodel.OrderItem = OrderManager.GetSIngleOrderItem(Order.OrderId);
                cartmodel.Order = Order;
                cart.Add(cartmodel);
            }
            customerorder.CustomerWiseOrderList= cart;
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
    }
}

