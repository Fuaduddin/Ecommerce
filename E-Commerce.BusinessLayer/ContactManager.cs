using E_Commerce.DataLayerSQL;
using E_Commerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BusinessLayer
{
    public class ContactManager
    {
        // Email Manager
        public static long AddNewEmail(EmailModel email)
        {
            ContactSQLProvider provider = new ContactSQLProvider();
            var Categorytid = provider.AddNewEmail(email);
            return Categorytid;
        }
        public static List<EmailModel> GetAllEmail()
        {
            ContactSQLProvider provider = new ContactSQLProvider();
            var Categoriesd = provider.ViewAllEmail();
            return Categoriesd;
        }
        public static bool UpdateEmail(int email,int checkedid)
        {
            ContactSQLProvider provider = new ContactSQLProvider();
            var Categoriesd = provider.UpdateEmail(email, checkedid);
            return Categoriesd;
        }
        public static EmailModel GetSingleEmail(int categoryId)
        {
            ContactSQLProvider provider = new ContactSQLProvider();
            var Categoriesd = provider.GetSingleEmail(categoryId);
            return Categoriesd;
        }
        public static bool DeleteEmail(int categoryId)
        {
            ContactSQLProvider provider = new ContactSQLProvider();
            var Categoriesd = provider.DeleteEmail(categoryId);
            return Categoriesd;
        }
        public static List<EmailModel> SearchEmail(string SearchKeyword)
        {
            ContactSQLProvider provider = new ContactSQLProvider();
            var Categoriesd = provider.SearchEmail(SearchKeyword);
            return Categoriesd;
        }
        public static List<EmailModel> FilterEmail(int SearchKeyword)
        {
            ContactSQLProvider provider = new ContactSQLProvider();
            var Categoriesd = provider.FilterEmail(SearchKeyword);
            return Categoriesd;
        }

        // Review Manager

        public static long AddNewReview(ReviewModel review)
        {
            ContactSQLProvider provider = new ContactSQLProvider();
            var Categorytid = provider.AddNewReview(review);
            return Categorytid;
        }
        public static List<ReviewModel> GetAllReview()
        {
            ContactSQLProvider provider = new ContactSQLProvider();
            var Categoriesd = provider.ViewAllReview();
            return Categoriesd;
        }
        public static List<ReviewModel> GetSingleProductReview(int id)
        {
            ContactSQLProvider provider = new ContactSQLProvider();
            var Categoriesd = provider.GetSingleProductReview(id);
            return Categoriesd;
        }
        public static ReviewModel GetSingleReview(int categoryId)
        {
            ContactSQLProvider provider = new ContactSQLProvider();
            var Categoriesd = provider.GetSingleReview(categoryId);
            return Categoriesd;
        }
        public static bool DeleteReview(int categoryId)
        {
            ContactSQLProvider provider = new ContactSQLProvider();
            var Categoriesd = provider.DeleteReview(categoryId);
            return Categoriesd;
        }
        public static long ReviewModelRatingDetails(int categoryId)
        {
            // ReviewModelRatingDetails
            ContactSQLProvider provider = new ContactSQLProvider();
            // var Categoriesd = provider.AddNewReview();
            long Categoriesd= 1;
            return Categoriesd;
        }
        // public static List<CategoryModel> SearchReview(string serachvalue)
        // {
        // ContactSQLProvider provider = new ContactSQLProvider();
        // var Categoriesd = provider.SearchCategory(serachvalue);
        //     return Categoriesd;
        // }

        //Appointment Manager

        public static long AddNewAppointment(AppointmentModel appointment)
        {
            ContactSQLProvider provider = new ContactSQLProvider();
            var Categorytid = provider.AddNewAppointment(appointment);
            return Categorytid;
        }
        public static List<AppointmentModel> GetAllAppointment()
        {
            ContactSQLProvider provider = new ContactSQLProvider();
            var Categoriesd = provider.ViewAllAppointment();
            return Categoriesd;
        }
        public static AppointmentModel GetSingleAppointment(int categoryId)
        {
            ContactSQLProvider provider = new ContactSQLProvider();
            var Categoriesd = provider.GetSingleAppointment(categoryId);
            return Categoriesd;
        }
        public static bool DeleteAppointment(int categoryId)
        {
            ContactSQLProvider provider = new ContactSQLProvider();
            var Categoriesd = provider.DeleteAppointment(categoryId);
            return Categoriesd;
        }
        public static bool UpdateAppointment(AppointmentModel appointment)
        {
            ContactSQLProvider provider = new ContactSQLProvider();
            var Categoriesd = provider.UpdateAppointment(appointment);
            return Categoriesd;
        }
        //  public static List<AppointmentModel> SearchAppointment(string serachvalue)
        // {
        //   ContactSQLProvider provider = new ContactSQLProvider();
        //   var Categoriesd = provider.SearchCategory(serachvalue);
        //       return Categoriesd;
        // }

        //FAQ
        public static long AddNewFAQ(string question, string answer,int productid)
        {
            ContactSQLProvider provider = new ContactSQLProvider();
            var Categorytid = provider.AddNewFAQ(question, answer, productid);
            return Categorytid;
        }
        public static List<FAQModel> GetSingleProductAllFAQ(int id)
        {
            ContactSQLProvider provider = new ContactSQLProvider();
            var Categoriesd = provider.GetSingleProductAllFAQ(id);
            return Categoriesd;
        }
        public static bool DeleteFAQ(int id)
        {
            ContactSQLProvider provider = new ContactSQLProvider();
            var Categoriesd = provider.DeleteFAQ(id);
            return Categoriesd;
        }
        public static bool UpdateFAQ(int id, string question, string answer, int productid)
        {
            ContactSQLProvider provider = new ContactSQLProvider();
            var Categoriesd = provider.UpdateFAQ(id, question, answer, productid);
            return Categoriesd;
        }
    }
}
