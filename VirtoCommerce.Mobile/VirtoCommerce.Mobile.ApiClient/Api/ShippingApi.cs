using System.Collections.Generic;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.ApiClient.Models;

namespace VirtoCommerce.Mobile.ApiClient.Api
{
    public class ShippingApi : BaseApi, IShippingApi
    {
        public ShippingApi(BaseApiClient client) : base(client)
        {
        }
        public async Task<ICollection<ShippingMethod>> GetShippingMethodsAsync(string userLogin)
        {
            return await Client.GetRequestAsync<ICollection<ShippingMethod>>($"api/mobile/sync/shippingMethods/{userLogin}");
        }
    }
}
