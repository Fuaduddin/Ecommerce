using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce.Model;
using E_Commerce.BusinessLayer;
using Newtonsoft.Json;

namespace E_Commerce.Admin.Panel.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult AddNewProduct()
        {
            AdminViewModel product = new AdminViewModel();
            product.Product = new ProductModel();
            product.CategoryList = CategoryManager.GetAllCategory();
            product.viewsubcategorydetails = SubCategoryManager.GetAllSubCategory();
            return View(product);
        }
        [HttpPost]
        public ActionResult AddNewProduct(ProductModel product, HttpPostedFileBase File, HttpPostedFileBase [] Files,int subcategoryitems )
        {
            if (product.ProductId > 0)
            {
                if (File.ContentLength >0)
                {
                    product.ProductImage = UploadImage(File);
                }
                if(Files != null)
                {
                    foreach (var images in Files)
                    {
                        var imageurl = UploadImage(images);
                        ImageGalleryManager.AddNewProductImageGallery(imageurl, product.ProductId);
                    }
                }
                if( ProductManager.UpdateProduct(product))
                {
                    ModelState.Clear();
                    ViewData["Message"] = "Your data have been Updated";
                }
                else
                {
                    ViewData["Message"] = "Your data have not been Updated";
                }
               return View("GetAllProduct");
            }
            else
            {
                int i = 0;
                if (ModelState.IsValid)
                {
                    product.ProductImage = UploadImage(File);
                    product.SubCategoryId= subcategoryitems;
                    product.AddedDate = DateTime.Today;
                    long productid = ProductManager.AddNewProduct(product);
                    ViewBag.productid = productid;
                    foreach (var images in Files)
                    {
                        var imageurl = UploadImage(images);
                        ImageGalleryManager.AddNewProductImageGallery(imageurl, productid);
                        i++;
                    }
                    if (ProductManager.AddNewProduct(product) > 0 && Files.Length==i)
                    {
                        ModelState.Clear();
                        ViewData["Message"] = "Your data have been Added";
                    }
                    else
                    {
                        ViewData["Message"] = "Your data have not been Added";
                    }
                    AdminViewModel faq = new AdminViewModel();
                    faq.FAQ = new FAQModel();
                    return View("AddNewFAQ", faq);
                }
            }
            return View();
        }
        public JsonResult Getselectedsubcategory(int categoryid)
        {
            List<SubCategoryModel> Subcategorylist = SubCategoryManager.GetAllSelectedSubCategory(categoryid);
            var result = JsonConvert.SerializeObject(Subcategorylist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddNewFAQ()
        {
            AdminViewModel faq = new AdminViewModel();
            faq.FAQ = new FAQModel();
            return View("AddNewFAQ", faq);
        }
        [HttpPost]
        public ActionResult AddNewFAQ(string [] question, string [] answer,int [] id, int productid)
        {
            if(id != null)
            {
                for(var i=0;i<id.Length;i++)
                {
                    ContactManager.UpdateFAQ(id[i],question[i], answer[i], productid);
                }
            }
            else
            {
                for(var i =0; i<question.Length;i++)
                {
                    ContactManager.AddNewFAQ(question[i], answer[i], productid);
                }
            }
            return View("GetAllProduct");
        }
        public JsonResult DeleteFaq(int id)
        {
            bool isdeleted = ContactManager.DeleteFAQ(id);
            var result = JsonConvert.SerializeObject(isdeleted);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllProduct()
        {
          AdminViewModel product = new AdminViewModel();
           product.ProductList = ProductManager.GetAllProduct();
          return View("GetAllProduct",product);
         }
        [HttpGet]
        public ActionResult GetSingleProduct(int id)
        {
           AdminViewModel product = new AdminViewModel();
            if(id>0)
            {
                product.Product=ProductManager.GetSingleProduct(id);
                product.CategoryList = CategoryManager.GetAllCategory();
            }
           return View("AddNewProduct", product);
        }
        public ActionResult DeleteProduct(int id)
         {
            if (id > 0)
            {
               bool imagedeleted= ImageGalleryManager.DeleteProductImageGallery(id);
                if (imagedeleted) {
                 ProductManager.DeleteProduct(id);
                } 
            }
            AdminViewModel product = new AdminViewModel();
            product.Product = new ProductModel();
            return View("GetAllProduct",product);
         }
        public string UploadImage(HttpPostedFileBase CategoryImage)
        {
            string savepath = "";
            string imageurl, imagepath, filepath;
            if (CategoryImage.ContentLength > 0)
            {
                var filename = Path.GetFileName(Guid.NewGuid() + CategoryImage.FileName);
                imagepath = Server.MapPath("~/Image/");
                filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/");
                if (imagepath == null)
                {
                    Directory.CreateDirectory(imagepath);
                }
                imageurl = Path.Combine(imagepath, filename);
                savepath = "/Image/" + filename;
                CategoryImage.SaveAs(imageurl);
            }
            return savepath;
        }

     
    }
}