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
        // All Single Model
        public ProductModel Product { get; set; }
        public CategoryModel Category { get; set; }
        public int totalpage { get; set; }
        public SubCategoryModel SubCategory { get; set; }
        public DeliveryCharge deliverycharge{ get; set; }
        public Area area { get; set; }
        public Zone zone { get; set; }

        // All Lists
        public List<ProductModel> ProductList { get; set; }
        //public List<ProductModel> ProductSearchList { get; set; }
        public List<DeliveryCharge> deliverychargeList { get; set; }
        public List<Area> zoneList { get; set; }
        public List<Zone> areaList { get; set; }
        public List<CategoryModel> CategoryList { get; set; }
        public List<SubCategoryModel> SubCategoryList { get; set; }
        public List<viewsubcategory> viewsubcategorydetails { get; set; }

        //public RoleModel role { get; set; }
        //public List<RoleModel> rolelist { get; set; }
        //public UserModel User { get; set; }
        //public List<CustomerInformation> customerlist { get; set; }
        //public CustomerInformation Customer { get; set; }
        //public AdminModel Admin { get; set; }

        //Super Admin and Admin Dash Board
        public int TotalProduct { get; set; }
        public int TotalOrder { get; set; }
        public int TotalCustomer { get; set; }

        // Image
        [Required(ErrorMessage = "Please Upload a Image")]
        public HttpPostedFileBase File { get; set; }
        [Required(ErrorMessage = "Please Upload a Image")]
        public HttpPostedFileBase[] Files { get; set; }
    }
}
