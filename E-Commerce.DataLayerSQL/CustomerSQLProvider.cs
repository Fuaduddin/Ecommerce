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
        public List<CustomerModel> ViewAllCustomer()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetAllCustomer, connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    SqlDataReader Datareader = command.ExecuteReader();
                    List<CustomerModel> deliverychargeList = new List<CustomerModel>();
                    deliverychargeList = UtilityManager.DataReaderMapToList<CustomerModel>(Datareader);
                    return deliverychargeList;
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception Adding Data. " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public bool DeleteCustomer(int deliverychargeid)
        {
            bool IsDeleted = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.DeleteCustomer, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@CustomerId", deliverychargeid));
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    IsDeleted = false;
                    throw new Exception("Exception Adding Data. " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                return IsDeleted;
            }
        }
        public bool UpdateCustomer(CustomerModel deliveryman)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                bool updated = true;
                SqlCommand command = new SqlCommand(StoredProcedured.UpdateCustomer, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (var charge in deliveryman.GetType().GetProperties())
                {
                    if (charge.Name != "CustomerId" && charge.Name != "PlaceName" && charge.Name != "DevisionName"
                     && charge.Name != "UserName" && charge.Name != "UserPassword" && charge.Name != "UserType"
                     && charge.Name != "UserTotalLogin" && charge.Name != "UserLastLogin" && charge.Name != "User")
                    {
                        string name = charge.Name;
                        var value = charge.GetValue(deliveryman, null);
                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    updated = false;
                    throw new Exception("Exception Adding Data. " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return updated;
            }
        }
        public CustomerModel GetSingleCustomer(int deliverychargeid)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetSingleCustomer, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@CustomerId", deliverychargeid));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    CustomerModel charge = new CustomerModel();
                    charge = UtilityManager.DataReaderMap<CustomerModel>(reader);
                    return charge;
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception Adding Data. " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
