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
    public class SubCategoryController : Controller
    {
        // GET: SubCategory
        public ActionResult AddSubCategory()
        {
            AdminViewModel subcategory = new AdminViewModel();
            subcategory.SubCategory = new SubCategoryModel();
            subcategory.viewsubcategorydetails = SubCategoryManager.GetAllSubCategory();
            subcategory.CategoryList = CategoryManager.GetAllCategory();
            return View(subcategory);
        }
        [HttpPost]
        public ActionResult AddSubCategory(SubCategoryModel Subcategory)
        {
            if (Subcategory.SubCategoryId >0)
            {
                SubCategoryManager.UpdateSubCategory(Subcategory);
                AdminViewModel subcategory = new AdminViewModel();
                subcategory.CategoryList = CategoryManager.GetAllCategory();
                subcategory.viewsubcategorydetails = SubCategoryManager.GetAllSubCategory();
                return View(subcategory);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    SubCategoryManager.AddSubCategory(Subcategory);
                    AdminViewModel subcategory = new AdminViewModel();
                    subcategory.CategoryList = CategoryManager.GetAllCategory();
                    subcategory.viewsubcategorydetails = SubCategoryManager.GetAllSubCategory();
                    return View(subcategory);
                }
            }
            return View();
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
            if (SubCategoryManager.DeleteSubCategory(id))
            {
                AdminViewModel subcategory = new AdminViewModel();
                subcategory.viewsubcategorydetails = SubCategoryManager.GetAllSubCategory();
                subcategory.CategoryList = CategoryManager.GetAllCategory();
                return View("AddSubCategory", subcategory);
            }

            return View("AddSubCategory");
        }
        public int pagecount(int perpagedata)
        {
            IEnumerable<viewsubcategory> category = SubCategoryManager.GetAllSubCategory();
            return Convert.ToInt32(Math.Ceiling(category.Count() / (double)perpagedata));
        }

        public List<viewsubcategory> perpageshowdata(int pageindex, int pagesize)
        {
            IEnumerable<viewsubcategory> category = SubCategoryManager.GetAllSubCategory();
            return category.Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        }

        public JsonResult Getpaginatiotabledata(int pageindex, int pagesize)
        {
            List<viewsubcategory> categorylist = perpageshowdata(pageindex, pagesize);
            var result = JsonConvert.SerializeObject(categorylist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}