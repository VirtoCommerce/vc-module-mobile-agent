using Newtonsoft.Json;
using System.Collections.Generic;

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
        public ProductPricesSearchResult(long? totalCount = default(long?), IList<ProductPrice> productPrices = default(IList<ProductPrice>))
        {
            TotalCount = totalCount;
            ProductPrices = productPrices;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "totalCount")]
        public long? TotalCount { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "productPrices")]
        public IList<ProductPrice> ProductPrices { get; set; }

    }
}
