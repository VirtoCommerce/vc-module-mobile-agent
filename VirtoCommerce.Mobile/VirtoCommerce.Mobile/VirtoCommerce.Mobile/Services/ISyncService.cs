using System.Threading.Tasks;
using VirtoCommerce.Mobile.Responses;

namespace VirtoCommerce.Mobile.Services
{
    public interface ISyncService
    {
        /// <summary>
        /// Sync products from server
        /// </summary>
        Task<SyncResponse> SyncProducts();

        /// <summary>
        /// Sync filters from server
        /// </summary>
        /// <returns></returns>
        Task<SyncResponse> SyncFilters();

        /// <summary>
        /// Sync theme from server
        /// </summary>
        /// <returns></returns>
        Task<SyncResponse> SyncTheme();

        /// <summary>
        /// Sync currency
        /// </summary>
        /// <returns></returns>
        Task<SyncResponse> SyncCurrency();

        /// <summary>
        /// Sync shipping methods
        /// </summary>
        Task<SyncResponse> SyncShippingMethods();
        /// <summary>
        /// Sync payment methods
        /// </summary>
        Task<SyncResponse> SyncPaymentMethods();

        /// <summary>
        /// Sync orders
        /// </summary>
        /// <returns></returns>
        Task<SyncResponse> SyncOrders();

    }
}
