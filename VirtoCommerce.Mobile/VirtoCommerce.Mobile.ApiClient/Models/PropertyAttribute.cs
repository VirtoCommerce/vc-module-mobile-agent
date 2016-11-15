using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public partial class PropertyAttribute
    {
        /// <summary>
        /// Initializes a new instance of the PropertyAttribute class.
        /// </summary>
        public PropertyAttribute() { }

        /// <summary>
        /// Initializes a new instance of the PropertyAttribute class.
        /// </summary>
        public PropertyAttribute(string id = default(string), Property property = default(Property), string value = default(string), string name = default(string))
        {
            Id = id;
            Property = property;
            Value = value;
            Name = name;
        }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "property")]
        public Property Property { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

    }
}
