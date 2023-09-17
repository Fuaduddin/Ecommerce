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
    public class DeliverySettingsSQLProvider
    {
        public long AddNewDeliveryDeliveryCharge(DeliveryCharge deliverycharge)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                long id = 0;
                SqlCommand command = new SqlCommand(StoredProcedured.AddDeliveryCharge, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnvalue = new SqlParameter("@" + "DeliveryChargeid", SqlDbType.Int);
                returnvalue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnvalue);
                foreach (var charge in deliverycharge.GetType().GetProperties())
                {
                    if (charge.Name != "DeliveryChargeid")
                    {
                        string name = charge.Name;
                        var value = charge.GetValue(deliverycharge, null);
                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@DeliveryChargeid"].Value;
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
        public List<DeliveryCharge> ViewAllDeliveryCharge()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetAllDeliveryCharge, connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    SqlDataReader Datareader = command.ExecuteReader();
                    List<DeliveryCharge> deliverychargeList = new List<DeliveryCharge>();
                    deliverychargeList = UtilityManager.DataReaderMapToList<DeliveryCharge>(Datareader);
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
        public List<DeliveryCharge> SearchDeliveryCost(string SearchKeyword)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.SearchDeliveryCharge, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@DeliveryChargeTitle", SearchKeyword));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<DeliveryCharge> deliverychargeList = new List<DeliveryCharge>();
                    deliverychargeList = UtilityManager.DataReaderMapToList<DeliveryCharge>(reader);
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
        public bool DeleteDeliveryCharge(int deliverychargeid)
        {
            bool IsDeleted = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.DeleteDeliveryCharge, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@DeliveryChargeid", deliverychargeid));
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
        public DeliveryCharge GetSingleDelivery(int deliverychargeid)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetSingleDeliveryCharge, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@DeliveryChargeid", deliverychargeid));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DeliveryCharge charge = new DeliveryCharge();
                    charge = UtilityManager.DataReaderMap<DeliveryCharge>(reader);
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
        public bool UpdateDeliveryCharge(DeliveryCharge deliveryCharge)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                bool updated = true;
                SqlCommand command = new SqlCommand(StoredProcedured.UpdateDeliveryCharge, connection);
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
        // zone
        public long AddNewZone(Zone zone)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                long id = 0;
                SqlCommand command = new SqlCommand(StoredProcedured.AddZone, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnvalue = new SqlParameter("@" + "Placeid", SqlDbType.Int);
                returnvalue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnvalue);
                foreach (var charge in zone.GetType().GetProperties())
                {
                    if (charge.Name != "Placeid")
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
                    id = (int)command.Parameters["@Placeid"].Value;
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
        public List<viewZone> ViewAllZone()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetAllZone, connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    SqlDataReader Datareader = command.ExecuteReader();
                    List<viewZone> deliverychargeList = new List<viewZone>();
                    deliverychargeList = UtilityManager.DataReaderMapToList<viewZone>(Datareader);
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
        public bool DeleteZone(int areaid)
        {
            bool IsDeleted = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.DeleteZone, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Placeid", areaid));
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
        public Zone GetSingleZone(int areaid)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetSingleZone, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Placeid", areaid));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Zone charge = new Zone();
                    charge = UtilityManager.DataReaderMap<Zone>(reader);
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
        public List<Area> GetSingleZoneAllArea(int areaid)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetSingleZoneAllArea, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Placeid", areaid));
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
        public bool UpdateZone(Zone area)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                bool updated = true;
                SqlCommand command = new SqlCommand(StoredProcedured.UpdateZone, connection);
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
        //area
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
    }
}
