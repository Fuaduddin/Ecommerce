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
    public class ImageGallrySQLProvider
    {
        public long AddNewImageGallery(string image, long id)
        {
            long ids = 0;
            using (SqlConnection  connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.AddImageGallery, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnvalue = new SqlParameter("@" + "ImageGalleryId", SqlDbType.Int);
                returnvalue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnvalue);
                command.Parameters.Add(new SqlParameter("@Images",image));
                command.Parameters.Add(new SqlParameter("@ProductId",id));
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
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

            return ids;
        }
        public bool DeleteImages(int productid)
        {
            bool IsDeleted = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.DeleteImageGallery, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ImageGalleryId", productid));
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
        public bool  UpdateSingleProductAllImage(ImageGallery images)
        {
            bool updated = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.UpdateImageGallery, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (var charge in images.GetType().GetProperties())
                {
                    string name = charge.Name;
                    var value = charge.GetValue(images, null);
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
            }  
            return updated;
        }
        public List<ImageGallery> GetSingleProductAllImage(int productid)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetSingleProductAllImage, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProductId", productid));
                try
                {
                    connection.Open();
                    SqlDataReader Datareader = command.ExecuteReader();
                    List<ImageGallery> subcategoryList = new List<ImageGallery>();
                    subcategoryList = UtilityManager.DataReaderMapToList<ImageGallery>(Datareader);
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
    }
}
