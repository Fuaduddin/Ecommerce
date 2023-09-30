using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model
{
    public class CustomerViewModel
    {
        public CustomerModel Customer { get; set; }
        public EmailModel  Email { get; set; }
        public AppointmentModel Appointment { get; set; }
        public UserModel user { get; set; }
        public ProductModel Product { get; set; }
        public ReviewModelRatingDetails RatingDetails { get; set; }
        public ReviewModel Review { get; set; }
        public FAQModel FAQ { get; set; }
        public ShipmentModel shipment { get; set; }
        public CartModel Cart { get; set; }
        public DashBoardModel DashBoard { get; set; }


        // List
        public List<DeliveryCharge> PaymentMethodList { get; set; }
        public List<viewZone> viewzoneList { get; set; }
        public List<Area> AreaList { get; set; }
        public List<FAQModel> FAQList { get; set; }
        public List<viewZone> viewzone { get; set; }
        public List<Area> areaList { get; set; }
        public List<ProductModel> ProductList { get; set; }
        public List<ProductModel> LetestProductList { get; set; }
        public List<CategoryModel> CategoryList { get; set; }
        public List<viewsubcategory> viewsubcategorydetails { get; set; }
        public List<ImageGallery> Imagegallery { get; set; }
        public List<ReviewModel> ReviewList { get; set; }
        public List<SubCategoryModel> SubCategoryList { get; set; }
        public List<CartModel> CustomerWiseOrderList { get; set; }

        // Common
        public int totalpage { get; set; }
    }
}
