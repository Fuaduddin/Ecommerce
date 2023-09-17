using E_Commerce.DataLayerSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Model;

namespace E_Commerce.BusinessLayer
{
   public class StaffSettingsManager
    {
        //DeliveryMan
        public static long AddNewDeliveryMan(DeliveryManModel deliveryman)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var chargeid = provider.AddNewDeliveryMan(deliveryman);
            return chargeid;
        }
        public static List<DeliveryManModel> GetAllDeliveryMan()
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var chargeid = provider.ViewAllDeliveryMan();
            return chargeid;
        }
        public static bool UpdateDeliveryMan(DeliveryManModel deliveryman)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var chargeid = provider.UpdateDeliveryMan(deliveryman);
            return chargeid;
        }
        public static DeliveryManModel GetSingleDeliveryMan(int categoryId)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var chargeid = provider.GetSingleDeliveryMan(categoryId);
            return chargeid;
        }
        public static bool DeleteDeliveryMan(int categoryId)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var Categoriesd = provider.DeleteDeliveryMan(categoryId);
            return Categoriesd;
        }
        //Supplier
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
        // Admin
        public static long AddNewAdmin(AdminModel Admin)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var Categorytid = provider.AddNewAdmin(Admin);
            return Categorytid;
        }
        public static List<AdminModel> GetAllAdmin()
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var Categoriesd = provider.ViewAllAdmin();
            return Categoriesd;
        }

        public static bool DeleteAdmin(int categoryId)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var Categoriesd = provider.DeleteAdmin(categoryId);
            return Categoriesd;
        }
        public static bool UpdateAdmin(AdminModel Admin)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var Categoriesd = provider.UpdateAdmin(Admin);
            return Categoriesd;
        }
        public static AdminModel GetSingleAdmin(int areaid)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var Categoriesd = provider.GetSingleAdmin(areaid);
            return Categoriesd;
        }
    }
}
