using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public ProductAssociation(string type = default(string), int? priority = default(int?), int? quantity = default(int?), string associatedObjectId = default(string), string associatedObjectName = default(string), string associatedObjectType = default(string), string associatedObjectImg = default(string), System.Collections.Generic.IList<string> tags = default(System.Collections.Generic.IList<string>))
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
        [Newtonsoft.Json.JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "priority")]
        public int? Priority { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "quantity")]
        public int? Quantity { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "associatedObjectId")]
        public string AssociatedObjectId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "associatedObjectName")]
        public string AssociatedObjectName { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "associatedObjectType")]
        public string AssociatedObjectType { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "associatedObjectImg")]
        public string AssociatedObjectImg { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "tags")]
        public System.Collections.Generic.IList<string> Tags { get; set; }

    }
}
