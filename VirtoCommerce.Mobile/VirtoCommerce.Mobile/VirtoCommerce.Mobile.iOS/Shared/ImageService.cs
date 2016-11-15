using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using VirtoCommerce.Mobile.Model;
using VirtoCommerce.Mobile.Services;
using System.Net;
using System.IO;
using VirtoCommerce.Mobile.iOS.Shared;

[assembly: Xamarin.Forms.Dependency(typeof(ImageService))]
namespace VirtoCommerce.Mobile.iOS.Shared
{
    public class ImageService : ILocalStorageImageService
    {
        public string SaveImage(Image image, string productId)
        {
            var webClient = new WebClient();
            var bytes = webClient.DownloadData(image.Path);
            string documentsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), productId);
            string localFilename = image.Path;
            string localPath = Path.Combine(documentsPath, localFilename);
            File.WriteAllBytes(localPath, bytes);
            return localPath;
        }
    }
}