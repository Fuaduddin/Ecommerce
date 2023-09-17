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
            var chargeid = provider.GetSingleDelivery(categoryId);
            return chargeid;
        }
        public static bool DeleteDeliveryCost(int categoryId)
        {
            DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
            var Categoriesd = provider.DeleteDeliveryCharge(categoryId);
            return Categoriesd;
        }
        public static List<DeliveryCharge> SearchDeliveryCost(string SearchKeyword)
        {
            DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
            var Categoriesd = provider.SearchDeliveryCost(SearchKeyword);
            return Categoriesd;
        }
        //Zone
        public static long AddNewZone(Zone area)
        {
            DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
            var Categorytid = provider.AddNewZone(area);
            return Categorytid;
        }
        public static List<viewZone> GetAllZone()
        {
            DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
            var Categoriesd = provider.ViewAllZone();
            return Categoriesd;
        }
        public static bool UpdateZone(Zone area)
        {
            DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
            var Categoriesd = provider.UpdateZone(area);
            return Categoriesd;
        }
        public static Zone GetSingleZone(int areaid)
        {
            DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
            var Categoriesd = provider.GetSingleZone(areaid);
            return Categoriesd;
        }
        public static bool DeleteZone(int areaid)
        {
            DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
            var Categoriesd = provider.DeleteZone(areaid);
            return Categoriesd;
        }
        public static List<Area> GetSingleZoneAllArea(int areaid)
        {
            DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
            var Categoriesd = provider.GetSingleZoneAllArea(areaid);
            return Categoriesd;
        }
        // Area
          public static long AddNewArea(Area zone)
          {
              DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
             var Categorytid = provider.AddNewArea(zone);
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
    }
}
