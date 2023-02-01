using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce.BusinessLayer;
using E_Commerce.Model;
using Newtonsoft.Json;

namespace E_Commerce.Admin.Panel.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult AddCategory()
        {
            AdminViewModel category = new AdminViewModel();
            category.Category = new CategoryModel();
            //IEnumerable<CategoryModel> categorylist= CategoryManager.GetAllCategory();
            category.CategoryList = perpageshowdata( 1, 10);
            category.totalpage = pagecount( 10);
            // category.CategoryList = CategoryManager.GetAllCategory();
            return View(category);
        }
        [HttpPost]
        public ActionResult AddCategory(CategoryModel category, HttpPostedFileBase File)
        {
            if (category.CategoryId > 0)
            {
                AdminViewModel categorys = new AdminViewModel();
                if (File != null)
                {
                    category.CategoryImage = UploadImage(File);
                }

                CategoryManager.UpdateCategory(category);
                categorys.CategoryList = perpageshowdata(1, 10);
                categorys.totalpage = pagecount(10);
                categorys.Category = new CategoryModel();
                return View(categorys);
            }
            else
            {
                AdminViewModel categorys = new AdminViewModel();
                category.CategoryImage = UploadImage(File);
                var categoryid = CategoryManager.AddNewCategory(category);
                categorys.CategoryList = perpageshowdata(1, 10);
                categorys.totalpage = pagecount(10);
                if (categoryid > 0)
                {
                    categorys.Category = new CategoryModel();
                    return View("AddCategory", categorys);
                }
            }
            return View();
        }
        public ActionResult GetSingleCategory(int Id)
        {
            AdminViewModel category = new AdminViewModel();
            category.Category = CategoryManager.GetSingleCategory(Id);
            category.CategoryList = perpageshowdata(1, 10);
            category.totalpage = pagecount(10);
            return View("AddCategory", category);
        }
   
        public ActionResult DeleteCategory(string Id)
        {
            AdminViewModel category = new AdminViewModel();
            int CategoryId=Int32.Parse(Id);
            var categorydelete = CategoryManager.DeleteCategory(CategoryId);
            category.CategoryList = perpageshowdata(1, 10);
            category.totalpage = pagecount(10);
            return View("AddCategory", category);
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
        public int pagecount(int perpagedata)
        {
            IEnumerable<CategoryModel> category = CategoryManager.GetAllCategory();
            return Convert.ToInt32(Math.Ceiling(category.Count() / (double)perpagedata));
        }

        public List<CategoryModel> perpageshowdata(int pageindex, int pagesize)
        {
            IEnumerable<CategoryModel> category= CategoryManager.GetAllCategory();
            return category.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }

        public JsonResult Getpaginatiotabledata(int pageindex, int pagesize)
        {
            List<CategoryModel> categorylist = perpageshowdata(pageindex, pagesize);
            var result = JsonConvert.SerializeObject(categorylist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}