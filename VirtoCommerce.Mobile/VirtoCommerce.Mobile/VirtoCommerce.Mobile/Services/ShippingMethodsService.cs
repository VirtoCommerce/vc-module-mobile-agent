using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Mobile.ApiClient.Models;
using VirtoCommerce.Mobile.Convertors;
using VirtoCommerce.Mobile.Repositories;

namespace VirtoCommerce.Mobile.Services
{
    public class ShippingMethodsService : IShippingMethodsService
    {

        private readonly IShippingRepository _shippingRepository;
        public ShippingMethodsService(Repositories.IShippingRepository shippingRepository) {
            _shippingRepository = shippingRepository;
        }

        public ICollection<Model.ShippingMethod> GetAllShippingMethods()
        {
            var shippingMethods = _shippingRepository.GetAllShippingMethods().Select(x => x.EntityToModel()).ToArray();
            foreach (var sm in shippingMethods)
            {
                sm.MethodRates = _shippingRepository.GetShippingRatesForMethod(sm.Id).Select(x => { var m = x.EntityToMedel(); m.ShippingMethod = sm; return m; }).ToArray();
            }
            return shippingMethods;
        }

        public Model.ShippingMethod GetShippingMethod(string id)
        {
            var method = _shippingRepository.GetShippingMethodById(id);
            if (method != null)
                return method.EntityToModel();
            return null;
        }

        public void SaveShippingMethods(ICollection<ShippingMethod> methods)
        {
            foreach (var method in methods)
            {
                _shippingRepository.SaveShipping(method.ApiModelToEntity());
                foreach (var rate in method.ShippingRates)
                {
                    var r = rate.ApiModelToEntity();
                    r.ShippingMethodId = method.Id;
                    _shippingRepository.SaveShippingRate(r);
                }
            }
        }
    }
}
