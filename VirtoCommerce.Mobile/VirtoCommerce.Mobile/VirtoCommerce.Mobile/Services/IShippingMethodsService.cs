using System.Collections.Generic;
using ApiClientModel = VirtoCommerce.Mobile.ApiClient.Models;

namespace VirtoCommerce.Mobile.Services
{
    public  interface IShippingMethodsService
    {
        /// <summary>
        /// Save shipping methods
        /// </summary>
        void SaveShippingMethods(ICollection<ApiClientModel.ShippingMethod> methods);
        /// <summary>
        /// Get all shipping methods
        /// </summary>
        ICollection<Model.ShippingMethod> GetAllShippingMethods();
        /// <summary>
        /// Get shipping method by id
        /// </summary>
        Model.ShippingMethod GetShippingMethod(string id);

    }
}
