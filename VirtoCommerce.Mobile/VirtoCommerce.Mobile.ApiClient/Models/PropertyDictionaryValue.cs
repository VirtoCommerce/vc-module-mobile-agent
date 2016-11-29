using Newtonsoft.Json;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public partial class PropertyDictionaryValue
    {
        /// <summary>
        /// Initializes a new instance of the PropertyDictionaryValue class.
        /// </summary>
        public PropertyDictionaryValue() { }

        /// <summary>
        /// Initializes a new instance of the PropertyDictionaryValue class.
        /// </summary>
        public PropertyDictionaryValue(string id = default(string), string propertyId = default(string), string alias = default(string), string languageCode = default(string), string value = default(string))
        {
            Id = id;
            PropertyId = propertyId;
            Alias = alias;
            LanguageCode = languageCode;
            Value = value;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "propertyId")]
        public string PropertyId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "alias")]
        public string Alias { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "languageCode")]
        public string LanguageCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

    }
}
