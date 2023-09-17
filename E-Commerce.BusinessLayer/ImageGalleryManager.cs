using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.DataLayerSQL;
using E_Commerce.Model;
using static System.Net.Mime.MediaTypeNames;

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
        public static bool DeleteProductImageGallery(int productid)
        {
            ImageGallrySQLProvider provider = new ImageGallrySQLProvider();
            var image = provider.DeleteImages(productid);
            return image;
        }
        public static bool UpdateSingleProductAllImage(ImageGallery images)
        {
            ImageGallrySQLProvider provider = new ImageGallrySQLProvider();
            var image = provider.UpdateSingleProductAllImage(images);
            return image;
        }
        public static List<ImageGallery> GetSingleProductAllImage(int id)
        {
            ImageGallrySQLProvider provider = new ImageGallrySQLProvider();
            var image = provider.GetSingleProductAllImage(id);
            return image;
        }
    }
}
