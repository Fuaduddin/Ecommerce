using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model
{
   public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "User Name is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "User Password  is Required")]
        public string UserPassword { get; set; }
        public DateTime UserLastLogin { get; set; }
        public int UserTotalLogin { get; set; }
        public string UserType { get; set; }
       
    }
}
