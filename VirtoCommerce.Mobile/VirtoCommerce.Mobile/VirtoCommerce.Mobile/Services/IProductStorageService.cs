using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.Services
{
    public interface IProductStorageService
    {
        /// <summary>
        /// Get all products from LocalStorage
        /// </summary>
        /// <returns></returns>
        ICollection<Product> GetAllProducts();
        /// <summary>
        /// Get product list from LocalStorage
        /// </summary>
        ICollection<Product> GetProducts(int start, int end);
        /// <summary>
        /// Get product from LocalStorage
        /// </summary>
        ICollection<Product> GetProduct(string id);
        /// <summary>
        /// Save products in LocalStorage
        /// </summary>
        bool SaveProducts(ICollection<Product> products);
    }
}
