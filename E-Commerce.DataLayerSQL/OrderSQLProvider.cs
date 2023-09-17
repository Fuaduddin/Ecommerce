using E_Commerce.Model;
using E_Commerce.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataLayerSQL
{
    public class OrderSQLProvider
    {

        public long AddNewOrder(OrderModel order)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                long id = 0;
                SqlCommand command = new SqlCommand(StoredProcedured.AddNewOrder, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnvalue = new SqlParameter("@" + "OrderId", SqlDbType.Int);
                returnvalue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnvalue);
                foreach (var charge in order.GetType().GetProperties())
                {
                    if (charge.Name != "OrderId")
                    {
                        string name = charge.Name;
                        var value = charge.GetValue(order, null);
                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@OrderId"].Value;
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
        public long AddNewShipment(ShipmentModel shipment)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                long id = 0;
                SqlCommand command = new SqlCommand(StoredProcedured.AddNewShipment, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnvalue = new SqlParameter("@" + "ShipmentId", SqlDbType.Int);
                returnvalue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnvalue);
                foreach (var charge in shipment.GetType().GetProperties())
                {
                    if (charge.Name != "ShipmentId" && charge.Name != "ShipmentItemPickedUpDate")
                    {
                        string name = charge.Name;
                        var value = charge.GetValue(shipment, null);
                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@ShipmentId"].Value;
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
        public long AddNewOrderItem(OrderItemModel OrderItem)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                long id = 0;
                SqlCommand command = new SqlCommand(StoredProcedured.AddNewOrderItem, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnvalue = new SqlParameter("@" + "OrderItemId", SqlDbType.Int);
                returnvalue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnvalue);
                foreach (var charge in OrderItem.GetType().GetProperties())
                {
                    if (charge.Name != "OrderItemId")
                    {
                        string name = charge.Name;
                        var value = charge.GetValue(OrderItem, null);
                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@OrderItemId"].Value;
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
        public long AddNewPayment(Payment payment)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                long id = 0;
                SqlCommand command = new SqlCommand(StoredProcedured.AddNewPayment, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnvalue = new SqlParameter("@" + "PaymentId", SqlDbType.Int);
                returnvalue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnvalue);
                foreach (var charge in payment.GetType().GetProperties())
                {
                    if (charge.Name != "PaymentId")
                    {
                        string name = charge.Name;
                        var value = charge.GetValue(payment, null);
                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@PaymentId"].Value;
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
        public OrderModel GetSIngleOrder(string Order)
        {
			using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
			{
				SqlCommand command = new SqlCommand(StoredProcedured.GetSingleOrder, connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@OrderOfficialId", Order));
				try
				{
					connection.Open();
					SqlDataReader reader = command.ExecuteReader();
					OrderModel order = new OrderModel();
					order = UtilityManager.DataReaderMap<OrderModel>(reader);
					return order;
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
        public ShipmentModel GetSIngleShipment(int OrderId)
        {
			using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
			{
				SqlCommand command = new SqlCommand(StoredProcedured.GetSingleShipment, connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@OrderId", OrderId));
				try
				{
					connection.Open();
					SqlDataReader reader = command.ExecuteReader();
					ShipmentModel shipment = new ShipmentModel();
					shipment = UtilityManager.DataReaderMap<ShipmentModel>(reader);
					return shipment;
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
        public List<OrderItemModel> GetSIngleOrderItem(int OrderId)
        {
			using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
			{
				SqlCommand command = new SqlCommand(StoredProcedured.GetSingleOrderItem, connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@OrderId", OrderId));
				command.CommandType = CommandType.StoredProcedure;
				try
				{
					connection.Open();
					SqlDataReader Datareader = command.ExecuteReader();
					List<OrderItemModel> orderitemList = new List<OrderItemModel>();
					orderitemList = UtilityManager.DataReaderMapToList<OrderItemModel>(Datareader);
					return orderitemList;
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
        public Payment GetSInglePayment(int OrderId)
        {
			using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
			{
				SqlCommand command = new SqlCommand(StoredProcedured.GetSinglePayment, connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@OrderId", OrderId));
				try
				{
					connection.Open();
					SqlDataReader reader = command.ExecuteReader();
					Payment payment = new Payment();
					payment = UtilityManager.DataReaderMap<Payment>(reader);
					return payment;
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
        //public List<DeliveryCharge> ViewAllDeliveryCharge()
        //{
        //    using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
        //    {
        //        SqlCommand command = new SqlCommand(StoredProcedured.GetAllDeliveryCharge, connection);
        //        command.CommandType = CommandType.StoredProcedure;
        //        try
        //        {
        //            connection.Open();
        //            SqlDataReader Datareader = command.ExecuteReader();
        //            List<DeliveryCharge> deliverychargeList = new List<DeliveryCharge>();
        //            deliverychargeList = UtilityManager.DataReaderMapToList<DeliveryCharge>(Datareader);
        //            return deliverychargeList;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Exception Adding Data. " + ex.Message);
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //}
        //public List<DeliveryCharge> SearchDeliveryCost(string SearchKeyword)
        //{
        //    using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
        //    {
        //        SqlCommand command = new SqlCommand(StoredProcedured.SearchDeliveryCharge, connection);
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.Add(new SqlParameter("@DeliveryChargeTitle", SearchKeyword));
        //        try
        //        {
        //            connection.Open();
        //            SqlDataReader reader = command.ExecuteReader();
        //            List<DeliveryCharge> deliverychargeList = new List<DeliveryCharge>();
        //            deliverychargeList = UtilityManager.DataReaderMapToList<DeliveryCharge>(reader);
        //            return deliverychargeList;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Exception Adding Data. " + ex.Message);
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //}
        //public bool DeleteDeliveryCharge(int deliverychargeid)
        //{
        //    bool IsDeleted = true;
        //    using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
        //    {
        //        SqlCommand command = new SqlCommand(StoredProcedured.DeleteDeliveryCharge, connection);
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.Add(new SqlParameter("@DeliveryChargeid", deliverychargeid));
        //        try
        //        {
        //            connection.Open();
        //            command.ExecuteNonQuery();
        //        }
        //        catch (Exception ex)
        //        {
        //            IsDeleted = false;
        //            throw new Exception("Exception Adding Data. " + ex.Message);
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }

        //        return IsDeleted;
        //    }
        //}
        //public DeliveryCharge GetSingleDelivery(int deliverychargeid)
        //{
        //    using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
        //    {
        //        SqlCommand command = new SqlCommand(StoredProcedured.GetSingleDeliveryCharge, connection);
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.Add(new SqlParameter("@DeliveryChargeid", deliverychargeid));
        //        try
        //        {
        //            connection.Open();
        //            SqlDataReader reader = command.ExecuteReader();
        //            DeliveryCharge charge = new DeliveryCharge();
        //            charge = UtilityManager.DataReaderMap<DeliveryCharge>(reader);
        //            return charge;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Exception Adding Data. " + ex.Message);
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //}
        //public bool UpdateDeliveryCharge(DeliveryCharge deliveryCharge)
        //{
        //    using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
        //    {
        //        bool updated = true;
        //        SqlCommand command = new SqlCommand(StoredProcedured.UpdateDeliveryCharge, connection);
        //        command.CommandType = CommandType.StoredProcedure;
        //        foreach (var charge in deliveryCharge.GetType().GetProperties())
        //        {
        //            string name = charge.Name;
        //            var value = charge.GetValue(deliveryCharge, null);
        //            command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
        //        }
        //        try
        //        {
        //            connection.Open();
        //            command.ExecuteNonQuery();
        //        }
        //        catch (Exception ex)
        //        {
        //            updated = false;
        //            throw new Exception("Exception Adding Data. " + ex.Message);
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //        return updated;
        //    }
        //}

    }
}
