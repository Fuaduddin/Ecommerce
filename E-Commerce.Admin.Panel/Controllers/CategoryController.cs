using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce.BusinessLayer;
using E_Commerce.Model;
using Newtonsoft.Json;

namespace E_Commerce.Admin.Panel.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult AddCategory()
        {
            AdminViewModel category = new AdminViewModel();
            category.Category = new CategoryModel();
           // IEnumerable<CategoryModel> categorylist= CategoryManager.GetAllCategory();
           category.CategoryList = perpageshowdata(1,10);
           category.totalpage = pagecount(10);
           category.CategoryList = CategoryManager.GetAllCategory();
            return View("AddCategory", category);
        }
        [HttpPost]
        public ActionResult AddCategory(CategoryModel category, HttpPostedFileBase File)
        {
            AdminViewModel categorys = new AdminViewModel();
            if (category.CategoryId > 0)
            {
               
                if (File != null)
                {
                    category.CategoryImage = UploadImage(File);
                }

                if(CategoryManager.UpdateCategory(category))
                {
                    ViewData["Message"] = "Your data have been Updated";
                    ModelState.Clear();
                }
                else
                {
                    ViewData["Message"] = "Your data have not been Updated";
                }
            }
            else
            {
                category.CategoryImage = UploadImage(File);
                if (CategoryManager.AddNewCategory(category) > 0)
                {
                    ViewData["Message"] = "Your data have been added";
                    ModelState.Clear();
                }
                else
                {
                    ViewData["Message"] = "Your data have not been added";
                }
            }
            categorys.Category = new CategoryModel();
            categorys.CategoryList = perpageshowdata(1, 10);
            categorys.totalpage = pagecount(10);
            return View("AddCategory", categorys);
        }
        public ActionResult Multiedelete(int [] multidelete)
        {
            int i = 0;
            if(multidelete != null)
            {
                foreach (int multid in multidelete)
                {
                    CategoryManager.DeleteCategory(multid);
                    i++;
                }
            }
            if(multidelete.Length==i)
            {
                ViewData["Message"] = "Your data have  been deleted";
            }
            else
            {
                ViewData["Message"] = "Your data not have  been deleted";
            }
            AdminViewModel category = new AdminViewModel();
            category.CategoryList = perpageshowdata(1, 10);
            category.totalpage = pagecount(10);
            return View("AddCategory", category);
        }
        public ActionResult GetSingleCategory(int Id)
        {
            AdminViewModel category = new AdminViewModel();
            category.Category = CategoryManager.GetSingleCategory(Id);
            category.CategoryList = perpageshowdata(1, 10);
            category.totalpage = pagecount(10);
            return View("AddCategory", category);
        }
   
        public ActionResult DeleteCategory(string id)
        {
            AdminViewModel category = new AdminViewModel();
            int CategoryId=Int32.Parse(id);
            if(CategoryManager.DeleteCategory(CategoryId))
            {
                ViewData["Message"] = "Your data have  been deleted";
            }
            else
            {
                ViewData["Message"] = "Your data not have  been deleted";
            }
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
        // Pagination,search,single details, ajax
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
            AdminViewModel categorylist = new AdminViewModel();
            categorylist.CategoryList = perpageshowdata(pageindex, pagesize);
            categorylist.totalpage = pagecount(pagesize);
            var result = JsonConvert.SerializeObject(categorylist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Searchdata(string serachvalue)
        {
            List<CategoryModel> categorylist = CategoryManager.SearchCategory(serachvalue);
            var result = JsonConvert.SerializeObject(categorylist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
   
    }
}