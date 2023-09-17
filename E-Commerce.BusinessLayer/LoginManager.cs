using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.DataLayerSQL;
using E_Commerce.Model;

namespace E_Commerce.BusinessLayer
{
   public class LoginManager
    {
        public static UserModel Login(string username)
        {
            UserModelSQLProvider provider = new UserModelSQLProvider();
            var Categoriesd = provider.GetSingleUserForlogin(username);
            return Categoriesd;
        }
        public static bool UpdateUser(UserModel user)
        {
            UserModelSQLProvider provider = new UserModelSQLProvider();
            var Categoriesd = provider.UpdateUserForLogin(user);
            return Categoriesd;
        }
        public static AdminModel GetAdminDetails(int id)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var Categoriesd = provider.GetSingleAdmin(id);
            return Categoriesd;
        }
        public static DeliveryManModel GetDeliveryManDetails(int id)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
              var Categoriesd = provider.GetSingleDeliveryMan(id);
            return Categoriesd;
        }
        public static SupplierModel GetSupplierDetails(int id)
        {
            StaffSettingSQLProvider provider = new StaffSettingSQLProvider();
            var Categoriesd = provider.GetSingleSupplier(id);
            return Categoriesd;
        }

    }
}
