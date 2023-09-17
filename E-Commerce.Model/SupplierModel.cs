using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model
{
    public class SupplierModel
    {
        [Key]
        public int SupplierId { get; set; }
        public string SupplierOfficialId { get; set; }
        [Required(ErrorMessage = "Please Enter  Name")]
        public string SupplierName { get; set; }
        [Required(ErrorMessage = "Please Enter Date of Birth")]
        public DateTime SupplierDateofBirth { get; set; }
        [Required(ErrorMessage = "Please Enter Product Description")]
        public string SupplierGender { get; set; }
        [Required(ErrorMessage = "Please Enter Present Address")]
        public string SupplierPresentAddress { get; set; }
        [Required(ErrorMessage = "Please Enter Permanent Address")]
        public string SupplierPermanentAddress { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        public string SupplierEmail { get; set; }
        [Required(ErrorMessage = "Please Enter Phone Number")]
        public string SupplierPhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Select a Category")]
        public int CategoryId { get; set; }
        public int TotalAssngComplete { get; set; }
        public int UserId { get; set; }
        public string SupplierProfilePic { get; set; }
        public string CategoryName { get; set; }
     //   public UserModel User { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserType { get; set; }
        public int UserTotalLogin { get; set; }
        public DateTime UserLastLogin { get; set; }
    }
}
