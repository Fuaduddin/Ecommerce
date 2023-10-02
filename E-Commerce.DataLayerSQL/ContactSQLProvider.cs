using E_Commerce.Model;
using E_Commerce.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace E_Commerce.DataLayerSQL
{
    public class ContactSQLProvider
    {
        // Email SQL Provider
        public long AddNewEmail(EmailModel email)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                long id = 0;
                SqlCommand command = new SqlCommand(StoredProcedured.AddNewEmail, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnvalue = new SqlParameter("@" + "Emailid", SqlDbType.Int);
                returnvalue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnvalue);
                foreach (var emailitem in email.GetType().GetProperties())
                {
                    if (emailitem.Name != "Emailid")
                    {
                        string name = emailitem.Name;
                        var value = emailitem.GetValue(email, null);
                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@Emailid"].Value;
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
        public List<EmailModel> ViewAllEmail()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetAllEmail, connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    SqlDataReader Datareader = command.ExecuteReader();
                    List<EmailModel> categoryList = new List<EmailModel>();
                    categoryList = UtilityManager.DataReaderMapToList<EmailModel>(Datareader);
                    return categoryList;
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
        public List<EmailModel> SearchEmail(string SearchKeyword)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.SearchEmail, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SearchKeyword", SearchKeyword));
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    SqlDataReader Datareader = command.ExecuteReader();
                    List<EmailModel> categoryList = new List<EmailModel>();
                    categoryList = UtilityManager.DataReaderMapToList<EmailModel>(Datareader);
                    return categoryList;
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
        public List<EmailModel> FilterEmail(int SearchKeyword)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.FilterEmail, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@SearchKeyword", SearchKeyword));
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    SqlDataReader Datareader = command.ExecuteReader();
                    List<EmailModel> categoryList = new List<EmailModel>();
                    categoryList = UtilityManager.DataReaderMapToList<EmailModel>(Datareader);
                    return categoryList;
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
        public bool DeleteEmail(int categoryid)
        {
            bool IsDeleted = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.DeleteEmail, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Emailid", categoryid));
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
        public EmailModel GetSingleEmail(int categoryid)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetSingleEmail, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Emailid", categoryid));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    EmailModel category = new EmailModel();
                    category = UtilityManager.DataReaderMap<EmailModel>(reader);
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
        public bool UpdateEmail(int id, int checkedid)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                bool updated = true;
                SqlCommand command = new SqlCommand(StoredProcedured.UpdateEmail, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Emailid",id));
                command.Parameters.Add(new SqlParameter("@Updatemessage", checkedid));
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

        // Review SQL Provider

        public long AddNewReview(ReviewModel review)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                long id = 0;
                SqlCommand command = new SqlCommand(StoredProcedured.AddNewReview, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnvalue = new SqlParameter("@" + "ReviewId", SqlDbType.Int);
                returnvalue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnvalue);
                foreach (var Categories in review.GetType().GetProperties())
                {
                    if (Categories.Name != "ReviewId" && Categories.Name != "ProductName")
                    {
                        string name = Categories.Name;
                        var value = Categories.GetValue(review, null);
                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@ReviewId"].Value;
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
        public List<ReviewModel> ViewAllReview()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetAllReview, connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    SqlDataReader Datareader = command.ExecuteReader();
                    List<ReviewModel> categoryList = new List<ReviewModel>();
                    categoryList = UtilityManager.DataReaderMapToList<ReviewModel>(Datareader);
                    return categoryList;
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
        public List<ReviewModel> SearchReview(string searchitem)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetCategorySearch, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@CategoryName", searchitem));
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    SqlDataReader Datareader = command.ExecuteReader();
                    List<ReviewModel> categoryList = new List<ReviewModel>();
                    categoryList = UtilityManager.DataReaderMapToList<ReviewModel>(Datareader);
                    return categoryList;
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
        public bool DeleteReview(int categoryid)
        {
            bool IsDeleted = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.DeleteReview, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ReviewId", categoryid));
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
        public ReviewModel GetSingleReview(int categoryid)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetSingleReview, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ReviewId", categoryid));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    ReviewModel category = new ReviewModel();
                    category = UtilityManager.DataReaderMap<ReviewModel>(reader);
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
        public List<ReviewModel> GetSingleProductReview(int id)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetSingleProductReview, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProductId", id));
                try
                {
                    connection.Open();
                    SqlDataReader Datareader = command.ExecuteReader();
                    List<ReviewModel> categoryList = new List<ReviewModel>();
                    categoryList = UtilityManager.DataReaderMapToList<ReviewModel>(Datareader);
                    return categoryList;
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

        //Appointment SQL Provider

        public long AddNewAppointment(AppointmentModel appointment)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                long id = 0;
                SqlCommand command = new SqlCommand(StoredProcedured.AddNewAppointment, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnvalue = new SqlParameter("@" + "AppointmentId", SqlDbType.Int);
                returnvalue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnvalue);
                foreach (var Categories in appointment.GetType().GetProperties())
                {
                    if (Categories.Name != "AppointmentId")
                    {
                        string name = Categories.Name;
                        var value = Categories.GetValue(appointment, null);
                        command.Parameters.Add(new SqlParameter("@" + name, value == null ? DBNull.Value : value));
                    }
                }
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@AppointmentId"].Value;
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
        public List<AppointmentModel> ViewAllAppointment()
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetAllAppointment, connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    SqlDataReader Datareader = command.ExecuteReader();
                    List<AppointmentModel> categoryList = new List<AppointmentModel>();
                    categoryList = UtilityManager.DataReaderMapToList<AppointmentModel>(Datareader);
                    return categoryList;
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
        public List<CategoryModel> SearchAppointment(string searchitem)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetCategorySearch, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@CategoryName", searchitem));
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    SqlDataReader Datareader = command.ExecuteReader();
                    List<CategoryModel> categoryList = new List<CategoryModel>();
                    categoryList = UtilityManager.DataReaderMapToList<CategoryModel>(Datareader);
                    return categoryList;
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
        public bool DeleteAppointment(int categoryid)
        {
            bool IsDeleted = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.DeleteAppointment, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@AppointmentId", categoryid));
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
        public AppointmentModel GetSingleAppointment(int categoryid)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetSingleAppointment, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@AppointmentId", categoryid));
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    AppointmentModel category = new AppointmentModel();
                    category = UtilityManager.DataReaderMap<AppointmentModel>(reader);
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
        public bool UpdateAppointment(AppointmentModel Appointment)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                bool updated = true;
                SqlCommand command = new SqlCommand(StoredProcedured.UpdateAppointment, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (var Categories in Appointment.GetType().GetProperties())
                {
                    string name = Categories.Name;
                    var value = Categories.GetValue(Appointment, null);
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
        // FAQ SQL Provider

        public long AddNewFAQ(string question, string answer,int productid)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                long id = 0;
                SqlCommand command = new SqlCommand(StoredProcedured.AddNewFAQ, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter returnvalue = new SqlParameter("@" + "FAQid", SqlDbType.Int);
                returnvalue.Direction = ParameterDirection.Output;
                command.Parameters.Add(returnvalue);
                command.Parameters.Add(new SqlParameter("@FAQQuestion", question ));
                command.Parameters.Add(new SqlParameter("@FAQAns", answer));
                command.Parameters.Add(new SqlParameter("@Productid", productid));
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    id = (int)command.Parameters["@FAQid"].Value;
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
        public List<FAQModel> GetSingleProductAllFAQ(int id)
        {
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.GetSingleFAQ, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ProductId", id));
                try
                {
                    connection.Open();
                    SqlDataReader Datareader = command.ExecuteReader();
                    List<FAQModel> categoryList = new List<FAQModel>();
                    categoryList = UtilityManager.DataReaderMapToList<FAQModel>(Datareader);
                    return categoryList;
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
        public bool DeleteFAQ(int id)
        {
            bool IsDeleted = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.DeleteFAQ, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FAQid", id));
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
        public bool UpdateFAQ(int id, string question, string answer,int productid)
        {
            bool IsUpdated = true;
            using (SqlConnection connection = new SqlConnection(CommonUtility.ConnectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedured.UpdateFAQ, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@FAQid", id));
                command.Parameters.Add(new SqlParameter("@FAQQuestion", question));
                command.Parameters.Add(new SqlParameter("@FAQAns", answer));
                command.Parameters.Add(new SqlParameter("@Productid", productid));
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    IsUpdated = false;
                    throw new Exception("Exception Adding Data. " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return IsUpdated;
            }
        }
    }
}
