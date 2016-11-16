using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public partial class ProductPrice
    {
        /// <summary>
        /// Initializes a new instance of the ProductPrice class.
        /// </summary>
        public ProductPrice() { }

        /// <summary>
        /// Initializes a new instance of the ProductPrice class.
        /// </summary>
        /// <param name="prices">List prices for the products. It includes
        /// tiered prices also. (Depending on the quantity, for
        /// example)</param>
        public ProductPrice(string productId = default(string), Product product = default(Product), System.Collections.Generic.IList<Price> prices = default(System.Collections.Generic.IList<Price>))
        {
            ProductId = productId;
            Product = product;
            Prices = prices;
        }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "productId")]
        public string ProductId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "product")]
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets list prices for the products. It includes tiered
        /// prices also. (Depending on the quantity, for example)
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "prices")]
        public IList<Price> Prices { get; set; }

    }
}
