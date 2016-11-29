using Newtonsoft.Json;
using System.Collections.Generic;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public class OutlineItem
    {
        /// <summary>
        /// Initializes a new instance of the OutlineItem class.
        /// </summary>
        public OutlineItem() { }

        /// <summary>
        /// Initializes a new instance of the OutlineItem class.
        /// </summary>
        public OutlineItem(string id = default(string), string seoObjectType = default(string), IList<SeoInfo> seoInfos = default(IList<SeoInfo>), bool? hasVirtualParent = default(bool?))
        {
            Id = id;
            SeoObjectType = seoObjectType;
            SeoInfos = seoInfos;
            HasVirtualParent = hasVirtualParent;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "seoObjectType")]
        public string SeoObjectType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "seoInfos")]
        public IList<SeoInfo> SeoInfos { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hasVirtualParent")]
        public bool? HasVirtualParent { get; set; }

    }
}
