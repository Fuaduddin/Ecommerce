using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace E_Commerce.Utility
{
    public class CommonUtility
    {
        public static string ConnectionString = ConfigurationManager.AppSettings["connectionString"].ToString();
    }

    public static class StoredProcedured
    {
        // Super Admin and Admin

        //Category

        public static string AddCategory = "SpCategory_AddCategory";
        public static string UpdateCategory = "sp_UpdateCategory";
        public static string DeleteCategory = "Sp_DeleteCategory";
        public static string GetSingleCategory = "Sp_GetSingleCategory";
        public static string GetAllCategory = "Sp_GetAllCategory";
        public static string GetCategorySearch = "Sp_GetSearchCategory";

        // SubCategory 

        public static string AddSubCategory = "Sp_AddSubcategory";
        public static string UpdateSubCategory = "Sp_UpdateSubcategory";
        public static string DeleteSubCategory = "Sp_DeleteSubcategory";
        public static string GetSingleSubCategory = "Sp_GetSingleSubcategory";
        public static string GetAllSubCategory = "Sp_GetAllSubcategory";
        public static string GetSubCategorySearch = "Sp_GetSearchCategory";
        public static string GetAllSelectedSubCategory = "Sp_GetAllSubcategorySelected";

        // Product

        public static string AddNewProduct = "SP_AddNewProduct";
        public static string UpdateProduct = "SP_UpdateProduct";
        public static string DeleteProduct = "SP_DeleteProduct";
        public static string GetSingleProduct = "SP_GetProduct";
        public static string GetAllProduct = "SP_GetAllProduct";
        public static string GetProductSearch = "Sp_GetSearchCategory";


        // Image Gallery

        public static string AddImageGallery = "SP_AddImageGallary";
        public static string UpdateImageGallery = "Sp_UpdateSubcategory";
        public static string DeleteImageGallery = "SP_DeleteImageGallary";
        public static string GetSingleImageGallery = "SP_GetSingleImageGallary";

        // Delivery Charge
        public static string AddDeliveryCharge = "AddNewDeliveryCharge";
        public static string UpdateDeliveryCharge = "Sp_UpdateDeliveryCharge";
        public static string DeleteDeliveryCharge = "Sp_DeleteDeliveryCharge";
        public static string GetSingleDeliveryCharge = "Sp_GetSingleDeliveryCharge";
        public static string GetAllDeliveryCharge = "Sp_GetAllDeliveryCharge";

        // Zone
        public static string AddZone = "AddNewZone";
        public static string UpdateZone = "sp_UpdateZone";
        public static string DeleteZone = "Sp_DeleteZone";
        public static string GetSingleZone = "Sp_GetSingleZone";
        public static string GetAllZone = "GetAllZone";
        public static string GetSingleZoneAllArea = "Sp_GetSingleZoneAllArea";

        // Area
        public static string AddArea = "Sp_AddNewArea";
        public static string DeleteArea = "Sp_DeleteArea";
        public static string GetAllArea = "Sp_GetAllArea";
    }

}
