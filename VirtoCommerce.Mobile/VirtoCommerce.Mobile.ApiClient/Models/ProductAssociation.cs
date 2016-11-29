using Newtonsoft.Json;
using System.Collections.Generic;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public partial class ProductAssociation
    {
        /// <summary>
        /// Initializes a new instance of the ProductAssociation class.
        /// </summary>
        public ProductAssociation() { }

        /// <summary>
        /// Initializes a new instance of the ProductAssociation class.
        /// </summary>
        public ProductAssociation(string type = default(string), int? priority = default(int?), int? quantity = default(int?), string associatedObjectId = default(string), string associatedObjectName = default(string), string associatedObjectType = default(string), string associatedObjectImg = default(string), IList<string> tags = default(IList<string>))
        {
            Type = type;
            Priority = priority;
            Quantity = quantity;
            AssociatedObjectId = associatedObjectId;
            AssociatedObjectName = associatedObjectName;
            AssociatedObjectType = associatedObjectType;
            AssociatedObjectImg = associatedObjectImg;
            Tags = tags;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "priority")]
        public int? Priority { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "quantity")]
        public int? Quantity { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "associatedObjectId")]
        public string AssociatedObjectId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "associatedObjectName")]
        public string AssociatedObjectName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "associatedObjectType")]
        public string AssociatedObjectType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "associatedObjectImg")]
        public string AssociatedObjectImg { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public IList<string> Tags { get; set; }

    }
}
