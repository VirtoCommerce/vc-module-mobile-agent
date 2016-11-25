using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public class PaymentMethod
    {
        public string Id { set; get; }
        public string Code { get; set; }
        public string Name { get; set; }
		public string PaymentMethodType { get; set; }
        public string PaymentMethodGroupType { get; set; }
    }
}
