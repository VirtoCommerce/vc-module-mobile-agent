using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public partial class EditorialReview
    {
        /// <summary>
        /// Initializes a new instance of the EditorialReview class.
        /// </summary>
        public EditorialReview() { }

        /// <summary>
        /// Initializes a new instance of the EditorialReview class.
        /// </summary>
        public EditorialReview(string id = default(string), string content = default(string), string reviewType = default(string), string languageCode = default(string), bool? isInherited = default(bool?))
        {
            Id = id;
            Content = content;
            ReviewType = reviewType;
            LanguageCode = languageCode;
            IsInherited = isInherited;
        }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "reviewType")]
        public string ReviewType { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "languageCode")]
        public string LanguageCode { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "isInherited")]
        public bool? IsInherited { get; set; }

    }
}
