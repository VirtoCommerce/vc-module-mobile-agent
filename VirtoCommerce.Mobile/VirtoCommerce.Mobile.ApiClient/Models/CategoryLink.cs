using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public partial class CategoryLink
    {
        /// <summary>
        /// Initializes a new instance of the CategoryLink class.
        /// </summary>
        public CategoryLink() { }

        /// <summary>
        /// Initializes a new instance of the CategoryLink class.
        /// </summary>
        public CategoryLink(int? priority = default(int?), string sourceItemId = default(string), string sourceCategoryId = default(string), string catalogId = default(string), string categoryId = default(string))
        {
            Priority = priority;
            SourceItemId = sourceItemId;
            SourceCategoryId = sourceCategoryId;
            CatalogId = catalogId;
            CategoryId = categoryId;
        }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "priority")]
        public int? Priority { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "sourceItemId")]
        public string SourceItemId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "sourceCategoryId")]
        public string SourceCategoryId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "catalogId")]
        public string CatalogId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "categoryId")]
        public string CategoryId { get; set; }

    }
}
