using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Entities;
using VirtoCommerce.Mobile.Model;
using VirtoCommerce.Mobile.Responses;

namespace VirtoCommerce.Mobile.Services
{
    public interface ISyncServerService
    {
        /// <summary>
        /// Get list products
        /// </summary>
        Task<ServerResponseCollection<ApiClient.Models.Product>> GetProducts();
        /// <summary>
        /// Get list filters
        /// </summary>
        Task<ServerResponseCollection<Filter>> GetFilters();

        /// <summary>
        /// Get theme
        /// </summary>
        /// <returns></returns>
        Task<ServerResponse<ApiClient.Models.MobileTheme>> GetTheme();

        /// <summary>
        /// Get current currency
        /// </summary>
        /// <returns></returns>
        Task<ServerResponse<ApiClient.Models.Currency>> GetCurrency();

        /// <summary>
        /// Get shipping methods
        /// </summary>
        Task<ServerResponseCollection<ApiClient.Models.ShippingMethod>> GetShippingMethods();

        /// <summary>
        /// Get payment methods
        /// </summary>
        /// <returns></returns>
        Task<ServerResponseCollection<ApiClient.Models.PaymentMethod>> GetPaymentMethods();
        /// <summary>
        /// Send orders to server
        /// </summary>
        Task<ServerResponse<bool>> SendOrders(ICollection<ApiClient.Models.Order> orders);
    }
}
