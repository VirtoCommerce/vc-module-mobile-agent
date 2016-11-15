using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;
        private static readonly JsonSerializerSettings _serializeSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.None,
            TypeNameHandling = TypeNameHandling.None,
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc
        };

        #region SettingsKeys 
        private const string UserKey = "User";
        #endregion

        public static User CurrentUser
        {
            get
            {
                return JsonConvert.DeserializeObject<User>(AppSettings.GetValueOrDefault(UserKey, string.Empty), _serializeSettings);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserKey, JsonConvert.SerializeObject(value, _serializeSettings));
            }
        }
    }
}
