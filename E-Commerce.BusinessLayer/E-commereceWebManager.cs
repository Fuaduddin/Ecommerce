using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.DataLayerSQL;
using E_Commerce.Model;

namespace E_Commerce.BusinessLayer
{
    public class E_commereceWebManager
    {
        public static List<ProductModel> GetSubAllProduct(int id)
        {
            E_commereceWebSQLProvider provider = new E_commereceWebSQLProvider();
            var Categoriesd = provider.GetSubAllProduct(id);
            return Categoriesd;
        }
       public static List<ProductModel> GetLatestAllProduct()
        {
           E_commereceWebSQLProvider provider = new E_commereceWebSQLProvider();
            var Categoriesd = provider.GetLatestAllProduct();
            return Categoriesd;
        }
        //public static SupplierModel GetSupplierDetails(int id)
       // {
       //     E_commereceWebSQLProvider provider = new E_commereceWebSQLProvider();
        //    var Categoriesd = provider.GetSingleSupplier(id);
        //    return Categoriesd;
       // }
    }
}
