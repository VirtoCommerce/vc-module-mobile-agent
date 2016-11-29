using Newtonsoft.Json;
using System;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public partial class SeoInfo
    {
        /// <summary>
        /// Initializes a new instance of the SeoInfo class.
        /// </summary>
        public SeoInfo() { }

        /// <summary>
        /// Initializes a new instance of the SeoInfo class.
        /// </summary>
        public SeoInfo(string name = default(string), string semanticUrl = default(string), string pageTitle = default(string), string metaDescription = default(string), string imageAltDescription = default(string), string metaKeywords = default(string), string storeId = default(string), string objectId = default(string), string objectType = default(string), bool? isActive = default(bool?), string languageCode = default(string), DateTime? createdDate = default(DateTime?), DateTime? modifiedDate = default(DateTime?), string createdBy = default(string), string modifiedBy = default(string), string id = default(string))
        {
            Name = name;
            SemanticUrl = semanticUrl;
            PageTitle = pageTitle;
            MetaDescription = metaDescription;
            ImageAltDescription = imageAltDescription;
            MetaKeywords = metaKeywords;
            StoreId = storeId;
            ObjectId = objectId;
            ObjectType = objectType;
            IsActive = isActive;
            LanguageCode = languageCode;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            Id = id;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "semanticUrl")]
        public string SemanticUrl { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "pageTitle")]
        public string PageTitle { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "metaDescription")]
        public string MetaDescription { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "imageAltDescription")]
        public string ImageAltDescription { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "metaKeywords")]
        public string MetaKeywords { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "storeId")]
        public string StoreId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "objectId")]
        public string ObjectId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "objectType")]
        public string ObjectType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isActive")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "languageCode")]
        public string LanguageCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdDate")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "modifiedDate")]
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "modifiedBy")]
        public string ModifiedBy { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

    }
}
