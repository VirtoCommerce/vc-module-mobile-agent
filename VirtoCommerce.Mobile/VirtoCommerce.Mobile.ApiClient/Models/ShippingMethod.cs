using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public class ShippingMethod
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public ICollection<ShippingRate> ShippingRates {set;get;}
    }
}
