using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Model
{
    public class ShippingMethod
    {
        public ShippingMethod()
        {
            MethodRates = new List<ShippingMethodRate>();
        }
        public string Id { set; get; }
        public string Name { set; get; }
        public ICollection<ShippingMethodRate> MethodRates { set; get; }
    }
}
