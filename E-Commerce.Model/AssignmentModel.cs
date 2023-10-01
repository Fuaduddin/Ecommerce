using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model
{
    public class AssignmentModel
    {

    }
    public class ViewSupplierAssignmentModel
    {
        public int AssigentmentSupplierId { get; set; }
        public DateTime AssignDate { get; set; }
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public int TotalAmount { get; set; }
        public int AssignmentUpdate { get; set; }
        public int AssignmentTotalCost { get; set; }
        public string ProdcutItemId { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductPrice { get; set; }
        public int ProductWidth { get; set; }
        public int ProductHeight { get; set; }
        public int ProductWeight { get; set; }
        public string ProductColor { get; set; }
        public int ProductDepth { get; set; }
        public int ProductFreshnessDuration { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
    }
    public class SupplierAssignmentModel
    {
        [Key]
        public int AssigentmentSupplierId { get; set; }
        public DateTime AssignDate { get; set; }
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public int TotalAmount { get; set; }
        public int AssignmentUpdate { get; set; }
        public int AssignmentTotalCost { get; set; }

    }
    public class AdminAssignmentModel
    {
        [Key]
        public int AssigentmentAppointmentId { get; set; }
        public DateTime AssigentmentAppointmentDate { get; set; }
        public DateTime AssigentmentFixedDate { get; set; }
        [Required(ErrorMessage = "Please Select Appointment")]
        public int AppointId { get; set; }
        [Required(ErrorMessage = "Please Assign Admin")]
        public int AdminId { get; set; }
        public int AssigentmentUpdate { get; set; }
        public string AppointmentSubject { get; set; }
        public string AppointmentMessage { get; set; }
        public DateTime AppointDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmail { get; set; }
        public int AssingedUpdate { get; set; }
        public string AdminName { get; set; }
    }
    //update
    public class DeliveryManAssignmentModel 
{
        [Key]
        public int AssignmentDeliveryId { get; set; }
        public DateTime AssignDate { get; set; }
        public int DeliveryManeID { get; set; }
        public int OrderID { get; set; }
        public int AssigentmentUpdate { get; set; }
        public string DeliveryManeName { get; set; }
        public string DevisionName { get; set; }
        public string PlaceName { get; set; }
        public string OrderOfficialId { get; set; }
        public string ShipmentAddress { get; set; }
        public int TotalPrice { get; set; }
    }
}
