using System.Collections.Generic;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.ApiClient.Models;

namespace VirtoCommerce.Mobile.ApiClient.Api
{
    public interface IShippingApi
    {
        /// <summary>
        /// Get shipping methods
        /// </summary>
        /// <returns></returns>
        Task<ICollection<ShippingMethod>> GetShippingMethodsAsync(string userLogin);
    }
}
