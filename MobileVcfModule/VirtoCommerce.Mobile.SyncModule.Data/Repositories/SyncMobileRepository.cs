using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using VirtoCommerce.Mobile.SyncModule.Data.Models;
using VirtoCommerce.Platform.Data.Infrastructure;
using VirtoCommerce.Platform.Data.Infrastructure.Interceptors;

namespace VirtoCommerce.Mobile.SyncModule.Data.Repositories
{
    public class SyncMobileRepository : EFRepositoryBase, ISyncMobileRepository
    {
        public SyncMobileRepository()
        {
        }
        public SyncMobileRepository(string nameOrConnectionString, params IInterceptor[] interceptors)
            : base(nameOrConnectionString, null, interceptors)
        {
            System.Data.Entity.Database.SetInitializer<SyncMobileRepository>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region MobileSetting
            modelBuilder.Entity<Entities.MobileSetting>().ToTable("MobileSettings").HasKey(x => x.Id).Property(x => x.Id);
            #endregion
        }
        #region ISyncMobileRepository
        public IQueryable<Entities.MobileSetting> MobileSettings
        {
            get
            {
                return GetAsQueryable<Entities.MobileSetting>();
            }
        }

        public ICollection<Entities.MobileSetting> GetAllSettings()
        {
            return MobileSettings.ToArray();
        }

        public Entities.MobileSetting GetSettingsById(string id)
        {
            return MobileSettings.FirstOrDefault(x => x.Id == id);
        }

        public void RemoveSettings(string id)
        {
            ObjectContext.ExecuteStoreCommand($"DELETE FROM MobileSettings where id='{id}'");
        }

        public void SaveSettings(Entities.MobileSetting setting)
        {
            if (string.IsNullOrEmpty(setting.Id))
            {
                setting.Id = Guid.NewGuid().ToString();
            }
            AddOrUpdate(setting);
            UnitOfWork.Commit();
        }
        #endregion

    }
}
