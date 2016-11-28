using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.SyncModule.Data.Models;
using VirtoCommerce.Mobile.SyncModule.Data.Repositories;
using VirtoCommerce.Platform.Data.Repositories;
using VirtoCommerce.Mobile.SyncModule.Data.Convertors;

namespace VirtoCommerce.Mobile.SyncModule.Data.Services
{
    public class SyncSettingsService : ISyncSettingsService
    {
        private readonly Func<ISyncMobileRepository> _syncMobileRepositoryFactory;
        private readonly Func<IPlatformRepository> _platformRepositoryFactory;

        public SyncSettingsService(Func<ISyncMobileRepository>  syncRepositoryFactory, Func<IPlatformRepository> platformRepositoryFactory)
        {
            _syncMobileRepositoryFactory = syncRepositoryFactory;
            _platformRepositoryFactory = platformRepositoryFactory;
        }
        public ICollection<MobileSetting> GetAllSettings()
        {
            using (var settingRepository = _syncMobileRepositoryFactory())
            {
                var settings = settingRepository.GetAllSettings().Select(x => x.ToModel()).ToArray();
                var accountIds = settings.Select(x => x.AccountId);
                using (var platformRepository = _platformRepositoryFactory())
                {
                    var accounts = platformRepository.Accounts.Where(x => accountIds.Contains(x.Id));
                    foreach (var setting in settings)
                    {
                        setting.UserName = accounts.FirstOrDefault(x => x.Id == setting.AccountId)?.UserName;
                    }
                }
                return settings;
            }
        }
        
        public MobileSetting GetSettingsByAccountName(string name)
        {
            using (var settingRepository = _syncMobileRepositoryFactory())
            {
                
                var settings = settingRepository.GetAllSettings();
                using (var platformRepository = _platformRepositoryFactory())
                {
                    var account = platformRepository.GetAccountByName(name, Platform.Core.Security.UserDetails.Export);
                    foreach (var setting in settings)
                    {
                        if (setting.AccountId == account.Id)
                        {
                            var result = setting.ToModel();
                            result.UserName = account.UserName;
                            return result;
                        }
                    }
                }
                return null;
            }
        }

        public MobileSetting GetSettingsById(string id)
        {
            throw new NotImplementedException();
        }

        public void RemoveSettings(string id)
        {
            throw new NotImplementedException();
        }

        public void SaveSettings(MobileSetting setting)
        {
            using (var syncRepository = _syncMobileRepositoryFactory())
            {
                syncRepository.SaveSettings(setting.ToEntityModel());
            }
        }
    }
}
