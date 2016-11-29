using System.Collections.Generic;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.ApiClient.Models;

namespace VirtoCommerce.Mobile.ApiClient.Api
{
    public class PaymentApi : BaseApi, IPaymentApi
    {
        public PaymentApi(BaseApiClient client) : base(client)
        {
        }

        public async Task<ICollection<PaymentMethod>> GetPaymentMethodsAsync(string userLogin)
        {
            return await Client.GetRequestAsync<ICollection<PaymentMethod>>($"api/mobile/sync/paymentMethods/{userLogin}");
        }
    }
}
