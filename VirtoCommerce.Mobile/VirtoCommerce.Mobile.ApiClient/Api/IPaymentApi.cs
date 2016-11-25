using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.ApiClient.Api
{
    public interface IPaymentApi
    {
        /// <summary>
        /// Get payment methods
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        Task<ICollection<Models.PaymentMethod>> GetPaymentMethodsAsync(string userLogin);
    }
}
