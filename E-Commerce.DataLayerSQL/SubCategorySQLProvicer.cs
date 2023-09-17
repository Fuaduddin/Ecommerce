using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Model;
using E_Commerce.Utility;

namespace E_Commerce.DataLayerSQL.Properties
{
    public class SubCategorySQLProvicer
    {
        public long AddSubcategory(SubCategoryModel subcategory)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.AddSubCategory, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnvalue = new SqlParameter("@" + "SubCategoryId", SqlDbType.Int);
                returnvalue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnvalue);
                foreach (var Subcategory in subcategory.GetType().GetProperties())
                {
                    if (Subcategory.Name != "SubCategoryId")
                    {
                        var name = Subcategory.Name;
                        var value = Subcategory.GetValue(subcategory,null);
                        command.Parameters.Add(new  SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@SubCategoryId"].Value;
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
            return id;
        }

        public bool UpdateSubCategory(SubCategoryModel subCategory)
        {
            bool IsUpdated = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.UpdateSubCategory, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (var Subcategory in subCategory.GetType().GetProperties())
                {
                    if (Subcategory.Name != "CategoryName")
                    {
                        var name = Subcategory.Name;
                        var value = Subcategory.GetValue(subCategory, null);
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
        public List<viewsubcategory> ViewAllSubCategory()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetAllSubCategory, connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    SqlDataReader Datareader = command.ExecuteReader();
                    List<viewsubcategory> subcategoryList = new List<viewsubcategory>();
                    subcategoryList = UtilityManager.DataReaderMapToList<viewsubcategory>(Datareader);
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
        public List<viewsubcategory> SearchSubCategory(string SearchKeyword)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetSubCategorySearch, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SearchKeyword", SearchKeyword));
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    SqlDataReader Datareader = command.ExecuteReader();
                    List<viewsubcategory> subcategoryList = new List<viewsubcategory>();
                    subcategoryList = UtilityManager.DataReaderMapToList<viewsubcategory>(Datareader);
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

        public bool DeleteSubCategory(int subcategoryid)
        {
            bool IsDeleted = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.DeleteSubCategory, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SubCategoryId", subcategoryid));
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
        public SubCategoryModel GetSingleSubCategory(int subcategoryid)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetSingleSubCategory, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SubCategoryId", subcategoryid));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    SubCategoryModel category = new SubCategoryModel();
                    category = UtilityManager.DataReaderMap<SubCategoryModel>(reader);
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
        public List<SubCategoryModel> GetAllSelectedSubCategory(int subcategoryid)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetAllSelectedSubCategory, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@CategoryId", subcategoryid));
                try
                {
                    connection.Open();
                    SqlDataReader Datareader = command.ExecuteReader();
                    List<SubCategoryModel> subcategoryList = new List<SubCategoryModel>();
                    subcategoryList = UtilityManager.DataReaderMapToList<SubCategoryModel>(Datareader);
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
        public int GettotalProduct(int SubCategoryId)
          {
          using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
           {
          SqlCommand command = new SqlCommand(StoredProcedured.GetSubcategorytotalproduct, connection);
           command.CommandType = CommandType.StoredProcedure;
          command.Parameters.Add(new SqlParameter("@SubCategoryId", SubCategoryId));
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

   } 
}
