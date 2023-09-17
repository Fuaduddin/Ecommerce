using E_Commerce.Model;
using E_Commerce.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataLayerSQL
{
    public class UserModelSQLProvider
    {
        public long AddNewUser(UserModel user)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                long id = 0;
                SqlCommand command = new SqlCommand(StoredProcedured.AddUser, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnvalue = new SqlParameter("@" + "UserId", SqlDbType.Int);
                returnvalue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnvalue);
                foreach (var Categories in user.GetType().GetProperties())
                {
                    if (Categories.Name != "UserId")
                    {
                        string name = Categories.Name;
                        var value = Categories.GetValue(user, null);
                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@UserId"].Value;
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
        public UserModel GetSingleUserForlogin(string username)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetSingleUserForlogin, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@UserName", username));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    UserModel charge = new UserModel();
                    charge = UtilityManager.DataReaderMap<UserModel>(reader);
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
        public bool UpdateUserForLogin(UserModel user)
        {
            bool IsUpdated = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.UpdateUserForlogin, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (var Categories in user.GetType().GetProperties())
                {
                    if (Categories.Name != "UserType" && Categories.Name != "UserId"&& Categories.Name != "UserPassword")
                    {
                        string name = Categories.Name;
                        var value = Categories.GetValue(user, null);
                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
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

            }
            return IsUpdated;
        }
        public bool UpdateUser(UserModel user)
        {
            bool IsUpdated = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.UpdateUser, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (var Categories in user.GetType().GetProperties())
                {
                    if(Categories.Name == "UserName" || Categories.Name == "UserPassword" || Categories.Name == "UserId")
                    {
                        string name = Categories.Name;
                        var value = Categories.GetValue(user, null);
                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
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

            }
            return IsUpdated;
        }

        public bool DeleteUser(int subcategoryid)
        {
            bool IsDeleted = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.DeleteUser, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@UserId", subcategoryid));
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
        public bool CheckUser(string username)
        {
            bool IsExist = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetSingleUserForlogin, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@UserName", username));
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch 
                {
                    IsExist = false;
                   
                }
                finally
                {
                    connection.Close();
                }

                return IsExist;
            }
        }
    }
}
