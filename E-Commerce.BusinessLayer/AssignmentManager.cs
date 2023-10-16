using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.DataLayerSQL;
using E_Commerce.Model;

namespace E_Commerce.BusinessLayer
{
    public class AssignmentManager
    {
        //Assignment Appointment
        public static long AddNewAssignmentAppointment(AdminAssignmentModel charge)
        {
            AssignmentAppointSQLProvider provider = new AssignmentAppointSQLProvider();
            var chargeid = provider.AddNewAssignmentAppointment(charge);
            return chargeid;
        }
        public static List<AdminAssignmentModel> GetAllAssignmentAppointment()
        {
            AssignmentAppointSQLProvider provider = new AssignmentAppointSQLProvider();
            var chargeid = provider.ViewAllAssignmentAppointment();
            return chargeid;
        }
        public static bool UpdateAssignmentAppointment(AdminAssignmentModel category)
        {
            AssignmentAppointSQLProvider provider = new AssignmentAppointSQLProvider();
            var chargeid = provider.UpdateAssignmentAppointment(category);
            return chargeid;
        }
        public static AdminAssignmentModel GetSingleAssignmentAppointment(int categoryId)
        {
            AssignmentAppointSQLProvider provider = new AssignmentAppointSQLProvider();
            var chargeid = provider.GetSingleAssignmentAppointment(categoryId);
            return chargeid;
        }
        public static bool DeleteAssignmentAppointment(int categoryId)
        {
            AssignmentAppointSQLProvider provider = new AssignmentAppointSQLProvider();
            var Categoriesd = provider.DeleteAssignmentAppointment(categoryId);
            return Categoriesd;
        }
        //Assignment Supplier
        public static ProductModel GetSupplyProduct(int id)
        {
            AssignmentAppointSQLProvider provider = new AssignmentAppointSQLProvider();
            var Categorytid = provider.GetSingleProduct(id);
            return Categorytid;
        }
        public static long AddNewAssignmentSupplier(SupplierAssignmentModel area)
         {
          AssignmentAppointSQLProvider provider = new AssignmentAppointSQLProvider();
          var Categorytid = provider.AddNewAssignmentSupplier(area);
          return Categorytid;
         }
         public static List<ViewSupplierAssignmentModel> GetAllAssignmentSupplier()
         {
            AssignmentAppointSQLProvider provider = new AssignmentAppointSQLProvider();
           var Categoriesd = provider.ViewAllAssignmentSupplier();
           return Categoriesd;
         }
         public static bool UpdateAssignmentSupplier(SupplierAssignmentModel area)
         {
           AssignmentAppointSQLProvider provider = new AssignmentAppointSQLProvider();
          var Categoriesd = provider.UpdateAssignmentSupplier(area);
            return Categoriesd;
         }
        public static ViewSupplierAssignmentModel GetSingleAssignmentSupplier(int areaid)
         {
          AssignmentAppointSQLProvider provider = new AssignmentAppointSQLProvider();
          var Categoriesd = provider.GetSingleAssignmentSupplier(areaid);
            return Categoriesd;
         }
         public static bool DeleteAssignmentSupplier(int areaid)
         {
          AssignmentAppointSQLProvider provider = new AssignmentAppointSQLProvider();
          var Categoriesd = provider.DeleteAssignmentSupplier(areaid);
             return Categoriesd;
         }
         public static List<Area> GetSingleZoneAllArea(int areaid)
         {
             DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
             var Categoriesd = provider.GetSingleZoneAllArea(areaid);
             return Categoriesd;
         }
        // Indivitual Assignment Details
        //Admin
         public static List<AdminAssignmentModel> ViewAllAssingment(int adminid, int assignmentupdate)
         {
            AssignmentAppointSQLProvider provider = new AssignmentAppointSQLProvider();
            var Categorytid = provider.ViewAllAssingment(adminid, assignmentupdate);
            return Categorytid;
         }
        public static List<Area> GetAllArea()
        {
            DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
            var Categoriesd = provider.ViewAllArea();
            return Categoriesd;
        }

      public static bool DeleteArea(int categoryId)
       {
         DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
         var Categoriesd = provider.DeleteArea(categoryId);
         return Categoriesd;
      }


        // Assignment Delivery Man
        public static long AddNewAssignmentDeliveryMan(DeliveryManAssignmentModel DeliveryMan)
        {
            AssignmentAppointSQLProvider provider = new AssignmentAppointSQLProvider();
            var chargeid = provider.AddNewAssignmentDeliveryMan(DeliveryMan);
            return chargeid;
        }
        public static List<DeliveryManAssignmentModel> GetAllAssignmentDeliveryMan()
        {
            AssignmentAppointSQLProvider provider = new AssignmentAppointSQLProvider();
            var chargeid = provider.GetAllAssignmentDeliveryMan();
            return chargeid;
        }
        public static bool UpdateAssignmentDeliveryMan(DeliveryManAssignmentModel category)
        {
            AssignmentAppointSQLProvider provider = new AssignmentAppointSQLProvider();
            var chargeid = provider.UpdateAssignmentDeliveryMan(category);
            return chargeid;
        }
        public static DeliveryManAssignmentModel GetSingleAssignmentDeliveryMant(int categoryId)
        {
            AssignmentAppointSQLProvider provider = new AssignmentAppointSQLProvider();
            var chargeid = provider.GetSingleAssignmentDeliveryMant(categoryId);
            return chargeid;
        }
        public static bool DeleteAssignmentDeliveryMant(int categoryId)
        {
            AssignmentAppointSQLProvider provider = new AssignmentAppointSQLProvider();
            var Categoriesd = provider.DeleteAssignmentDeliveryMant(categoryId);
            return Categoriesd;
        }
        public static DeliveryManAssignmentModel GetDeliveryManWiseAssign(int categoryId)
        {
            AssignmentAppointSQLProvider provider = new AssignmentAppointSQLProvider();
            var Categoriesd = provider.GetDeliveryManWiseAssign(categoryId);
            return Categoriesd;
        }

        // Supplier and DeliveryMan Assignment Update
        //public static bool UpdateSupplierAssignmentDetails(ViewSupplierAssignmentModel Supplier)
        //{
        //    AssignmentAppointSQLProvider provider = new AssignmentAppointSQLProvider();
        //    var Categoriesd = provider.UpdateAssignmentSupplierUpdate(Supplier);
        //    return Categoriesd;
        //}
        // Supplier and DeliveryMan Assignment Update
        //public static bool UpdateProductAmount(int categoryId)
        //{
        //    AssignmentAppointSQLProvider provider = new AssignmentAppointSQLProvider();
        //    var Categoriesd = provider.UpdateSupplierAssignmentDetails(categoryId);
        //    return Categoriesd;
        //}
    }
}
