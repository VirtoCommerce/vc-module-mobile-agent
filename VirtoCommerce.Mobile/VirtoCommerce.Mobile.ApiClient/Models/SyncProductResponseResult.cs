using Newtonsoft.Json;
using System.Collections.Generic;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public class SyncProductResponseResult
    {
        public SyncProductResponseResult()
        {
            Products = new List<Product>();
            Prices = new List<ProductPrice>();
        }
        [JsonProperty(PropertyName = "products")]
        public ICollection<Product> Products { set; get; }
        [JsonProperty(PropertyName = "prices")]
        public ICollection<ProductPrice> Prices { set; get; }
    }
}
