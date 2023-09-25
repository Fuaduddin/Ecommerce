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
        [HttpGet]
        public ActionResult singleproduct()//int id)
        {
            int id = 14;
            CustomerViewModel categoryproduct = new CustomerViewModel();
            categoryproduct.Review = new ReviewModel();
            categoryproduct.Product = ProductManager.GetSingleProduct(id);
            categoryproduct.Imagegallery= ImageGalleryManager.GetSingleProductAllImage(id);
            categoryproduct.FAQList = ContactManager.GetSingleProductAllFAQ(id);
            categoryproduct.ReviewList = ContactManager.GetSingleProductReview(id);
            return View("singleproduct", categoryproduct);
        }
        [HttpPost]
        public ActionResult SortSearchProduct(int[]subcategory, int startingvalue, int endingvalue)
        {
            CustomerViewModel categoryproduct = new CustomerViewModel();
            if (subcategory != null)
            {
                categoryproduct.ProductList = SortSearchProducts(subcategory,0,0);
            }
            else
            {
                subcategory = null;
                categoryproduct.ProductList = SortSearchProducts(subcategory, startingvalue, endingvalue);
            }
            return View("categoryproduct", categoryproduct);
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
    }
}