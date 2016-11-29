using Newtonsoft.Json;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public class MobileTheme
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { set; get; }

        [JsonProperty(PropertyName = "mainColor")]
        public string MainColor { set; get; }

    }
}
