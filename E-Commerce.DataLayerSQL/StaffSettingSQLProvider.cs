using E_Commerce.Model;
using E_Commerce.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;

namespace E_Commerce.DataLayerSQL
{
    public class StaffSettingSQLProvider
    {
        //DeliveryMan
        public long AddNewDeliveryMan(DeliveryManModel deliveryman)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                long id = 0;
                SqlCommand command = new SqlCommand(StoredProcedured.AddNewDeliveryMan, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnvalue = new SqlParameter("@" + "DeliverManId", SqlDbType.Int);
                returnvalue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnvalue);
                foreach (var charge in deliveryman.GetType().GetProperties())
                {
                    if (charge.Name != "DeliverManId" && charge.Name != "PlaceName" && charge.Name != "DevisionName"
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
                    id = (int)command.Parameters["@DeliverManId"].Value;
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
        public List<DeliveryManModel> ViewAllDeliveryMan()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetAllDeliveryMan, connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    SqlDataReader Datareader = command.ExecuteReader();
                    List<DeliveryManModel> deliverychargeList = new List<DeliveryManModel>();
                    deliverychargeList = UtilityManager.DataReaderMapToList<DeliveryManModel>(Datareader);
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
        public bool DeleteDeliveryMan(int deliverychargeid)
        {
            bool IsDeleted = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.DeleteDeliveryMan, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@DeliverManId", deliverychargeid));
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
        public DeliveryManModel GetSingleDeliveryMan(int deliverychargeid)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetSingleDeliveryMan, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@DeliverManId", deliverychargeid));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DeliveryManModel charge = new DeliveryManModel();
                    charge = UtilityManager.DataReaderMap<DeliveryManModel>(reader);
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
        public bool UpdateDeliveryMan(DeliveryManModel deliveryman)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                bool updated = true;
                SqlCommand command = new SqlCommand(StoredProcedured.UpdateDeliveryMan, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (var charge in deliveryman.GetType().GetProperties())
                {
                    if (charge.Name != "PlaceName" && charge.Name != "DevisionName"
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
        // Supplier
        public long AddNewSupplier(SupplierModel Supplier)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                long id = 0;
                SqlCommand command = new SqlCommand(StoredProcedured.AddNewSupplier, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnvalue = new SqlParameter("@" + "SupplierId", SqlDbType.Int);
                returnvalue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnvalue);
                foreach (var charge in Supplier.GetType().GetProperties())
                {
                    if (charge.Name != "SupplierId" && charge.Name != "CategoryName"
                     && charge.Name != "UserName" && charge.Name != "UserPassword" && charge.Name != "UserType"
                     && charge.Name != "UserTotalLogin" && charge.Name != "UserLastLogin" && charge.Name != "User")
                    {
                        string name = charge.Name;
                        var value = charge.GetValue(Supplier, null);
                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@SupplierId"].Value;
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
        public List<SupplierModel> ViewAllSupplier()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetAllSupplier, connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    SqlDataReader Datareader = command.ExecuteReader();
                    List<SupplierModel> deliverychargeList = new List<SupplierModel>();
                    deliverychargeList = UtilityManager.DataReaderMapToList<SupplierModel>(Datareader);
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
        public bool DeleteSupplier(int areaid)
        {
            bool IsDeleted = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.DeleteSupplier, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SupplierId", areaid));
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
        public SupplierModel GetSingleSupplier(int areaid)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetSingleSupplier, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SupplierId", areaid));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    SupplierModel charge = new SupplierModel();
                    charge = UtilityManager.DataReaderMap<SupplierModel>(reader);
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
        public bool UpdateSupplier(SupplierModel supplier)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                bool updated = true;
                SqlCommand command = new SqlCommand(StoredProcedured.UpdateSupplier, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (var charge in supplier.GetType().GetProperties())
                {
                    if (charge.Name != "CategoryName" && charge.Name != "UserName" && charge.Name != "UserPassword"
                    && charge.Name != "UserType" && charge.Name != "UserTotalLogin" && charge.Name != "UserLastLogin"
                    && charge.Name != "User")
                    {
                        string name = charge.Name;
                        var value = charge.GetValue(supplier, null);
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
        //Admin
        public long AddNewAdmin(AdminModel admin)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                long id = 0;
                SqlCommand command = new SqlCommand(StoredProcedured.AddNewAdmin, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnvalue = new SqlParameter("@" + "AdminId", SqlDbType.Int);
                returnvalue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnvalue);
                foreach (var charge in admin.GetType().GetProperties())
                {
                    if (charge.Name != "AdminId" && charge.Name != "UserName" && charge.Name != "UserPassword"
                        && charge.Name != "UserType" && charge.Name != "UserTotalLogin" && charge.Name != "UserLastLogin"
                        && charge.Name != "User")
                    {
                        string name = charge.Name;
                        var value = charge.GetValue(admin, null);
                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@AdminId"].Value;
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
        public List<AdminModel> ViewAllAdmin()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetAllAdmin, connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    SqlDataReader Datareader = command.ExecuteReader();
                    List<AdminModel> deliverychargeList = new List<AdminModel>();
                    deliverychargeList = UtilityManager.DataReaderMapToList<AdminModel>(Datareader);
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
        public bool DeleteAdmin(int areaid)
        {
            bool IsDeleted = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.DeleteAdmin, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@AdminId", areaid));
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
        public bool UpdateAdmin(AdminModel admin)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                bool updated = true;
                SqlCommand command = new SqlCommand(StoredProcedured.UpdateAdmin, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (var charge in admin.GetType().GetProperties())
                {
                    if (charge.Name != "UserName" && charge.Name != "UserPassword"
                  && charge.Name != "UserType" && charge.Name != "UserTotalLogin" && charge.Name != "UserLastLogin"
                  && charge.Name != "User")
                    {
                        string name = charge.Name;
                        var value = charge.GetValue(admin, null);
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
        public AdminModel GetSingleAdmin(int areaid)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetSingleAdmin, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@AdminId", areaid));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    AdminModel charge = new AdminModel();
                    charge = UtilityManager.DataReaderMap<AdminModel>(reader);
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
