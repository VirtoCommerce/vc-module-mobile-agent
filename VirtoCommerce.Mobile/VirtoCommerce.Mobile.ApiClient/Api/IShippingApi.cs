using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.ApiClient.Api
{
    public interface IShippingApi
    {
        /// <summary>
        /// Get shipping methods
        /// </summary>
        /// <returns></returns>
        Task<ICollection<Models.ShippingMethod>> GetShippingMethodsAsync(string userLogin);
    }
}
