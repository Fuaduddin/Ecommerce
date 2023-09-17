using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.DataLayerSQL;
using E_Commerce.Model;

namespace E_Commerce.BusinessLayer
{
    public class UserSettingManager
    {
        //USER
        public static long AddNewUser(UserModel user)
        {
            UserModelSQLProvider provider = new UserModelSQLProvider();
            var chargeid = provider.AddNewUser(user);
            return chargeid;
        }
        public static List<DeliveryCharge> GetAllDeliveryCost()
        {
            DeliverySettingsSQLProvider provider = new DeliverySettingsSQLProvider();
            var chargeid = provider.ViewAllDeliveryCharge();
            return chargeid;
        }
        public static bool CheckUserName(string UserName)
        {
            UserModelSQLProvider provider = new UserModelSQLProvider();
           bool chargeid = provider.CheckUser(UserName);
            return chargeid;
        }
        public static UserModel GetSingleUserForlogin(string UserName)
        {
            UserModelSQLProvider provider = new UserModelSQLProvider();
            var chargeid = provider.GetSingleUserForlogin(UserName);
            return chargeid;
        }
        public static bool DeleteUser(int categoryId)
        {
            UserModelSQLProvider provider = new UserModelSQLProvider();
            var Categoriesd = provider.DeleteUser(categoryId);
            return Categoriesd;
        }
        public static bool UpdateUser(UserModel user)
        {
            UserModelSQLProvider provider = new UserModelSQLProvider();
            var Categoriesd = provider.UpdateUser(user);
            return Categoriesd;
        }
    }
}
