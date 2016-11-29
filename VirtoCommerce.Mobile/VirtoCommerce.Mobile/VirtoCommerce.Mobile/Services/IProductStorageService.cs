using System.Collections.Generic;
using VirtoCommerce.Mobile.Model;
using ApiClientModel = VirtoCommerce.Mobile.ApiClient.Models;

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
        ICollection<Product> GetProducts(int start, int count);
        /// <summary>
        /// Get product by filter
        /// </summary>
        /// <returns></returns>
        ICollection<Product> GetProductByFilter(FilterRequest request);
        /// <summary>
        /// Get count products 
        /// </summary>        
        int GetProductsCount();
        /// <summary>
        /// Get product from LocalStorage
        /// </summary>
        Product GetProduct(string id);
        /// <summary>
        /// Save products in LocalStorage
        /// </summary>
        bool SaveProducts(ICollection<ApiClientModel.Product> products);
        /// <summary>
        /// Save currency
        /// </summary>
        bool SaveCurrency(ApiClientModel.Currency currency);
        /// <summary>
        /// Get current currency
        /// </summary>
        Currency GetCurrentCurrency();

        
    }
}
