using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.DataLayerSQL;
using E_Commerce.Model;

namespace E_Commerce.BusinessLayer
{
    public class ProductManager
    {
        public static long AddNewProduct(ProductModel product)
        {
            ProductSQLProvider provider = new ProductSQLProvider();
            var products = provider.AddNewProduct(product);
            return products;
        }
        public static bool UpdateProduct(ProductModel product)
        {
            ProductSQLProvider provider = new ProductSQLProvider();
            var products = provider.UpdateProduct(product);
            return products;
        }
       public static bool DeleteProduct(int productid)
        {
            ProductSQLProvider provider = new ProductSQLProvider();
            var products = provider.DeleteProduct(productid);
            return products;
        }
        public static ProductModel GetSingleProduct(int productid)
        {
            ProductSQLProvider provider = new ProductSQLProvider();
            var products = provider.GetSingleProduct(productid);
            return products;
        }
        public static List<ProductModel> GetAllProduct()
        {
            ProductSQLProvider provider = new ProductSQLProvider();
            var products = provider.GetAllProduct();
            return products;
        }
    }
}
