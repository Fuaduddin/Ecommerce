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
    public class SupplierDeliveryManDashBoardSQLProvider
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
        public List<ViewSupplierAssignmentModel> ViewAssignmentAssginment(int id)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.ViewAllSupplierAssignAssign, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SupplierId", id));
                try
                {
                    connection.Open();
                    SqlDataReader Datareader = command.ExecuteReader();
                    List<ViewSupplierAssignmentModel> deliverychargeList = new List<ViewSupplierAssignmentModel>();
                    deliverychargeList = UtilityManager.DataReaderMapToList<ViewSupplierAssignmentModel>(Datareader);
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
        public List<ViewSupplierAssignmentModel> ViewAllCompleteAssignment(int id)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.ViewAllCompleteSupplierAssign, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SupplierId", id));
                try
                {
                    connection.Open();
                    SqlDataReader Datareader = command.ExecuteReader();
                    List<ViewSupplierAssignmentModel> deliverychargeList = new List<ViewSupplierAssignmentModel>();
                    deliverychargeList = UtilityManager.DataReaderMapToList<ViewSupplierAssignmentModel>(Datareader);
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
        public int GettotalCompleteAssing(int id)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.SupplierTotalCompleteAssign, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SupplierId", id));
                try
                {
                    connection.Open();
                    int category = command.ExecuteNonQuery();
                    return category;
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
        public int GettotalDueAssing(int id)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.SupplierTotalDueAssign, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SupplierId", id));
                try
                {
                    connection.Open();
                    int category = command.ExecuteNonQuery();
                    return category;
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
        public int GettotalAssignAssing(int id)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.SupplierTotalDueAssign, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SupplierId", id));
                try
                {
                    connection.Open();
                    int category = command.ExecuteNonQuery();
                    return category;
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
        public ViewSupplierAssignmentModel GetSingleSupplierAssing(int id)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetSingleAssignmentSupplier, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@AssigentmentSupplierId", id));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    ViewSupplierAssignmentModel charge = new ViewSupplierAssignmentModel();
                    charge = UtilityManager.DataReaderMap<ViewSupplierAssignmentModel>(reader);
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
        public bool UpdateSupplierAssing(int id, int status,int payment)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                bool updated = true;
                SqlCommand command = new SqlCommand(StoredProcedured.UpdateAssignmentSupplier, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@AssigentmentSupplierId", id));
                command.Parameters.Add(new SqlParameter("@AssignmentUpdate", status));
                command.Parameters.Add(new SqlParameter("@AssignmentTotalCost", payment));
         
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
    }
}
