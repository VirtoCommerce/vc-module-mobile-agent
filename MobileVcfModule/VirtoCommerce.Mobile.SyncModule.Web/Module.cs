using Microsoft.Practices.Unity;
using System;
using VirtoCommerce.CatalogModule.Data.Repositories;
using VirtoCommerce.Mobile.SyncModule.Data.Repositories;
using VirtoCommerce.Mobile.SyncModule.Data.Services;
using VirtoCommerce.Platform.Core.ExportImport;
using VirtoCommerce.Platform.Core.Modularity;
using VirtoCommerce.Platform.Core.Security;
using VirtoCommerce.Platform.Data.Infrastructure;
using VirtoCommerce.Platform.Data.Infrastructure.Interceptors;
using VirtoCommerce.Platform.Data.Repositories;

namespace VirtoCommerce.Mobile.SyncModule.Web
{
    public class Module : ModuleBase
    {
        private const string _connectionStringName = "VirtoCommerce";
        private readonly IUnityContainer _container;

        public Module(IUnityContainer container)
        {
            _container = container;
        }

        #region IModule Members
        public override void SetupDatabase()
        {
            base.SetupDatabase();

            using (var db = new SyncMobileRepository(_connectionStringName, _container.Resolve<AuditableInterceptor>()))
            {
                var initializer = new SetupDatabaseInitializer<SyncMobileRepository, Data.Migrations.Configuration>();

                initializer.InitializeDatabase(db);
            }
        }

        public override void Initialize()
        {
            Func<ISyncMobileRepository> syncRepFactory = () =>
                new SyncMobileRepository(_connectionStringName, new EntityPrimaryKeyGeneratorInterceptor(), _container.Resolve<AuditableInterceptor>(),
                    new ChangeLogInterceptor(_container.Resolve<Func<IPlatformRepository>>(), ChangeLogPolicy.Cumulative, new[] { typeof(Data.Entities.MobileSetting).Name }, _container.Resolve<IUserNameResolver>()));

            _container.RegisterInstance(syncRepFactory);
            _container.RegisterType<ISyncSettingsService, SyncSettingsService>();
        }
        #endregion
    }
}
