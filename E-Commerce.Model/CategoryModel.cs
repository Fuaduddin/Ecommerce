using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Model
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name is Required")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Category Description is Required")]
        public string CategoryDescription { get; set; }
        public string CategoryImage { get; set; }
    }

}
