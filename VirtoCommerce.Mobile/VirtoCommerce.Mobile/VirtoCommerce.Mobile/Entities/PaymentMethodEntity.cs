using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Entities
{
    public class PaymentMethodEntity:BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string PaymentMethodType { get; set; }
        public string PaymentMethodGroupType { get; set; }
    }
}
