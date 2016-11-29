using System.Collections.Generic;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.ApiClient.Models;

namespace VirtoCommerce.Mobile.ApiClient.Api
{
    public interface IPaymentApi
    {
        /// <summary>
        /// Get payment methods
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        Task<ICollection<PaymentMethod>> GetPaymentMethodsAsync(string userLogin);
    }
}
