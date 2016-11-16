using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public partial class ProductPricesSearchResult
    {
        /// <summary>
        /// Initializes a new instance of the ProductPricesSearchResult class.
        /// </summary>
        public ProductPricesSearchResult() { }

        /// <summary>
        /// Initializes a new instance of the ProductPricesSearchResult class.
        /// </summary>
        public ProductPricesSearchResult(long? totalCount = default(long?), System.Collections.Generic.IList<ProductPrice> productPrices = default(System.Collections.Generic.IList<ProductPrice>))
        {
            TotalCount = totalCount;
            ProductPrices = productPrices;
        }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "totalCount")]
        public long? TotalCount { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "productPrices")]
        public System.Collections.Generic.IList<ProductPrice> ProductPrices { get; set; }

    }
}
