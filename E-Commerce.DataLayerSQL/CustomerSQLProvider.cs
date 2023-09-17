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
    public class CustomerSQLProvider
    {
        public long AddNewCustomer(CustomerModel customer)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                long id = 0;
                SqlCommand command = new SqlCommand(StoredProcedured.AddNewCustomer, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnvalue = new SqlParameter("@" + "CustomerId", SqlDbType.Int);
                returnvalue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnvalue);
                foreach (var charge in customer.GetType().GetProperties())
                {
                    if (charge.Name != "CustomerId" && charge.Name != "PlaceName" && charge.Name != "DevisionName"
                    && charge.Name != "UserName" && charge.Name != "UserPassword" && charge.Name != "UserType"
                    && charge.Name != "UserTotalLogin" && charge.Name != "UserLastLogin" && charge.Name != "User")
                    {
                        string name = charge.Name;
                        var value = charge.GetValue(customer, null);
                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@CustomerId"].Value;
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception Adding Data. " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return id;
            }
        }
    }
}
