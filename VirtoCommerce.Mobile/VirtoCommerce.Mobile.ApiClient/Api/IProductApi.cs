using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.ApiClient.Models;

namespace VirtoCommerce.Mobile.ApiClient.Api
{
    public interface IProductApi
    {
        /// <summary>
        /// Find products 
        /// </summary>
        /// <returns></returns>
        Task<CatalogSearchResult> GetProductsAsync();
        /// <summary>
        /// Get full info for products
        /// </summary>
        Task<ICollection<Product>> GetProductsWithReviewsAsync(string ids);
        /// <summary>
        /// Get product prices
        /// </summary>
        Task<ProductPricesSearchResult> GetProductPricesAsync(string ids);
    }
}
