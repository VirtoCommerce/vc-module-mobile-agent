using Newtonsoft.Json;
using System.Collections.Generic;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public class CatalogSearchResult
    {
        /// <summary>
        /// Initializes a new instance of the CatalogSearchResult class.
        /// </summary>
        public CatalogSearchResult() { }

        /// <summary>
        /// Initializes a new instance of the CatalogSearchResult class.
        /// </summary>
        public CatalogSearchResult(int? productsTotalCount = default(int?), IList<Product> products = default(IList<Product>))
        {
            ProductsTotalCount = productsTotalCount;
            Products = products;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "productsTotalCount")]
        public int? ProductsTotalCount { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "products")]
        public IList<Product> Products { get; set; }

    }

}
