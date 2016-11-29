using System.Collections.Generic;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public class ShippingMethod
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public ICollection<ShippingRate> ShippingRates {set;get;}
    }
}
