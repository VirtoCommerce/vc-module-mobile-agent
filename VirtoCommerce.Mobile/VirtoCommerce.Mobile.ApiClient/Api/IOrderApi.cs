using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
