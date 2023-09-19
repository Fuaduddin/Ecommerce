using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.DataLayerSQL;
using E_Commerce.Model;

namespace E_Commerce.BusinessLayer
{
    public class CustomerManager
    {
        public static long AddNewCustomer(CustomerModel customer)
        {
            CustomerSQLProvider provider = new CustomerSQLProvider();
            var Categorytid = provider.AddNewCustomer(customer);
            return Categorytid;
        }
        public static List<CustomerModel> GetAllCustomer()
        {
            CustomerSQLProvider provider = new CustomerSQLProvider();
            var Categoriesd = provider.ViewAllCustomer();
            return Categoriesd;
        }
        public static bool UpdateCustomer(CustomerModel category)
        {
            CustomerSQLProvider provider = new CustomerSQLProvider();
            var Categoriesd = provider.UpdateCustomer(category);
            return Categoriesd;
        }
        public static CustomerModel GetSingleCustomer(int categoryId)
        {
            CustomerSQLProvider provider = new CustomerSQLProvider();
            var Categoriesd = provider.GetSingleCustomer(categoryId);
            return Categoriesd;
        }
        public static bool DeleteCustomer(int categoryId)
        {
            CustomerSQLProvider provider = new CustomerSQLProvider();
            var Categoriesd = provider.DeleteCustomer(categoryId);
            return Categoriesd;
        }

        //public static List<CategoryModel> SearchCustomer(string serachvalue)
        //{
        //    CustomerSQLProvider provider = new CustomerSQLProvider();
        //    var Categoriesd = provider.SearchCategory(serachvalue);
        //    return Categoriesd;
        //}
    }
}
