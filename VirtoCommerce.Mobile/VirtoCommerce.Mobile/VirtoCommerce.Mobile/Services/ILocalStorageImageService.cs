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
        /// <summary>
        /// Save logo
        /// </summary>
        /// <param name="image"></param>
        void SaveImageLogo(Image image);

        /// <summary>
        /// Delete folder
        /// </summary>
        void DeleteFolderImage(string folder);
        /// <summary>
        /// Delete image from folder
        /// </summary>
        void DeleteImage(string path);
    }
}
