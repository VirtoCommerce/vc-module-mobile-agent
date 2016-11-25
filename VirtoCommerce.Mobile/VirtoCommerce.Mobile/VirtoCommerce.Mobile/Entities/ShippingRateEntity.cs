using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Entities
{
    public class ShippingRateEntity:BaseEntity
    {
        public string OptionName { get; set; }

        public string OptionDescription { get; set; }

        public double Rate { get; set; }

        public double RateWithTax { get; set; }

        public double DiscountAmount { get; set; }

        public double DiscountAmountWithTax { get; set; }

        public string ShippingMethodId { set; get; }
    }
}
