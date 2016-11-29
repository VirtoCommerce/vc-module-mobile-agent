using Newtonsoft.Json;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public partial class PropertyDisplayName
    {
        /// <summary>
        /// Initializes a new instance of the PropertyDisplayName class.
        /// </summary>
        public PropertyDisplayName() { }

        /// <summary>
        /// Initializes a new instance of the PropertyDisplayName class.
        /// </summary>
        public PropertyDisplayName(string name = default(string), string languageCode = default(string))
        {
            Name = name;
            LanguageCode = languageCode;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "languageCode")]
        public string LanguageCode { get; set; }

    }
}
