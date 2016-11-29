using Newtonsoft.Json;

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
        [JsonProperty(PropertyName = "priority")]
        public int? Priority { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sourceItemId")]
        public string SourceItemId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sourceCategoryId")]
        public string SourceCategoryId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "catalogId")]
        public string CatalogId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "categoryId")]
        public string CategoryId { get; set; }

    }
}
