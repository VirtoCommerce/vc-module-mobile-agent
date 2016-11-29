using System.Collections.Generic;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Responses;
using VirtoCommerce.Mobile.ApiClient.Models;
namespace VirtoCommerce.Mobile.Services
{
    public interface ISyncServerService
    {
        /// <summary>
        /// Get list products
        /// </summary>
        Task<ServerResponseCollection<Product>> GetProducts();
        /// <summary>
        /// Get list filters
        /// </summary>
        Task<ServerResponseCollection<Model.Filter>> GetFilters();

        /// <summary>
        /// Get theme
        /// </summary>
        /// <returns></returns>
        Task<ServerResponse<MobileTheme>> GetTheme();

        /// <summary>
        /// Get current currency
        /// </summary>
        /// <returns></returns>
        Task<ServerResponse<Currency>> GetCurrency();

        /// <summary>
        /// Get shipping methods
        /// </summary>
        Task<ServerResponseCollection<ShippingMethod>> GetShippingMethods();

        /// <summary>
        /// Get payment methods
        /// </summary>
        /// <returns></returns>
        Task<ServerResponseCollection<PaymentMethod>> GetPaymentMethods();
        /// <summary>
        /// Send orders to server
        /// </summary>
        Task<ServerResponse<bool>> SendOrders(ICollection<Order> orders);
    }
}
