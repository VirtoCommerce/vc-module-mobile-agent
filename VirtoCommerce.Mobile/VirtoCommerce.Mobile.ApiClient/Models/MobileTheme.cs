using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public class MobileTheme
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public string Id { set; get; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "mainColor")]
        public string MainColor { set; get; }

    }
}
