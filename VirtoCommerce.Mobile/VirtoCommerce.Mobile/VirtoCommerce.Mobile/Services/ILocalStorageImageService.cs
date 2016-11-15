using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Entities;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.Services
{
    public interface ILocalStorageImageService
    {
        /// <summary>
        /// Save image to LocalStoreage
        /// </summary>
        /// <returns>Local path save</returns>
        string SaveImage(Image image, string productId);
    }
}
