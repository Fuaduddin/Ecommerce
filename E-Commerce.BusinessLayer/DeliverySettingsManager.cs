using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.DataLayerSQL;
using E_Commerce.Model;

namespace E_Commerce.BusinessLayer
{
    public class DeliverySettingsManager
    {
        //DeliveryCost
        public static long AddNewDeliveryCost(DeliveryCharge charge)
        {
            DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
            var chargeid = provider.AddNewDeliveryDeliveryCharge(charge);
            return chargeid;
        }
        public static List<DeliveryCharge> GetAllDeliveryCost()
        {
            DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
            var chargeid = provider.ViewAllDeliveryCharge();
            return chargeid;
        }
        public static bool UpdateDeliveryCost(DeliveryCharge category)
        {
            DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
            var chargeid = provider.UpdateDeliveryCharge(category);
            return chargeid;
        }
        public static DeliveryCharge GetSingleDeliveryCost(int categoryId)
        {
            DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
            var chargeid = provider.GetSingleCategory(categoryId);
            return chargeid;
        }
        public static bool DeleteDeliveryCost(int categoryId)
        {
            DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
            var Categoriesd = provider.DeleteDeliveryCharge(categoryId);
            return Categoriesd;
        }
        //Area
        public static long AddNewArea(Area area)
        {
            DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
            var Categorytid = provider.AddNewArea(area);
            return Categorytid;
        }
        public static List<Area> GetAllArea()
        {
            DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
            var Categoriesd = provider.ViewAllArea();
            return Categoriesd;
        }
        public static bool UpdateArea(Area area)
        {
            DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
            var Categoriesd = provider.UpdateArea(area);
            return Categoriesd;
        }
        public static Area GetSingleArea(int areaid)
        {
            DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
            var Categoriesd = provider.GetSingleArea(areaid);
            return Categoriesd;
        }
        public static bool DeleteArea(int areaid)
        {
            DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
            var Categoriesd = provider.DeleteArea(areaid);
            return Categoriesd;
        }
        // All Zone
        public static long AddNewZone(CategoryModel category)
        {
            CategorySQLProvider provider = new CategorySQLProvider();
            var Categorytid = provider.AddNewCategory(category);
            return Categorytid;
        }
        public static List<CategoryModel> GetAllZone()
        {
            CategorySQLProvider provider = new CategorySQLProvider();
            var Categoriesd = provider.ViewAllCategory();
            return Categoriesd;
        }
        public static bool UpdateZone(CategoryModel category)
        {
            CategorySQLProvider provider = new CategorySQLProvider();
            var Categoriesd = provider.UpdateCategory(category);
            return Categoriesd;
        }
        public static CategoryModel GetSingleZone(int categoryId)
        {
            CategorySQLProvider provider = new CategorySQLProvider();
            var Categoriesd = provider.GetSingleCategory(categoryId);
            return Categoriesd;
        }
        public static bool DeleteZone(int categoryId)
        {
            CategorySQLProvider provider = new CategorySQLProvider();
            var Categoriesd = provider.DeleteCategory(categoryId);
            return Categoriesd;
        }
    }
}
