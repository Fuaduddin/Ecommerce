using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model
{
    public class SubCategoryModel
    {
        [Key]
        public int SubCategoryId { get; set; }
        [Required (ErrorMessage = "Please Give Name of the Sub Category")]
        public string SubCategoryName { get; set; }
        [Required(ErrorMessage = "Please Select a Category")]
        public int CategoryId { get; set; }
    }

    public class viewsubcategory
    {
        [Key]
        public int SubCategoryId { get; set; }
        [Required(ErrorMessage = "Please Give Name of the Sub Category")]
        public string SubCategoryName { get; set; }
        [Required(ErrorMessage = "Please Select a Category")]
        public string Categoryname { get; set; }
        public int CategoryId { get; set; }

    }
}
