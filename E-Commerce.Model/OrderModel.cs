using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model
{
    public class CartModel
    {
        public OrderModel Order { get; set; }
        public ShipmentModel Shipment { get; set; }
        public List<OrderItemModel> OrderItem { get; set; }
        public Payment Payment { get; set; }
    }
   public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderAddedDate { get; set; }
        public int TotalPrice { get; set; }
        public int CustomerID { get; set; }
        public int OrderDeliveryUpdate { get; set; }
        public string OrderOfficialId { get; set; }
		public string CustomerName { get; set; }
	}
    public class ShipmentModel
    {
        [Key]
        public int ShipmentId { get; set; }
        public DateTime ShipmentAddedDate { get; set; }
        public string ShipmentAddress { get; set; }
        public int ZoneName { get; set; }
        public int AreaName { get; set; }
        public int OrderId { get; set; }
        public int ShipmentUpdate { get; set; }
        public DateTime ShipmentItemPickedUpDate { get; set; }
		public string PlaceName { get; set; }
		public string DevisionName { get; set; }
	}
    public class OrderItemModel
    {
        [Key]
        public int OrderItemId { get; set; }
        public int Product { get; set; }
        public int Quantity { get; set; }
        public int ProductPrice { get; set; }
        public int OrderId { get; set; }
		public string ProductName { get; set; }
	}
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentMethod { get; set; }
        public int Amount { get; set; }
        public int OrderId { get; set; }
    }
    //public class TrackOrder
    //{

    //    //public int OrderId { get; set; }
    //    //public DateTime OrderDate { get; set; }
    //    //public int TotalPrice { get; set; }
    //    //public int OrderDeliveryUpdate { get; set; }
    //    //public string OrderOfficialId { get; set; }
    //    //public string ZoneName { get; set; }
    //    //public string AreaName { get; set; }
    //    //public int ShipmentUpdate { get; set; }
    //    //public string PaymentMethod { get; set; }
    //    //public DateTime PaymentDate { get; set; }
    //    //public string ShipmentAddress { get; set; }
    //    //public string CustomerName { get; set; }
    //    //public string CustomerPhoneNumber { get; set; }
    //}
}
