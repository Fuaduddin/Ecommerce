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
                SqlParameter returnvalue = new SqlParameter("@" + "GalleryId", SqlDbType.Int);
                returnvalue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnvalue);
                command.Parameters.Add("@" + "Images", image);
                command.Parameters.Add("@" + "ProductId", id);
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
        //public bool DeleteImages(int productid)
        //{

        //}
        //public List<ProductImageGallery> GetSingleProductAllImage(int id)
        //{

        //}
    }
}
