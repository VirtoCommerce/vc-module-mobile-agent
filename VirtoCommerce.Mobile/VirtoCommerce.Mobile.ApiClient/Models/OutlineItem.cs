using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public partial class OutlineItem
    {
        /// <summary>
        /// Initializes a new instance of the OutlineItem class.
        /// </summary>
        public OutlineItem() { }

        /// <summary>
        /// Initializes a new instance of the OutlineItem class.
        /// </summary>
        public OutlineItem(string id = default(string), string seoObjectType = default(string), System.Collections.Generic.IList<SeoInfo> seoInfos = default(System.Collections.Generic.IList<SeoInfo>), bool? hasVirtualParent = default(bool?))
        {
            Id = id;
            SeoObjectType = seoObjectType;
            SeoInfos = seoInfos;
            HasVirtualParent = hasVirtualParent;
        }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "seoObjectType")]
        public string SeoObjectType { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "seoInfos")]
        public System.Collections.Generic.IList<SeoInfo> SeoInfos { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "hasVirtualParent")]
        public bool? HasVirtualParent { get; set; }

    }
}
