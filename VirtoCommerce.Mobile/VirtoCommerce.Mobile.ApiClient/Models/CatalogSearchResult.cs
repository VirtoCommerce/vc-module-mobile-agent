using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public partial class CatalogSearchResult
    {
        /// <summary>
        /// Initializes a new instance of the CatalogSearchResult class.
        /// </summary>
        public CatalogSearchResult() { }

        /// <summary>
        /// Initializes a new instance of the CatalogSearchResult class.
        /// </summary>
        public CatalogSearchResult(int? productsTotalCount = default(int?), System.Collections.Generic.IList<Product> products = default(System.Collections.Generic.IList<Product>))
        {
            ProductsTotalCount = productsTotalCount;
            Products = products;
        }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "productsTotalCount")]
        public int? ProductsTotalCount { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "products")]
        public System.Collections.Generic.IList<Product> Products { get; set; }

    }

}
