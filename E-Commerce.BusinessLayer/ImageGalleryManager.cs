using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.DataLayerSQL;
using E_Commerce.Model;

namespace E_Commerce.BusinessLayer
{
    public class ImageGalleryManager
    {
        public static long AddNewProductImageGallery(string images, long id)
        {
            ImageGallrySQLProvider provider = new ImageGallrySQLProvider();
            var image = provider.AddNewImageGallery(images,id);
            return image;
        }
        //public static bool DeleteProductImageGallery(int productid)
        //{

        //}
        //public static ProductModel GetSingleProductImageGallery(int productid)
        //{

        //}
        //public static List<ProductModel> GetAllProductImageGallery()
        //{

        //}
    }
}
