using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.SyncModule.Data.Services
{
    public interface ISyncSettingsService
    {
        void SaveSettings(Models.MobileSetting setting);
        void RemoveSettings(string id);

        ICollection<Models.MobileSetting> GetAllSettings();
        Models.MobileSetting GetSettingsById(string id);
        Models.MobileSetting GetSettingsByAccountName(string name);
    }
}
