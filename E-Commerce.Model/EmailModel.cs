using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model
{
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
    }
}
