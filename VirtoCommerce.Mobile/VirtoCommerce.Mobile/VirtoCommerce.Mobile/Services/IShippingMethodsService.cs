using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Services
{
   public  interface IShippingMethodsService
    {
        /// <summary>
        /// Save shipping methods
        /// </summary>
        void SaveShippingMethods(ICollection<ApiClient.Models.ShippingMethod> methods);
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
