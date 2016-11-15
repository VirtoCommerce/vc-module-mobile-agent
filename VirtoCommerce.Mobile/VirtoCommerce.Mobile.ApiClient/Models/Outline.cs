using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public partial class Outline
    {
        /// <summary>
        /// Initializes a new instance of the Outline class.
        /// </summary>
        public Outline() { }

        /// <summary>
        /// Initializes a new instance of the Outline class.
        /// </summary>
        public Outline(System.Collections.Generic.IList<OutlineItem> items = default(System.Collections.Generic.IList<OutlineItem>))
        {
            Items = items;
        }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "items")]
        public System.Collections.Generic.IList<OutlineItem> Items { get; set; }

    }
}
