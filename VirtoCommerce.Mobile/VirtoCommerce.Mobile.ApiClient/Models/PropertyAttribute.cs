using Newtonsoft.Json;

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
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "property")]
        public Property Property { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

    }
}
