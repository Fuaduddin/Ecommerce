using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model
{
     public class ZoneModel
    {
        [Key]
        public int ZoneId { get; set; }
        [Required(ErrorMessage = "Please Enter Devision Name")]
        public string DevisionName { get; set; }
        [Required(ErrorMessage = "Please Enter Area Name")]
        public string AreaName { get; set; }
        [Required(ErrorMessage = "Please Enter Delivery Charge")]
        public int DeliverCharge { get; set; } 
    }
}
