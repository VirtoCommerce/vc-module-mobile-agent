using System.Collections.Generic;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.ApiClient.Api
{
    public interface IOrderApi
    {
        /// <summary>
        /// Sync orders
        /// </summary>
        Task<bool> SyncOrdersAsync(ICollection<Models.Order> notSyncOrders, string userLogin);
    }
}
