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
        public ActionResult AddNewProduct(ProductModel product, HttpPostedFileBase File, HttpPostedFileBase [] Files )
        {
            if (product.ProductId > 0)
            {
                if (File.ContentLength >0)
                {
                    product.ProductImage = UploadImage(File);
                }
                ProductManager.UpdateProduct(product);
               return View("GetAllProduct");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    product.ProductImage = UploadImage(File);
                    var productid = ProductManager.AddNewProduct(product);
                    foreach (var images in Files)
                    {
                        var imageurl = UploadImage(images);
                        ImageGalleryManager.AddNewProductImageGallery(imageurl, productid);
                    } 
                    return View("GetAllProduct");
                }
            }
            return View();
        }
      public ActionResult GetAllProduct()
      {
        AdminViewModel product = new AdminViewModel();
        product.Product = new ProductModel();
        product.CategoryList = CategoryManager.GetAllCategory();
        return View(product);
      }
        //    public ActionResult GetSingleProductUpdate()
        //   {
        //  AdminViewModel product = new AdminViewModel();
        //  product.Product = new ProductModel();
        //  product.CategoryList = CategoryManager.GetAllCategory();
        //  product.viewsubcategorydetails = SubCategoryManager.GetAllSubCategory();
        //    return View(product);
        // }
        //  public ActionResult GetSingleProduct()
        //   {
        //   AdminViewModel product = new AdminViewModel();
        //   product.Product = new ProductModel();
        //   product.CategoryList = CategoryManager.GetAllCategory();
        //    product.viewsubcategorydetails = SubCategoryManager.GetAllSubCategory();
        //        return View(product);
        //  }
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

        public JsonResult Getselectedsubcategory(int categoryid)
        {
            var subcategoprylist = SubCategoryManager.GetAllSelectedSubCategory(categoryid);
            var result = JsonConvert.SerializeObject(subcategoprylist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}