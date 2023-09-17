using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model
{
    // Email Model
    public class EmailModel
    {
        [Key]
        public int Emailid { get; set; }
        [Required(ErrorMessage = "Please Enter Your Full Name")]
        public string CustomerFullName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email Address")]
        public string CustomerEmailAddress { get; set; }
        [Required(ErrorMessage = "Please Enter Subject")]
        public string EmailSubject { get; set; }
        [Required(ErrorMessage = "Please Enter Message")]
        public string Email { get; set; }
        public DateTime SentDate { get; set; }
        public int Updatemessage { get; set; }
    }

    // Review Model
    public class ReviewModel
    {
        [Key]
        public int ReviewId { get; set; }
        [Required(ErrorMessage = "Please Enter Your Comment")]
        public string Review { get; set; }
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please Enter Your Rating")]
        public int TotalRating { get; set; }
        [Required(ErrorMessage = "Please Enter Your Name")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email")]
        public string CustomerEmail { get; set; }
        public string ProductName { get; set; }
    }
    // Review Rating Details
    public class ReviewModelRatingDetails
    {
        public double AverageStarRating { get; set; }
        public int TotalCustomerRating { get; set; }
        public int TotalFiveStarRating { get; set; }
        public int TotalFourStarRating { get; set; }
        public int TotalThreeStarRating { get; set; }
        public int TotalTwoStarRating { get; set; }
        public int TotalOneStarRating { get; set; }
        public int TotalFiveStarRatingCUstomer { get; set; }
        public int TotalFourStarRatingCUstomer { get; set; }
        public int TotalThreeStarRatingCUstomer { get; set; }
        public int TotalTwoStarRatingCUstomer { get; set; }
        public int TotalOneStarRatingCUstomer { get; set; }

    }
    // Appointment Model
    public class AppointmentModel
    {
        [Key]
        public int AppointmentId { get; set; }
        [Required(ErrorMessage = "Please Enter Appointment Subject")]
        public string AppointmentSubject { get; set; }
        [Required(ErrorMessage = "Please Enter Appointment Message")]
        public string AppointmentMessage { get; set; }
        [Required(ErrorMessage = "Please Enter Appoint Date")]
        public DateTime AppointDate { get; set; }
        [Required(ErrorMessage = "Please Enter Your Full Name")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Please Enter Your PhoneNumber")]
        public string CustomerPhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email")]
        public string CustomerEmail { get; set; }
        public int AssingedUpdate { get; set; }
    }
    // FAQ
    public class FAQModel
    {
        [Key]
        public int FAQid { get; set; }
        [Required(ErrorMessage = "Please Enter Question")]
        public string FAQQuestion { get; set; }
        [Required(ErrorMessage = "Please Enter Answer")]
        public string FAQAns { get; set; }
        public int Productid { get; set; }
    }
}
