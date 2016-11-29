using Newtonsoft.Json;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public class Asset
    {
        /// <summary>
        /// Initializes a new instance of the Asset class.
        /// </summary>
        public Asset() { }

        /// <summary>
        /// Initializes a new instance of the Asset class.
        /// </summary>
        public Asset(long? size = default(long?), string mimeType = default(string), string id = default(string), string relativeUrl = default(string), string url = default(string), string typeId = default(string), string group = default(string), string name = default(string), string languageCode = default(string), bool? isInherited = default(bool?))
        {
            Size = size;
            MimeType = mimeType;
            Id = id;
            RelativeUrl = relativeUrl;
            Url = url;
            TypeId = typeId;
            Group = group;
            Name = name;
            LanguageCode = languageCode;
            IsInherited = isInherited;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "size")]
        public long? Size { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "mimeType")]
        public string MimeType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "relativeUrl")]
        public string RelativeUrl { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "typeId")]
        public string TypeId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "group")]
        public string Group { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "languageCode")]
        public string LanguageCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isInherited")]
        public bool? IsInherited { get; set; }

    }
}
