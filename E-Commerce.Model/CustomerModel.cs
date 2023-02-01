using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model
{
    public class CustomerModel
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerImage { get; set; }
        [Required(ErrorMessage = "Please Enter Your Full Name")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Address")]
        public string CustomerAddress { get; set; }
        [Required(ErrorMessage = "Please Enter Phone NUmber")]
        public string CustomerPhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Division")]
        public string CustomerDivision { get; set; }
        [Required(ErrorMessage = "Please Enter Your Distrcit")]
        public string CustomerDistrict { get; set; }
        [Required(ErrorMessage = "Please Enter User Name")]
        public string CustomerUserName { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string CustomerPassword { get; set; }
        public string CustomerRole { get; set; }
    }
}
