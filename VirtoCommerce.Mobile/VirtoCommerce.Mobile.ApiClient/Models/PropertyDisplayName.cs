using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "languageCode")]
        public string LanguageCode { get; set; }

    }
}
