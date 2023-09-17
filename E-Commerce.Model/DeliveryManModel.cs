using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model
{
   public  class DeliveryManModel
    {
        [Key]
        public int DeliverManId { get; set; }
        public string DeliveryManeOfficialId { get; set; }
        public string DeliveryManeProfilePic { get; set; }
        [Required(ErrorMessage = "Please Enter  Name")]
        public string DeliveryManeName { get; set; }
        [Required(ErrorMessage = "Please Enter Date of Birth")]
        public DateTime DeliveryManeDateofBirth { get; set; }
        [Required(ErrorMessage = "Please Enter Product Description")]
        public string DeliveryManeGender { get; set; }
        [Required(ErrorMessage = "Please Enter Present Address")]
        public string DeliveryManePresentAddress { get; set; }
        [Required(ErrorMessage = "Please Enter Permanent Address")]
        public string DeliveryManePermanentAddress { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        public string DeliveryManeEmail { get; set; }
        [Required(ErrorMessage = "Please Enter Phone Number")]
        public string DeliveryManePhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Select a Zone")]
        public int DeliveryManeZoneName { get; set; }
        [Required(ErrorMessage = "Please Select a Area")]
        public int DeliveryManeAreaName { get; set; }
        public int TotalAssignmentComplete { get; set; }
        public int UserId { get; set; }
        public string DevisionName { get; set; }
        public string PlaceName { get; set; }
      //  public UserModel User { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserType { get; set; }
        public int UserTotalLogin { get; set; }
        public DateTime UserLastLogin { get; set; }
    }
}
