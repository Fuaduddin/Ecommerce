using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce.BusinessLayer;
using E_Commerce.Model;

namespace E_Commerce.Admin.Panel.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult ViewAllOrder()
        {
            AdminViewModel OrderList = new AdminViewModel();
            List<CartModel> cart = new List<CartModel>();
            var OrderListitems = OrderManager.GetAllCustomerOrder();
            foreach (var Order in OrderListitems)
            {
                CartModel cartmodel = new CartModel();
                cartmodel.Shipment = OrderManager.GetSIngleShipment(Order.OrderId);
                cartmodel.Payment = OrderManager.GetSInglePayment(Order.OrderId);
                cartmodel.OrderItem = OrderManager.GetSIngleOrderItem(Order.OrderId);
                cartmodel.Order = Order;
                cart.Add(cartmodel);
            }
            OrderList.CustomerWiseOrderList = cart;
            return View("ViewAllOrder", OrderList);
        }
        public ActionResult CancleOrder(int id)
        {
            if (id > 0)
            {
                if (OrderManager.DeleteShipment(id) && OrderManager.DeleteOrderItem(id) && OrderManager.DeletePayment(id))
                {
                    if (OrderManager.DeleteOrder(id))
                    {
                        ViewData["Message"] = "Your data have been deleted";
                    }
                    else
                    {
                        ViewData["Message"] = "!!!!!! Error !!!!!!!";
                    }
                }
            }
            return View();
        }
    }
}