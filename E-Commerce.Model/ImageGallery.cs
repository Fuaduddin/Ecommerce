using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model
{
    public class ImageGallery
    {
        [Key]
        public int ImageGalleryId { get; set; }
       
        public string Images { get; set; }
       
        public int ProductId { get; set; }
    }
}
