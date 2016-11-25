using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.ApiClient.Models;

namespace VirtoCommerce.Mobile.ApiClient.Api
{
    public class OrderApi : BaseApi, IOrderApi
    {
        public OrderApi(BaseApiClient client) : base(client)
        {
        }

        public async Task<bool> SyncOrdersAsync(ICollection<Order> notSyncOrders, string userLogin)
        {
            return await Client.PostJsonRequestAsync<bool, object>($"api/mobile/sync/orders", new { Orders = notSyncOrders, UserLogin = userLogin });
        }
    }
}
