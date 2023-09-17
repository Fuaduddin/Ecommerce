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
        //public ActionResult categoryproduct()
        //{
        //    return View("categoryproduct");
        //}
        [HttpGet]
        public ActionResult categoryproduct(int id)
        {
            CustomerViewModel categoryproduct = new CustomerViewModel();
            var productlist = GetAllCategoryWiseProduct();
            categoryproduct.ProductList = productlist.Where(x=> x.CategoryId==id).ToList();
            categoryproduct.SubCategoryList = SubCategoryManager.GetAllSelectedSubCategory(id);
            //ViewData["categoryid"] = id;
           // categoryproduct.CategoryList = CategoryManager.GetAllCategory();
            return View("categoryproduct", categoryproduct);
        }
        // Single Product Page
        public ActionResult singleproduct()//int id)
        {

            CustomerViewModel categoryproduct = new CustomerViewModel();
            categoryproduct.Review = new ReviewModel();
            //var productlist = GetAllCategoryWiseProduct();
            //categoryproduct.Product =(ProductModel)productlist.Where(x => x.ProductId == id).Take(1);
            ///return View("singleproduct", categoryproduct);
            return View("singleproduct", categoryproduct);
        }
        [HttpPost]
        public ActionResult SortSearchProduct(int[]subcategory, int startingvalue, int endingvalue)
        {
            CustomerViewModel categoryproduct = new CustomerViewModel();
            if (subcategory.Length>0)
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

            if(subcategoryid.Length>0 && startingvalueprice>0 && endingvalueprice>0)
            {
                foreach(var subcategory in subcategoryid)
                {
                    var getallpricesorted = ProductManager.GetAllProduct().Where(x => x.SubCategoryId == subcategory && x.ProductPrice >= startingvalueprice && x.ProductPrice <= endingvalueprice).ToList();
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
                var getallpricesorted = ProductManager.GetAllProduct().Where(x => x.ProductPrice >= startingvalueprice && x.ProductPrice <= endingvalueprice).ToList();
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