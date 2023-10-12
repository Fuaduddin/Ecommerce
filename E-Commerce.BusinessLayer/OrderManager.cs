using E_Commerce.DataLayerSQL;
using E_Commerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BusinessLayer
{
    public class OrderManager
    {
        // Order
        public static long AddNewOrder(OrderModel order)
        {
            OrderSQLProvider provider = new OrderSQLProvider();
            var chargeid = provider.AddNewOrder(order);
            return chargeid;
        }
        public static OrderModel GetSIngleOrder(string order)
        {
            OrderSQLProvider provider = new OrderSQLProvider();
            var chargeid = provider.GetSIngleOrder(order);
            return chargeid;
        }
        public static bool DeleteOrder(int  orderID)
        {
            OrderSQLProvider provider = new OrderSQLProvider();
            var chargeid = provider.DeleteOrder(orderID);
            return chargeid;
        }
        //Shipment
        public static long AddNewShipment(ShipmentModel shipment)
        {
            OrderSQLProvider provider = new OrderSQLProvider();
            var chargeid = provider.AddNewShipment(shipment);
            return chargeid;
        }
        public static ShipmentModel GetSIngleShipment(int order)
        {
            OrderSQLProvider provider = new OrderSQLProvider();
            var chargeid = provider.GetSIngleShipment(order);
            return chargeid;
        }
        public static bool DeleteShipment(int orderID)
        {
            OrderSQLProvider provider = new OrderSQLProvider();
            var chargeid = provider.DeleteShipment(orderID);
            return chargeid;
        }
        // Order Item
        public static long AddNewOrderItem(OrderItemModel OrderItem)
        {
            OrderSQLProvider provider = new OrderSQLProvider();
            var chargeid = provider.AddNewOrderItem(OrderItem);
            return chargeid;
        }
        public static bool DeleteOrderItem(int orderID)
        {
            OrderSQLProvider provider = new OrderSQLProvider();
            var chargeid = provider.DeleteOrderItem(orderID);
            return chargeid;
        }
        public static List<OrderItemModel> GetSIngleOrderItem(int order)
        {
            OrderSQLProvider provider = new OrderSQLProvider();
            var chargeid = provider.GetSIngleOrderItem(order);
            return chargeid;
        }
        // Payment
        public static long AddNewPayment(Payment payment)
        {
            OrderSQLProvider provider = new OrderSQLProvider();
            var chargeid = provider.AddNewPayment(payment);
            return chargeid;
        }
        public static Payment GetSInglePayment(int id)
        {
            OrderSQLProvider provider = new OrderSQLProvider();
            var chargeid = provider.GetSInglePayment(id);
            return chargeid;
        }
        public static bool DeletePayment(int orderID)
        {
            OrderSQLProvider provider = new OrderSQLProvider();
            var chargeid = provider.DeletePayment(orderID);
            return chargeid;
        }
        // Get Signle Customer Wise Order
        public static List<OrderModel> GetSIngleCustomerOrder(int CustomerID)
        {
            OrderSQLProvider provider = new OrderSQLProvider();
            var chargeid = provider.GetSIngleCustomerOrder(CustomerID);
            return chargeid;
        }



        // Super Admin & Admin
        public static List<OrderModel> GetAllCustomerOrder()
        {
            OrderSQLProvider provider = new OrderSQLProvider();
            var chargeid = provider.GetAllCustomerOrder();
            return chargeid;
        }
        public static OrderModel GetSingleOrderDetails(int id)
        {
            OrderSQLProvider provider = new OrderSQLProvider();
            var chargeid = provider.GetSingleOrderDetails(id);
            return chargeid;
        }


        /// Complete Order Update
        
        public static bool CompleteOrder(OrderModel Order)
        {
            OrderSQLProvider provider = new OrderSQLProvider();
            var chargeid = provider.CompleteOrder(Order);
            return chargeid;
        }
        public static bool CompletePayment(Payment payment)
        {
            OrderSQLProvider provider = new OrderSQLProvider();
            var chargeid = provider.CompletePayment(payment);
            return chargeid;
        }
        public static bool CompleteShipment(ShipmentModel shipment)
        {
            OrderSQLProvider provider = new OrderSQLProvider();
            var chargeid = provider.CompleteShipment(shipment);
            return chargeid;
        }


        //public static List<DeliveryCharge> GetAllDeliveryCost()
        //{
        //    DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
        //    var chargeid = provider.ViewAllDeliveryCharge();
        //    return chargeid;
        //}
        //public static bool UpdateDeliveryCost(DeliveryCharge category)
        //{
        //    DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
        //    var chargeid = provider.UpdateDeliveryCharge(category);
        //    return chargeid;
        //}
        //public static DeliveryCharge GetSingleDeliveryCost(int categoryId)
        //{
        //    DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
        //    var chargeid = provider.GetSingleDelivery(categoryId);
        //    return chargeid;
        //}
        //public static bool DeleteDeliveryCost(int categoryId)
        //{
        //    DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
        //    var Categoriesd = provider.DeleteDeliveryCharge(categoryId);
        //    return Categoriesd;
        //}
        //public static List<DeliveryCharge> SearchDeliveryCost(string SearchKeyword)
        //{
        //    DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
        //    var Categoriesd = provider.SearchDeliveryCost(SearchKeyword);
        //    return Categoriesd;
        //}
    }
}
