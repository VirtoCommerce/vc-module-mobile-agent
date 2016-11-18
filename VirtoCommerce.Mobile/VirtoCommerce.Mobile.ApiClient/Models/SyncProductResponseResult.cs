using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public class SyncProductResponseResult
    {
        public SyncProductResponseResult()
        {
            Products = new List<Product>();
            Prices = new List<ProductPrice>();
        }
        [Newtonsoft.Json.JsonProperty(PropertyName = "products")]
        public ICollection<Product> Products { set; get; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "prices")]
        public ICollection<ProductPrice> Prices { set; get; }
    }
}
