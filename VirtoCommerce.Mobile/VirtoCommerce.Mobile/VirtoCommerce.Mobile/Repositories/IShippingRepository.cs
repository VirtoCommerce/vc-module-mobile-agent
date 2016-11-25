using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Entities;

namespace VirtoCommerce.Mobile.Repositories
{
    public interface IShippingRepository
    {
        /// <summary>
        /// Save shipping method to store
        /// </summary>
        bool SaveShipping(ShippingMethodEntity method);

        /// <summary>
        /// Save shipping rate
        /// </summary>
        bool SaveShippingRate(ShippingRateEntity rate);

        /// <summary>
        /// Delete shipping method
        /// </summary>
        void DeleteShippig(string id);

        /// <summary>
        /// Delete shipping rate
        /// </summary>
        bool DeleteShippingRate(string id);

        /// <summary>
        /// Get shipping rates for shipping method
        /// </summary>
        ICollection<ShippingRateEntity> GetShippingRatesForMethod(string id);

        /// <summary>
        /// Get shipping rate
        /// </summary>
        ShippingRateEntity GetShippingRate(string id);
        /// <summary>
        /// Get shipping method by id
        /// </summary>
        ShippingMethodEntity GetShippingMethodById(string id);

        /// <summary>
        /// Get all shipping methods
        /// </summary>
        ICollection<ShippingMethodEntity> GetAllShippingMethods();
    }
}
