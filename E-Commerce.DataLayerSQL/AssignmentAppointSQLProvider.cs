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
   public class AssignmentAppointSQLProvider
    {
        //Assignment Appointment
        public long AddNewAssignmentAppointment(AdminAssignmentModel adminassing)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                long id = 0;
                SqlCommand command = new SqlCommand(StoredProcedured.AddNewAppointmentAssignment, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnvalue = new SqlParameter("@" + "AssigentmentAppointmentId", SqlDbType.Int);
                returnvalue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnvalue);
                foreach (var charge in adminassing.GetType().GetProperties())
                {
                    if (charge.Name != "AssigentmentAppointmentId" && charge.Name != "AssigentmentFixedDate" && charge.Name != "AppointmentSubject" && charge.Name != "AppointmentMessage"
                     && charge.Name != "AppointDate" && charge.Name != "CustomerName" && charge.Name != "CustomerPhoneNumber" && charge.Name != "CustomerEmail"
                     && charge.Name != "AssingedUpdate" && charge.Name != "AdminName")
                    {
                        string name = charge.Name;
                        var value = charge.GetValue(adminassing, null);
                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@AssigentmentAppointmentId"].Value;
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
        public List<AdminAssignmentModel> ViewAllAssignmentAppointment()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetAllAppointmentAssignment, connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    SqlDataReader Datareader = command.ExecuteReader();
                    List<AdminAssignmentModel> deliverychargeList = new List<AdminAssignmentModel>();
                    deliverychargeList = UtilityManager.DataReaderMapToList<AdminAssignmentModel>(Datareader);
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
        public bool DeleteAssignmentAppointment(int deliverychargeid)
        {
            bool IsDeleted = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.DeleteAppointmentAssignment, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@AssigentmentAppointmentId", deliverychargeid));
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
        public AdminAssignmentModel GetSingleAssignmentAppointment(int deliverychargeid)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetSingleAppointmentAssignment, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@AssigentmentAppointmentId", deliverychargeid));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    AdminAssignmentModel charge = new AdminAssignmentModel();
                    charge = UtilityManager.DataReaderMap<AdminAssignmentModel>(reader);
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
        public bool UpdateAssignmentAppointment(AdminAssignmentModel deliveryCharge)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                bool updated = true;
                SqlCommand command = new SqlCommand(StoredProcedured.UpdateAppointmentAssignment, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (var charge in deliveryCharge.GetType().GetProperties())
                {
                    string name = charge.Name;
                    var value = charge.GetValue(deliveryCharge, null);
                    command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
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
        //Assignment Supplier
        public ProductModel GetSingleProduct(int productid)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetAssignmentProduct, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProductId", productid));
                try
                {
                    connection.Open();
                    SqlDataReader Datareader = command.ExecuteReader();
                    ProductModel subcategoryList = new ProductModel();
                    subcategoryList = UtilityManager.DataReaderMap<ProductModel>(Datareader);
                    return subcategoryList;
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
        public long AddNewAssignmentSupplier(SupplierAssignmentModel zone)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                long id = 0;
                SqlCommand command = new SqlCommand(StoredProcedured.AddNewAssignmentSupplier, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnvalue = new SqlParameter("@" + "AssigentmentSupplierId", SqlDbType.Int);
                returnvalue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnvalue);
                foreach (var charge in zone.GetType().GetProperties())
                {
                    if (charge.Name != "AssigentmentSupplierId")
                    {
                        string name = charge.Name;
                        var value = charge.GetValue(zone, null);
                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@AssigentmentSupplierId"].Value;
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
        public List<ViewSupplierAssignmentModel> ViewAllAssignmentSupplier()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetAllAssignmentSupplier, connection);
                command.CommandType = CommandType.StoredProcedure;
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
        public bool DeleteAssignmentSupplier(int areaid)
        {
            bool IsDeleted = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.DeleteAssignmentSupplier, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@AssigentmentSupplierId", areaid));
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
        public ViewSupplierAssignmentModel GetSingleAssignmentSupplier(int areaid)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetSingleAssignmentSupplier, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@AssigentmentSupplierId", areaid));
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
        public bool UpdateAssignmentSupplier(SupplierAssignmentModel area)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                bool updated = true;
                SqlCommand command = new SqlCommand(StoredProcedured.UpdateAssignmentSupplier, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (var charge in area.GetType().GetProperties())
                {
                    string name = charge.Name;
                    var value = charge.GetValue(area, null);
                    command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
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
        // Indivitual Assignment Details
        //Admin
        public List<AdminAssignmentModel> ViewAllAssingment(int adminid, int assignmentupdate)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.ViewAllAdminAssignAssign, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@AdminId", adminid));
                command.Parameters.Add(new SqlParameter("@Update", assignmentupdate));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<AdminAssignmentModel> deliverychargeList = new List<AdminAssignmentModel>();
                    deliverychargeList = UtilityManager.DataReaderMapToList<AdminAssignmentModel>(reader);
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
        public long AddNewArea(Area zone)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                long id = 0;
                SqlCommand command = new SqlCommand(StoredProcedured.AddArea, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnvalue = new SqlParameter("@" + "ZoneId", SqlDbType.Int);
                returnvalue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnvalue);
                foreach (var charge in zone.GetType().GetProperties())
                {
                    if (charge.Name != "ZoneId" && charge.Name != "PlaceName")
                    {
                        string name = charge.Name;
                        var value = charge.GetValue(zone, null);
                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@ZoneId"].Value;
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
        public List<Area> ViewAllArea()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetAllArea, connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    SqlDataReader Datareader = command.ExecuteReader();
                    List<Area> deliverychargeList = new List<Area>();
                    deliverychargeList = UtilityManager.DataReaderMapToList<Area>(Datareader);
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
        public bool DeleteArea(int areaid)
        {
            bool IsDeleted = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.DeleteArea, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ZoneId", areaid));
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

        // Assignment Delivery Man
        public long AddNewAssignmentDeliveryMan(DeliveryManAssignmentModel adminassing)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                long id = 0;
                SqlCommand command = new SqlCommand(StoredProcedured.AddNewDeliveryManAssign, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnvalue = new SqlParameter("@" + "AssigentmentAppointmentId", SqlDbType.Int);
                returnvalue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnvalue);
                foreach (var charge in adminassing.GetType().GetProperties())
                {
                    if (charge.Name != "DeliveryManeName" && charge.Name != "AssignmentDeliveryId" && charge.Name != "DevisionName" && charge.Name != "PlaceName" && charge.Name != "OrderOfficialId" && charge.Name != "ShipmentAddress" && charge.Name != "TotalPrice")
                    {
                        string name = charge.Name;
                        var value = charge.GetValue(adminassing, null);
                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@AssigentmentAppointmentId"].Value;
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
        public List<DeliveryManAssignmentModel> GetAllAssignmentDeliveryMan()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetAllDeliveryManAssign, connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    SqlDataReader Datareader = command.ExecuteReader();
                    List<DeliveryManAssignmentModel> deliverychargeList = new List<DeliveryManAssignmentModel>();
                    deliverychargeList = UtilityManager.DataReaderMapToList<DeliveryManAssignmentModel>(Datareader);
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
        public bool DeleteAssignmentDeliveryMant(int deliverychargeid)
        {
            bool IsDeleted = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.DeleteDeliveryManAssign, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@AssigentmentAppointmentId", deliverychargeid));
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
        public DeliveryManAssignmentModel GetSingleAssignmentDeliveryMant(int deliverychargeid)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetSingleDeliveryManAssign, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@AssigentmentAppointmentId", deliverychargeid));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DeliveryManAssignmentModel charge = new DeliveryManAssignmentModel();
                    charge = UtilityManager.DataReaderMap<DeliveryManAssignmentModel>(reader);
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
        public bool UpdateAssignmentDeliveryMan(DeliveryManAssignmentModel deliveryCharge)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                bool updated = true;
                SqlCommand command = new SqlCommand(StoredProcedured.UpdateDeliveryManAssign, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (var charge in deliveryCharge.GetType().GetProperties())
                {
                    if (charge.Name != "DeliveryManeName" && charge.Name != "AssignmentDeliveryId" && charge.Name != "DevisionName" && charge.Name != "PlaceName" && charge.Name != "OrderOfficialId" && charge.Name != "ShipmentAddress" && charge.Name != "TotalPrice")
                    {
                        string name = charge.Name;
                        var value = charge.GetValue(deliveryCharge, null);
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

    }
}
