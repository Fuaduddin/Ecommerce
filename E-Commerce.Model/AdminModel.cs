using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model
{
    public class AdminModel
    {
        [Key]
        public int AdminId { get; set; }
        public string AdminOfficialId { get; set; }
        public string AdminProfilePic { get; set; }
        [Required(ErrorMessage = "Please Enter  Name")]
        public string AdminName { get; set; }
        [Required(ErrorMessage = "Please Enter Date of Birth")]
        public DateTime AdminDateofBirth { get; set; }
        [Required(ErrorMessage = "Please Enter Product Description")]
        public string AdminGender { get; set; }
        [Required(ErrorMessage = "Please Enter Present Address")]
        public string AdminPresentAddress { get; set; }
        [Required(ErrorMessage = "Please Enter Permanent Address")]
        public string AdminPermanentAddress { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        public string AdminEmail { get; set; }
        [Required(ErrorMessage = "Please Enter Phone Number")]
        public string AdminPhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Select a Zone")]
        public int TotalAppointment { get; set; }
        [Required(ErrorMessage = "Please Select a Area")]
        public int UserId { get; set; }
      //  public UserModel User { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserType { get; set; }
        public int UserTotalLogin { get; set; }
        public DateTime UserLastLogin { get; set; }
    }
}
