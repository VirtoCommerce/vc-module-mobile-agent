using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtoCommerce.Domain.Shipping.Model;

namespace VirtoCommerce.Mobile.SyncModule.Web.Models
{
    public class ShippingMethod
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public ICollection<ShippingRate> ShippingRates { set; get; }
    }
}