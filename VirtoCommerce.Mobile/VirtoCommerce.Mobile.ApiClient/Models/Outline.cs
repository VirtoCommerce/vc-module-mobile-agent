using Newtonsoft.Json;
using System.Collections.Generic;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public class Outline
    {
        /// <summary>
        /// Initializes a new instance of the Outline class.
        /// </summary>
        public Outline() { }

        /// <summary>
        /// Initializes a new instance of the Outline class.
        /// </summary>
        public Outline(IList<OutlineItem> items = default(IList<OutlineItem>))
        {
            Items = items;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "items")]
        public IList<OutlineItem> Items { get; set; }

    }
}
