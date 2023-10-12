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
        public static string GetSubCategorySearch = "Sp_GetSearchSubCategory";
        public static string GetSubcategorytotalproduct = "Sp_GetSubcategorytotalproduct";
        public static string GetAllSelectedSubCategory = "Sp_GetAllSelectedSubCategory";

        // Product

        public static string AddNewProduct = "SP_AddNewProduct";
        public static string UpdateProduct = "SP_UpdateProduct";
        public static string DeleteProduct = "SP_DeleteProduct";
        public static string GetSingleProduct = "SP_GetProduct";
        public static string GetAllProduct = "SP_GetAllProduct";
        public static string GetProductSearch = "Sp_GetSearchCategory";



        // Image Gallery

        public static string AddImageGallery = "SP_AddImageGallary";
        public static string UpdateImageGallery = "Sp_UpdateImageGallary";
        public static string DeleteImageGallery = "SP_DeleteImageGallary";
        public static string GetSingleImageGallery = "SP_GetSingleImageGallary";
        public static string GetSingleProductAllImage = "SP_GetSingleProductAllImage";

        // Delivery Charge
        public static string AddDeliveryCharge = "Sp_AddNewDeliveryCharge";
        public static string UpdateDeliveryCharge = "Sp_UpdateDeliveryCharge";
        public static string DeleteDeliveryCharge = "Sp_DeleteDeliveryCharge";
        public static string GetSingleDeliveryCharge = "Sp_GetSingleDeliveryCharge";
        public static string GetAllDeliveryCharge = "Sp_GetAllDeliveryCharge";
        public static string SearchDeliveryCharge = "Sp_SearchDeliveryCharge";

        // Zone
        public static string AddZone = "Sp_AddNewZone";
        public static string UpdateZone = "sp_UpdateZone";
        public static string DeleteZone = "Sp_DeleteZone";
        public static string GetSingleZone = "Sp_GetSingleZone";
        public static string GetAllZone = "Sp_GetAllZone";
        public static string GetSingleZoneAllArea = "Sp_GetSingleZoneAllArea";
        public static string SearchZone = "Sp_SearchZone";


        // Area
        public static string AddArea = "Sp_AddNewArea";
        public static string DeleteArea = "Sp_DeleteArea";
        public static string GetAllArea = "Sp_GetAllArea";
        //    public static string SearchArea = "Sp_SearchArea";

        // User
        public static string AddUser = "Sp_AddUserDetails";
        public static string DeleteUser = "Sp_DeleteUser";
        public static string UpdateUser = "Sp_UpdateUser";
        public static string GetSingleUser = "Sp_GetSingleUser";

        // Delivery Man  Details
        public static string AddNewDeliveryMan = "SP_AddNewDeliveryMan";
        public static string UpdateDeliveryMan = "SP_UpdateDeliveryMan";
        public static string DeleteDeliveryMan = "SP_DeleteDeliveryMan";
        public static string GetSingleDeliveryMan = "SP_GetSingleDeliveryMan";
        public static string GetAllDeliveryMan = "SP_GetAllDeliveryMan";
        public static string GetDeliveryManSearch = "Sp_GetDeliveryMan";

        // Supplier  Details
        public static string AddNewSupplier = "SP_AddNewSupplier";
        public static string UpdateSupplier = "SP_UpdateSupplier";
        public static string DeleteSupplier = "SP_DeleteSupplier";
        public static string GetSingleSupplier = "SP_GetSingleSupplier";
        public static string GetAllSupplier = "SP_GetAllSupplier";
        public static string GetSupplierSearch = "Sp_GetSupplier";

        // Admin  Details
        public static string AddNewAdmin = "SP_AddNewAdmin";
        public static string UpdateAdmin = "SP_UpdateAdmin";
        public static string DeleteAdmin = "SP_DeleteAdmin";
        public static string GetSingleAdmin = "SP_GetSingleAdmin";
        public static string GetAllAdmin = "SP_GetAllAdmin";
        public static string GetAdminSearch = "Sp_GetSearchAdmin";

        // Email
        public static string AddNewEmail = "SP_AddNewEmail";
        public static string UpdateEmail = "SP_UpdateEmail";
        public static string DeleteEmail = "SP_DeleteEmail";
        public static string GetSingleEmail = "SP_GetSingleEmail";
        public static string GetAllEmail = "SP_GetAllEmail";
        public static string GetEmail = "Sp_GetEmail";
        public static string SearchEmail = "Sp_SearchEmail";
        public static string FilterEmail = "Sp_FilterEmail";

        // Review
        public static string AddNewReview = "SP_AddNewReview";
        public static string UpdateReview = "SP_UpdateReview";
        public static string DeleteReview = "SP_DeleteReview";
        public static string GetSingleReview = "SP_GetSingleReview";
        public static string GetAllReview = "SP_GetAllReview";
        public static string GetSingleProductReview = "Sp_GetSingleProductReview";


        // Appointment
        public static string AddNewAppointment = "SP_AddNewAppointment";
        public static string UpdateAppointment = "SP_UpdateAppointment";
        public static string DeleteAppointment = "SP_DeleteAppointment";
        public static string GetSingleAppointment = "SP_GetSingleAppointment";
        public static string GetAllAppointment = "SP_GetAllAppointment";
        public static string GeAppointmentSearch = "Sp_GetSearchAppointment";
        public static string UpdateAppointmentSearch = "Sp_UpdateAppointmentSearch";

        // Login
        public static string GetSingleUserForlogin = "Sp_GetSingleUserForlogin";
        public static string UpdateUserForlogin = "Sp_UpdateUserForlogin";

        //Appointment Assignment
        public static string AddNewAppointmentAssignment = "SP_AddNewAppointmentAssignment";
        public static string UpdateAppointmentAssignment = "SP_UpdateAppointmentAssignment";
        public static string DeleteAppointmentAssignment = "SP_DeleteAppointmentAssignment";
        public static string GetSingleAppointmentAssignment = "SP_GetSingleAppointmentAssignment";
        public static string GetAllAppointmentAssignment = "SP_GetAllAppointmentAssignment";
        public static string GetAppointmentAssignmentSearch = "Sp_GetAppointmentAssignmentSearch";

        //Assignment Supplier
        public static string AddNewAssignmentSupplier = "SP_AddNewAssignmentSupplier";
        public static string UpdateAssignmentSupplier = "SP_UpdateAssignmentSupplier";
        public static string DeleteAssignmentSupplier = "SP_DeleteAssignmentSupplier";
        public static string GetSingleAssignmentSupplier = "SP_GetSingleAssignmentSupplier";
        public static string GetAllAssignmentSupplier = "SP_GetAllAssignmentSupplier";
        public static string GetAssignmentSupplierSearch = "Sp_GetAssignmentSupplierSearch";
        public static string GetAssignmentProduct = "Sp_GetAssignmentProduct";

        //Customer
        public static string AddNewCustomer = "SP_AddNewCustomer";
        public static string UpdateCustomer = "SP_UpdateCustomer";
        public static string DeleteCustomer = "SP_DeleteCustomer";
        public static string GetSingleCustomer = "SP_GetSingleCustomer";
        public static string GetAllCustomer = "SP_GetAllCustomer";

        // Supplier Dash Board
        public static string SupplierTotalCompleteAssign = "SP_SupplierTotalCompleteAssign";
        public static string SupplierTotalAssign = "SP_SupplierTotalAssign";
        public static string SupplierTotalDueAssign = "SP_SupplierTotalDueAssign";
        public static string ViewAllSupplierAssignAssign = "SP_ViewAllSupplierAssignAssign";
        public static string ViewAllCompleteSupplierAssign = "SP_ViewAllCompleteSupplierAssign";
        public static string DeleteSupplierAssignment = "SP_DeleteSupplierAssignment";
        public static string GetSIngleSupplierAssignment = "SP_GetSIngleSupplierAssignment";
        public static string UpdateSupplierAssignment = "SP_UpdateSupplierAssignment";

        // Admin Dash Board
        public static string AdminTotalCompleteAssign = "SP_AdminTotalCompleteAssign";
        public static string AdminTotalAssign = "SP_AdminTotalAssign";
        public static string AdminTotalDueAssign = "SP_AdminTotalDueAssign";
        public static string ViewAllAdminAssignAssign = "SP_ViewAllAdminAssignAssign";
        public static string DeleteAdminAssignment = "SP_DeleteAdminAssignment";
        public static string GetSIngleAdminAssignment = "SP_GetSIngleAdminAssignment";
        public static string UpdateAdminAssignment = "SP_UpdateAdminAssignment";

        //E-Commer web Manager
        public static string GetSubCategoryWiseProduct = "SP_GetSubCategoryWiseProduct";
        public static string GetLatestAllProduct = "SP_GetLatestAllProduct";


        // FAQ
        public static string AddNewFAQ = "SP_AddNewFAQ";
        public static string UpdateFAQ = "SP_UpdateFAQ";
        public static string DeleteFAQ = "SP_DeleteFAQ";
        public static string GetSingleFAQ = "SP_GetSingleFAQ";

        // Customer DashBoard
        public static string GetSingleCustomerOrder = "SP_GetSingleCustomerOrder";

        // Delivery Man Assignment
        public static string AddNewAssignDeliveryMan = "SP_AddNewAssignDeliveryMan";
        public static string DeleteAssignDeliveryMan = "SP_DeleteAssignDeliveryMan";
        public static string UpdateAssignDeliveryMan = "SP_UpdateAssignDeliveryMan";
        public static string GetAllAssignDeliveryMan = "SP_GetAllAssignDeliveryMan";
        public static string GetSingleOrderDetails = "SP_GetSingleOrderDetails";


        //Cart && Track Order && Payment && Order
        //public static string TrackOrder = "SP_TrackOrder";
        //public static string TrackOrder = "SP_TrackOrder";
        // Web 
        public static string AddNewOrder = "SP_AddNewOrder";
        public static string AddNewShipment = "SP_AddNewShipment";
        public static string AddNewOrderItem = "SP_AddNewOrderItem";
        public static string AddNewPayment = "SP_AddNewPayment";
        public static string GetSingleOrder = "SP_GetSingleOrder";
        public static string GetSingleShipment = "SP_GetSingleShipment";
        public static string GetSingleOrderItem = "SP_GetSingleOrderItem";
        public static string GetSinglePayment = "SP_GetSinglePayment";
        public static string DeleteOrder = "SP_DeleteOrder";
        public static string ADeleteShipment = "SP_DeleteShipment";
        public static string DeleteOrderItem = "SP_DeleteOrderItem";
        public static string DeletePayment = "SP_DeletePayment";

        public static string UpdateOrder = "SP_UpdateOrder";
        public static string UpdateShipment = "SP_UpdateShipment";
        public static string UpdatePayment = "SP_UpdatePayment";

        // Super Admin & Admin
        public static string GetAllCustomerOrder = "SP_GetAllCustomerOrder";
        public static string GetAllSingleOrder = "SP_GetAllSingleOrder";

        // Assign Delivery Man
        public static string AddNewDeliveryManAssign = "SP_AddNewDeliveryManAssign";
        public static string DeleteDeliveryManAssign = "SP_DeleteDeliveryManAssign";
        public static string UpdateDeliveryManAssign = "SP_UpdateDeliveryManAssign";
        public static string GetSingleDeliveryManAssign = "SP_GetSingleDeliveryManAssign";
        public static string GetAllDeliveryManAssign = "SP_GetAllDeliveryManAssign";

        // Delivery Man DashBoard
        public static string GetDeliveryManWiseAssign = "SP_GetDeliveryManWiseAssign";


        // Suplier and DeliveryMan Assignment Update
        public static string UpdateSupplierAssignmentUpdate = "SP_UpdateSupplierAssignmentUpdate";
        public static string UpdateDeliveryManAssignmentUpdate = "SP_UpdateDeliveryManAssignmentUpdate";
        public static string UpdateProductAmount = "SP_UpdateProductAmount";
        //public static string UpdateDeliveryManAssign = "SP_UpdateDeliveryManAssign";
        //public static string GetSingleDeliveryManAssign = "SP_GetSingleDeliveryManAssign";
        //public static string GetAllDeliveryManAssign = "SP_GetAllDeliveryManAssign";
    }

}
