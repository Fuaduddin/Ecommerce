using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace E_Commerce.Model
{
    public class AdminViewModel
    {
        public DeliveryChargeModel DeliveryCharge { get; set; }
        public List<DeliveryChargeModel> DeliveryChargeList { get; set; }
        public ProductModel Product { get; set; }
        public List<ProductModel> ProductList { get; set; }
        //public List<ProductModel> ProductSearchList { get; set; }
        public CategoryModel Category { get; set; }
        public int totalpage { get; set; }
        public SubCategoryModel SubCategory { get; set; }
        //public RoleModel role { get; set; }
        //public List<RoleModel> rolelist { get; set; }
        public List<CategoryModel> CategoryList { get; set; }
        public List<SubCategoryModel> SubCategoryList { get; set; }
        public List<viewsubcategory>viewsubcategorydetails { get; set; }

        [Required(ErrorMessage = "Please Upload a Image")]
        public HttpPostedFileBase File { get; set; }
        [Required(ErrorMessage = "Please Upload a Image")]
        public HttpPostedFileBase [] Files { get; set; }
        //public UserModel User { get; set; }
        //public List<CustomerInformation> customerlist { get; set; }
        //public CustomerInformation Customer { get; set; }
        //public AdminModel Admin { get; set; }
        public int TotalProduct { get; set; }
        public int TotalOrder { get; set; }
        public int TotalCustomer { get; set; }
    }
}
