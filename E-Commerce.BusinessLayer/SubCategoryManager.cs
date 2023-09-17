using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.DataLayerSQL;
using E_Commerce.DataLayerSQL.Properties;
using E_Commerce.Model;

namespace E_Commerce.BusinessLayer
{
    public class SubCategoryManager
    {
        public static long AddSubCategory(SubCategoryModel subcategory)
        {
            SubCategorySQLProvicer Provider = new SubCategorySQLProvicer();
            var subcategoryid = Provider.AddSubcategory(subcategory);
            return subcategoryid;
        }

        public static bool UpdateSubCategory(SubCategoryModel SubCategory)
        {
            SubCategorySQLProvicer provider = new SubCategorySQLProvicer();
            var data = provider.UpdateSubCategory(SubCategory);
            return data;
        }
        public static List<viewsubcategory> GetAllSubCategory()
        {
            SubCategorySQLProvicer provider = new SubCategorySQLProvicer();
            var data = provider.ViewAllSubCategory();
            return data;
        }
        public static SubCategoryModel GetSingleSubCategory( int id)
        {
            SubCategorySQLProvicer provider = new SubCategorySQLProvicer();
            var data = provider.GetSingleSubCategory(id);
            return data;
        }
   
        public static bool DeleteSubCategory(int id)
        {
            SubCategorySQLProvicer provider = new SubCategorySQLProvicer();
            var data = provider.DeleteSubCategory(id);
            return data;
        }
       public static int GettotalProduct(int id)
         {
          SubCategorySQLProvicer provider = new SubCategorySQLProvicer();
            var data = provider.GettotalProduct(id);
           return data;
       }
        public static List<SubCategoryModel> GetAllSelectedSubCategory(int id)
        {
            SubCategorySQLProvicer provider = new SubCategorySQLProvicer();
            var data = provider.GetAllSelectedSubCategory(id);
            return data;
        }
        public static List<viewsubcategory> SearchSubCategory(string SearchKeyword)
        {
            SubCategorySQLProvicer provider = new SubCategorySQLProvicer();
            var data = provider.SearchSubCategory(SearchKeyword);
            return data;
        }
    }
}
