using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model
{
    public class DeliveryCharge
    {
        [Key]
        public int DeliveryChargeid { get; set; }
        [Required(ErrorMessage = "Please Enter Delivery Charge Title")]
        public string DeliveryChargeTitle { get; set; }
        [Required(ErrorMessage = "Please Enter Delivery Charge Amount")]
        public int DeliveryChargeAmount { get; set; }
    }

    public class Area
    {
        [Key]
        public int ZoneId { get; set; }
        [Required(ErrorMessage = "Please Enter Place Name")]
        public string DevisionName { get; set; }
        [Required(ErrorMessage = "Please Enter Zone Name")]
        public int DeliveryCharge { get; set; }
    }
    public class Zone
    {
        [Key]
        public int Placeid { get; set; }
        [Required(ErrorMessage = "Please Enter Delivery Charge Title")]
        public string PlaceName { get; set; }
        [Required(ErrorMessage = "Please Enter Delivery Charge Amount")]
        public int Zoneid { get; set; }
    }

}
