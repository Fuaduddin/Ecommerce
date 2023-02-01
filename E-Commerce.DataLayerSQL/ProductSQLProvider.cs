using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Model;
using E_Commerce.Utility;

namespace E_Commerce.DataLayerSQL
{
    public class ProductSQLProvider
    {
        public long AddNewProduct(ProductModel product)
        {
            long id = 0;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.AddNewProduct, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnvalue = new SqlParameter("@" + "ProductId", SqlDbType.Int);
                returnvalue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnvalue);
                foreach (var Product in product.GetType().GetProperties())
                {
                    if (Product.Name != "ProductId")
                    {
                        var name = Product.Name;
                        var value = Product.GetValue(product, null);
                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@ProductId"].Value;
                }
                catch (Exception e)
                {

                    throw new Exception("Message" + e);
                }
                finally
                {
                    connection.Close();
                }
            }

            return id;
        }

        public bool UpdateProduct(ProductModel product)
        {
            bool IsUpdated = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.UpdateProduct, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (var Product in product.GetType().GetProperties())
                {
                    var name = Product.Name;
                    var value = Product.GetValue(Product, null);
                    command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                }

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    IsUpdated = false;
                    throw new Exception("Message" + e);
                }
                finally
                {
                    connection.Close();
                }

                return IsUpdated;
            }
            //public bool DeleteProduct(int productid)
            //{

            //}
            //public List<ProductModel> GetAllProduct()
            //{

            //}
            //public ProductModel GetSingleProduct(int productid)
            //{

            //}
        }
    }
}