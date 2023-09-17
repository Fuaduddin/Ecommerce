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
        [Required(ErrorMessage = "Please Enter Your Full Name")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Address")]
        public string CustomerAddress { get; set; }
        [Required(ErrorMessage = "Please Enter Phone NUmber")]
        public string CustomerPhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Division")]
        public int CustomerZone { get; set; }
        [Required(ErrorMessage = "Please Enter Your Distrcit")]
        public int CustomerArea { get; set; }
        public long UserId { get; set; }
      
        public string UserName { get; set; }
       
        public string UserPassword { get; set; }
        public DateTime UserLastLogin { get; set; }
        public int UserTotalLogin { get; set; }
        public string UserType { get; set; }
        public string DevisionName { get; set; }
        public string PlaceName { get; set; }
    }
}
