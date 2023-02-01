using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        public string ProdcutItemId { get; set; }
        public string ProductImage { get; set; }
        [Required(ErrorMessage = "Please Enter Product Name")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Please Enter Product Description")]
        public string ProductDescription { get; set; }
        [Required(ErrorMessage = "Please Enter Product Quantity")]
        public int ProductQuantity { get; set; }
        [Required(ErrorMessage = "Please Enter Product price")]
        public int ProductPrice { get; set; }
        [Required(ErrorMessage = "Please Enter Product Width")]
        public int ProductWidth { get; set; }
        [Required(ErrorMessage = "Please Enter Product Height")]
        public int ProductHeight { get; set; }
        [Required(ErrorMessage = "Please Enter Product Weight")]
        public int ProductWeight { get; set; }
        [Required(ErrorMessage = "Please Enter Product Color")]
        public string ProductColor { get; set; }
        [Required(ErrorMessage = "Please Enter Product Depth")]
        public int ProductDepth { get; set; }
        [Required(ErrorMessage = "Please Enter Product Freshness Duration")]
        public int ProductFreshnessDuration { get; set; }
        public SubCategoryModel Subcategory { get; set; }
        public int SubcategoryId { get; set; }
        public int CategoryId { get; set; }
    }
}
