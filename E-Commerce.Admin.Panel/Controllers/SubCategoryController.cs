using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce.Model;
using E_Commerce.BusinessLayer;
using Newtonsoft.Json;

namespace E_Commerce.Admin.Panel.Controllers
{
    [Authorize]
    public class SubCategoryController : Controller
    {
        // GET: SubCategory
        public ActionResult AddSubCategory()
        {
            AdminViewModel subcategory = new AdminViewModel();
            subcategory.SubCategory = new SubCategoryModel();
            subcategory.totalpage = pagecount(10);
            subcategory.viewsubcategorydetails = perpageshowdata(1,10);
            //subcategory.viewsubcategorydetails = SubCategoryManager.GetAllSubCategory();
            subcategory.CategoryList = CategoryManager.GetAllCategory();
            return View(subcategory);
        }
        [HttpPost]
        public ActionResult AddSubCategory(SubCategoryModel Subcategory)
        {
            AdminViewModel subcategory = new AdminViewModel();
            if (Subcategory.SubCategoryId >0)
            {
                if (SubCategoryManager.UpdateSubCategory(Subcategory))
                {
                    ModelState.Clear();
                    ViewData["Message"] = "Your data have been Updated";
                }
                else
                {
                    ViewData["Message"] = "Your data have not been Updated";
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    if (SubCategoryManager.AddSubCategory(Subcategory)>0)
                    {
                        ModelState.Clear();
                        ViewData["Message"] = "Your data have been added"; 
                    }
                    else
                    {
                        ViewData["Message"] = "Your data have not been added";
                    }
                    subcategory.SubCategory = new SubCategoryModel();
                }
            }
            subcategory.CategoryList = CategoryManager.GetAllCategory();
            subcategory.viewsubcategorydetails = SubCategoryManager.GetAllSubCategory();
            return View("AddSubCategory",subcategory);
        }
        public ActionResult GetAllSubCategory()
        {
            AdminViewModel subcategory = new AdminViewModel();
            subcategory.viewsubcategorydetails = SubCategoryManager.GetAllSubCategory();
            subcategory.CategoryList = CategoryManager.GetAllCategory();
            return View("AddSubCategory", subcategory);
        }
        public ActionResult GetSingleSubCategory(int id)
        {
            AdminViewModel subcategory = new AdminViewModel();
            subcategory.viewsubcategorydetails = SubCategoryManager.GetAllSubCategory();
            subcategory.SubCategory = SubCategoryManager.GetSingleSubCategory(id);
            subcategory.CategoryList = CategoryManager.GetAllCategory();
            return View("AddSubCategory", subcategory);
        }
        public ActionResult DeleteSubCategory(int id)
        {
            AdminViewModel subcategory = new AdminViewModel();
            if (SubCategoryManager.DeleteSubCategory(id))
            {
                ViewData["Message"] = "Your data have been Deleted";
            }
            else
            {
                ViewData["Message"] = "Your data have not been Deleted";
            }
            subcategory.viewsubcategorydetails = SubCategoryManager.GetAllSubCategory();
            subcategory.CategoryList = CategoryManager.GetAllCategory();
            return View("AddSubCategory", subcategory);
        }
        [HttpPost]
        public ActionResult Multiedelete(int[] multidelete)
        {
            int i = 0;
            AdminViewModel category = new AdminViewModel();
            if (multidelete != null)
            {
                foreach (int multid in multidelete)
                {
                    SubCategoryManager.DeleteSubCategory(multid);
                    i++;
                }
            }
          if(multidelete.Length==i)
            {
                ViewData["Message"] = "Your data have been Deleted";
            }
          else
            {
                ViewData["Message"] = "Your data have not been Deleted";
                //category.viewsubcategorydetails = perpageshowdata(1, 10);
                //category.totalpage = pagecount(10);
            }
            category.viewsubcategorydetails = perpageshowdata(1, 10);
            category.totalpage = pagecount(10);
            //RedirectToActionPermanent();
            return View("AddSubCategory", category);
        }
        public int pagecount(int perpagedata)
        {
            IEnumerable<viewsubcategory> subcategory = SubCategoryManager.GetAllSubCategory();
            return Convert.ToInt32(Math.Ceiling(subcategory.Count() / (double)perpagedata));
        }

        public List<viewsubcategory> perpageshowdata(int pageindex, int pagesize)
        {
            IEnumerable<viewsubcategory> subcategory = SubCategoryManager.GetAllSubCategory();
            return subcategory.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }

        public JsonResult Getpaginatiotabledata(int pageindex, int pagesize)
        {
            List<viewsubcategory> subcategorylist = perpageshowdata(pageindex, pagesize);
            var result = JsonConvert.SerializeObject(subcategorylist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetsingleSubcategorydetails(int serachvalue)
        {
            AdminViewModel subcategory = new AdminViewModel();
            subcategory.SubCategory= SubCategoryManager.GetSingleSubCategory(serachvalue);
            subcategory.Category=CategoryManager.GetSingleCategory(subcategory.SubCategory.CategoryId);
            subcategory.TotalProduct = SubCategoryManager.GettotalProduct(serachvalue);
            var result = JsonConvert.SerializeObject(subcategory);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchSubCategory(string SearchKeyword)
        {
            List<viewsubcategory> categorylist = SubCategoryManager.SearchSubCategory(SearchKeyword);
            var result = JsonConvert.SerializeObject(categorylist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}