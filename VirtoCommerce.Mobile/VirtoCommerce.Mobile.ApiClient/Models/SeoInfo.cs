using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public SeoInfo(string name = default(string), string semanticUrl = default(string), string pageTitle = default(string), string metaDescription = default(string), string imageAltDescription = default(string), string metaKeywords = default(string), string storeId = default(string), string objectId = default(string), string objectType = default(string), bool? isActive = default(bool?), string languageCode = default(string), System.DateTime? createdDate = default(System.DateTime?), System.DateTime? modifiedDate = default(System.DateTime?), string createdBy = default(string), string modifiedBy = default(string), string id = default(string))
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
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "semanticUrl")]
        public string SemanticUrl { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "pageTitle")]
        public string PageTitle { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "metaDescription")]
        public string MetaDescription { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "imageAltDescription")]
        public string ImageAltDescription { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "metaKeywords")]
        public string MetaKeywords { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "storeId")]
        public string StoreId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "objectId")]
        public string ObjectId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "objectType")]
        public string ObjectType { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "isActive")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "languageCode")]
        public string LanguageCode { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "createdDate")]
        public System.DateTime? CreatedDate { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "modifiedDate")]
        public System.DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "modifiedBy")]
        public string ModifiedBy { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

    }
}
