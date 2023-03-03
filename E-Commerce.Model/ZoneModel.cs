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
        [Required(ErrorMessage = "Please Enter Zone Name")]
        public string ZoneName { get; set; }
        [Required(ErrorMessage = "Please Enter Delivery Charge")]
        public int DeliverCharge { get; set; } 
    }
}
