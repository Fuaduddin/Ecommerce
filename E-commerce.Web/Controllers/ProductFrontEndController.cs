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
    public class ProductFrontEndController : Controller
    {
        // GET: ProductFrontEnd
        // Category Wise Product Page
        [HttpGet]
        public ActionResult categoryproduct(int id)
        {
            CustomerViewModel categoryproduct = new CustomerViewModel();
            if (id>0)
            {
                var productlist = GetAllCategoryWiseProduct();
                categoryproduct.ProductList = productlist.Where(x => x.CategoryId == id).ToList();
                categoryproduct.SubCategoryList = SubCategoryManager.GetAllSelectedSubCategory(id);
                ViewBag.categoryID = id;
            }
           else
            {
                categoryproduct.ProductList = GetAllCategoryWiseProduct();
                categoryproduct.SubCategoryList = SubCategoryManager.GetAllSelectedSubCategory(id);
                ViewBag.categoryID = id;
            }
            return View("categoryproduct", categoryproduct);
        }
        // Single Product Page
        public ActionResult singleproduct(int id)
        {
            CustomerViewModel Singleproduct = new CustomerViewModel();
            Singleproduct.Product = new ProductModel();
            Singleproduct.Product = ProductManager.GetSingleProduct(id);
            Singleproduct.Imagegallery = ImageGalleryManager.GetSingleProductAllImage(id);
            Singleproduct.FAQList = ContactManager.GetSingleProductAllFAQ(id);
            Singleproduct.ReviewList = ContactManager.GetSingleProductReview(id);
            Singleproduct.RatingDetails = GetProductWiseReview(Singleproduct.ReviewList);
            Singleproduct.Review = new ReviewModel();
            return View("singleproduct", Singleproduct);
        }
        [HttpPost]
        public ActionResult SortSearchProduct(int[]subcategory, int startingvalue, int endingvalue)
        {
            CustomerViewModel Sortproduct = new CustomerViewModel();
            if (subcategory != null)
            {
                Sortproduct.ProductList = SortSearchProducts(subcategory,0,0);
            }
            else
            {
                subcategory = null;
                Sortproduct.ProductList = SortSearchProducts(subcategory, startingvalue, endingvalue);
            }
            return View("categoryproduct", Sortproduct);
        }
        public List<ProductModel> SortSearchProducts(int[] subcategoryid, int startingvalueprice, int endingvalueprice)
        {
            List<ProductModel> productlist = new List<ProductModel>();
            int id= (int)ViewBag.categoryID;
            if (subcategoryid.Length>0 && startingvalueprice>0 && endingvalueprice>0)
            {
                foreach(var subcategory in subcategoryid)
                {
                    var getallpricesorted = ProductManager.GetAllProduct().Where(x => x.SubCategoryId == subcategory && x.ProductPrice >= startingvalueprice && x.ProductPrice <= endingvalueprice && x.CategoryId==id).ToList();
                    foreach (var productitem in getallpricesorted)
                    {
                        ProductModel product = new ProductModel();
                        product = (ProductModel)productitem;
                        productlist.Add(product);
                    }
                }
            }
            else
            {
                if(endingvalueprice<=0)
                {
                    endingvalueprice = startingvalueprice + 3000;
                }
                var getallpricesorted = ProductManager.GetAllProduct().Where(x => x.ProductPrice >= startingvalueprice && x.ProductPrice <= endingvalueprice && x.CategoryId == id).ToList();
                foreach(var productitem in getallpricesorted)
                {
                    ProductModel product = new ProductModel();
                    product = (ProductModel)productitem;
                    productlist.Add(product);
                }
            }
            return productlist;
        }
        
        public JsonResult SubmitReview(ReviewModel Review)
        {
           bool isadded =true;
            if(Review != null)
            {
                if(ContactManager.AddNewReview(Review) >0)
                {
                    ViewData["Message"] = "Thank You for Your Feed Back";
                    ModelState.Clear();
                } 
                else
                {
                    ViewData["Message"] = "!!!!!! ERROR !!!!!!!!";
                    isadded = false;
                }
            }
            return Json(isadded, JsonRequestBehavior.AllowGet);
        }
        private List<ProductModel> GetAllCategoryWiseProduct()
        {
            List<ProductModel> productlist = new List<ProductModel>();
            productlist = ProductManager.GetAllProduct();
            return productlist;
        }
        private ReviewModelRatingDetails GetProductWiseReview( List<ReviewModel> Reviews)
        {
            ReviewModelRatingDetails ratingdetails = new ReviewModelRatingDetails();
            var totalratings = ((5 * Reviews.Select(x => x.TotalRating == 5).ToList().Count())
                + (4 * Reviews.Select(x => x.TotalRating == 4).ToList().Count()) + (3 * Reviews.Select(x => x.TotalRating == 3).ToList().Count())
                + (3 * Reviews.Select(x => x.TotalRating == 3).ToList().Count()) + (2 * Reviews.Select(x => x.TotalRating == 2).ToList().Count())
                + (1 * Reviews.Select(x => x.TotalRating == 1).ToList().Count()));
            if (Reviews.Count > 0)
            {
                 ratingdetails = new ReviewModelRatingDetails
                {
                    TotalCustomerRating = Reviews.Count(),
                    TotalFiveStarRating = Reviews.Select(x => x.TotalRating == 5).ToList().Count(),
                    TotalFiveStarRatingCUstomer = Reviews.Select(x => x.TotalRating == 5).ToList().Count(),
                    TotalFourStarRating = Reviews.Select(x => x.TotalRating == 4).ToList().Count(),
                    TotalFourStarRatingCUstomer = Reviews.Select(x => x.TotalRating == 4).ToList().Count(),
                    TotalThreeStarRating = Reviews.Select(x => x.TotalRating == 3).ToList().Count(),
                    TotalThreeStarRatingCUstomer = Reviews.Select(x => x.TotalRating == 3).ToList().Count(),
                    TotalTwoStarRating = Reviews.Select(x => x.TotalRating == 2).ToList().Count(),
                    TotalTwoStarRatingCUstomer = Reviews.Select(x => x.TotalRating == 2).ToList().Count(),
                    TotalOneStarRating = Reviews.Select(x => x.TotalRating == 1).ToList().Count(),
                    TotalOneStarRatingCUstomer = Reviews.Select(x => x.TotalRating == 1).ToList().Count(),
                    AverageStarRating = totalratings / Reviews.Count()
                };
            }
            return ratingdetails;
        }
    }
}