using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model
{
    public class SupplierandDeliveryManViewModel
    {
        // All Single Model
        public ProductModel Product { get; set; }
        public SupplierAssignmentModel SupplierAssignment { get; set; }
        public ViewSupplierAssignmentModel UpdateAssignment { get; set; }
        public DashBoardModel dashboarddetails { get; set; }

        // All List Supplier and Delivery Man Dash Board
        public List<ViewSupplierAssignmentModel> ViewSupplierAssignmentList { get; set; }
        public List<DeliveryManAssignmentModel> DeliverymanAssignmentList { get; set; }
        public List<CategoryModel> CategoryList { get; set; }
        public List<SubCategoryModel> SubCategoryList { get; set; }
        // Supplier and Delivery Man Dash Board
        public int TotalCompleteAssng { get; set; }
        public int DueAssng { get; set; }
        public int TotalAssng { get; set; }
        public int totalpage { get; set; }
    }
}
