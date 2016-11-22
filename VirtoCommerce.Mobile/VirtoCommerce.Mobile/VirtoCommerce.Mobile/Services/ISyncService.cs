using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Model;
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
    }
}
