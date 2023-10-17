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
        public SubCategoryModel SubCategory { get; set; }
        public DeliveryCharge deliverycharge{ get; set; }
        public Area area { get; set; }
        public Zone zone { get; set; }
        public DeliveryManModel DeliveryMane { get; set; }
        public UserModel User { get; set; }
        public SupplierModel Supplier { get; set; }
        public AdminModel Admin { get; set; }
        public DeliveryManModel DeliveryMan { get; set; }
        //public UserModel User { get; set; }
        public AppointmentModel Appointment { get; set; }
        public AdminAssignmentModel AdminAssignment { get; set; }
        public SupplierAssignmentModel SupplierAssignment { get; set; }
        public DeliveryManAssignmentModel DeliverymanAssignment { get; set; }
        public FAQModel FAQ { get; set; }
        public CartModel Cart { get; set; }
        public OrderModel Order { get; set; }
        public DashBoardModel DashBoard { get; set; }


        // All Model Lists
        public List<FAQModel> FAQList { get; set; }
        public List<ReviewModel> ReviewList { get; set; }
        public List<DeliveryManModel> DeliveryManList { get; set; }
        public List<ViewSupplierAssignmentModel> ViewSupplierAssignmentList { get; set; }
        public List<AdminAssignmentModel> AdminAssignmentList { get; set; }
        public List<DeliveryManAssignmentModel> DeliverymanAssignmentList { get; set; }
        public List<AppointmentModel> AppointmentList { get; set; }
        public List<AdminModel> AdminList { get; set; }
        public List<SupplierModel> SupplierList { get; set; }
        public List<EmailModel> EmailList { get; set; }
        public List<DeliveryManModel> DeliveryManeList { get; set; }
        public List<ProductModel> ProductList { get; set; }
        //public List<ProductModel> ProductSearchList { get; set; }
        public List<DeliveryCharge> deliverychargeList { get; set; }
        public List<Zone> zoneList { get; set; }
        public List<Area> areaList { get; set; }
        public List<CategoryModel> CategoryList { get; set; }
        public List<SubCategoryModel> SubCategoryList { get; set; }
        public List<viewsubcategory> viewsubcategorydetails { get; set; }
        public List<viewZone> viewzone { get; set; }
        public List<CustomerModel> CustomerList { get; set; }
        public List<CartModel> CustomerWiseOrderList { get; set; }

        public List<OrderModel> CustomerOrderList { get; set; }


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
        public int totalpage { get; set; }

        // Image
        [Required(ErrorMessage = "Please Upload a Image")]
        public HttpPostedFileBase File { get; set; }
        [Required(ErrorMessage = "Please Upload a Image")]
        public HttpPostedFileBase[] Files { get; set; }
    }
}
