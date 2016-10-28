using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Model;
using VirtoCommerce.Mobile.Responses;

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
        Task<ServerResponseCollection<Filter>> GetFilters();
    }
}
