using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model
{
    public class DeliveryChargeModel
    {
        [Key]
        public int DeliveryChargeid { get; set; }
        [Required(ErrorMessage = "Please Enter Delivery Charge Title")]
        public string DeliveryChargeTitle { get; set; }
        [Required(ErrorMessage = "Please Enter Delivery Charge Amount")]
        public int DeliveryCharge { get; set; }
    }

    public class zoneplace
    {
        [Key]
        public int Placeid { get; set; }
        [Required(ErrorMessage = "Please Enter Place Name")]
        public string PlaceName { get; set; }
        [Required(ErrorMessage = "Please Enter Zone Name")]
        public int Zoneid { get; set; }
    }
}
