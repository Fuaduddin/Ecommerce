using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.DataLayerSQL;
using E_Commerce.Model;


namespace E_Commerce.BusinessLayer
{
    public class DashBoardManager
    {
        // supplier
        public static List<ViewSupplierAssignmentModel> ViewAssignmentAssginment(int id)
        {
            SupplierDeliveryManDashBoardSQLProvider provider = new SupplierDeliveryManDashBoardSQLProvider();
            var Categorytid = provider.ViewAssignmentAssginment(id);
            return Categorytid;
        }
        public static List<ViewSupplierAssignmentModel> ViewAllCompleteAssignment(int id)
        {
            SupplierDeliveryManDashBoardSQLProvider provider = new SupplierDeliveryManDashBoardSQLProvider();
            var Categoriesd = provider.ViewAllCompleteAssignment(id);
            return Categoriesd;
        }
        public static int GettotalCompleteAssing(int id)
        {
            SupplierDeliveryManDashBoardSQLProvider provider = new SupplierDeliveryManDashBoardSQLProvider();
            var data = provider.GettotalCompleteAssing(id);
            return data;
        }
        public static int GettotalDueAssing(int id)
        {
            SupplierDeliveryManDashBoardSQLProvider provider = new SupplierDeliveryManDashBoardSQLProvider();
            var data = provider.GettotalDueAssing(id);
            return data;
        }
        public static int GettotalAssignAssing(int id)
        {
            SupplierDeliveryManDashBoardSQLProvider provider = new SupplierDeliveryManDashBoardSQLProvider();
            var data = provider.GettotalAssignAssing(id);
            return data;
        }
        public static ViewSupplierAssignmentModel GetSingleSupplierAssing(int id)
        {
            SupplierDeliveryManDashBoardSQLProvider provider = new SupplierDeliveryManDashBoardSQLProvider();
            var data = provider.GetSingleSupplierAssing(id);
            return data;
        }
        public static bool UpdateSupplierAssing(int id, int status, int totalcoast) 
        {
            SupplierDeliveryManDashBoardSQLProvider provider = new SupplierDeliveryManDashBoardSQLProvider();
            var data = provider.UpdateSupplierAssing(id, status, totalcoast);
            return data;
        }
        // Admin
        public static List<ViewSupplierAssignmentModel> ViewAssignmentAppointment(int id)
        {
            AdninandSuperAdminDashBoardSQLProvider provider = new AdninandSuperAdminDashBoardSQLProvider();
            var Categorytid = provider.ViewAssignmentAppointment(id);
            return Categorytid;
        }
        public static List<ViewSupplierAssignmentModel> ViewAllCompleteAppointment(int id)
        {
            AdninandSuperAdminDashBoardSQLProvider provider = new AdninandSuperAdminDashBoardSQLProvider();
            var Categoriesd = provider.ViewAllCompleteAppointment(id);
            return Categoriesd;
        }
        public static int GettotalCompleteAppointment(int id)
        {
            AdninandSuperAdminDashBoardSQLProvider provider = new AdninandSuperAdminDashBoardSQLProvider();
            var data = provider.GettotalCompleteAppointment(id);
            return data;
        }
        public static int GettotalDueAppointment(int id)
        {
            AdninandSuperAdminDashBoardSQLProvider provider = new AdninandSuperAdminDashBoardSQLProvider();
            var data = provider.GettotalDueAppointment(id);
            return data;
        }
        public static int GettotalAssignAppointment(int id)
        {
            AdninandSuperAdminDashBoardSQLProvider provider = new AdninandSuperAdminDashBoardSQLProvider();
            var data = provider.GettotalAssignAppointment(id);
            return data;
        }
        public static ViewSupplierAssignmentModel GetSingleAdminAppointment(int id)
        {
            AdninandSuperAdminDashBoardSQLProvider provider = new AdninandSuperAdminDashBoardSQLProvider();
            var data = provider.GetSingleSupplierAppointment(id);
            return data;
        }
        public static bool UpdateAdminAppointment(int id, int status, DateTime fixeddate)
        {
            AdninandSuperAdminDashBoardSQLProvider provider = new AdninandSuperAdminDashBoardSQLProvider();
            var data = provider.UpdateAdminAppointment(id, status, fixeddate);
            return data;
        }
        //Delivery Man
        public static long AddNewSupplier(SupplierModel Supplier)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var Categorytid = provider.AddNewSupplier(Supplier);
            return Categorytid;
        }
        public static List<SupplierModel> GetAllSupplier()
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var Categoriesd = provider.ViewAllSupplier();
            return Categoriesd;
        }
        public static bool UpdateSupplier(SupplierModel Supplier)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var Categoriesd = provider.UpdateSupplier(Supplier);
            return Categoriesd;
        }
        public static SupplierModel GetSingleSupplier(int areaid)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var Categoriesd = provider.GetSingleSupplier(areaid);
            return Categoriesd;
        }
        public static bool DeleteSupplier(int areaid)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var Categoriesd = provider.DeleteSupplier(areaid);
            return Categoriesd;
        }
    }
}
