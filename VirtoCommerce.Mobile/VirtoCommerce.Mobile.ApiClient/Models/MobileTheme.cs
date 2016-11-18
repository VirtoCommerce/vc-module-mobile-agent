using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public class MobileTheme
    {
        public MobileTheme()
        {
            MainColor = new byte[4];
        }
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public string Id { set; get; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "mainColor")]
        public byte[] MainColor { set; get; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "logoPath")]
        public string LogoPath { set; get; }
    }
}
