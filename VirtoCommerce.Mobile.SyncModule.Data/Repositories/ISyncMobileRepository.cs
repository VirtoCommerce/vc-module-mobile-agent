using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.SyncModule.Data.Models;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Mobile.SyncModule.Data.Repositories
{
    public interface ISyncMobileRepository : IRepository
    {
        IQueryable<Entities.MobileSetting> MobileSettings { get; }

        void SaveSettings(Entities.MobileSetting setting);
        void RemoveSettings(string id);

        ICollection<Entities.MobileSetting> GetAllSettings();
        Entities.MobileSetting GetSettingsById(string id);
    }
}
