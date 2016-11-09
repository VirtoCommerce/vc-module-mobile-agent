using Microsoft.Practices.Unity;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtoCommerce.Mobile.Repositories;
using VirtoCommerce.Mobile.Services;

namespace VirtoCommerce.Mobile
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public static bool SyncComplete { get; set; }

        public override void Initialize()
        {
            Mvx.RegisterType<IMvxAppStart, AppStart>();
            //user manager
            Mvx.RegisterType<IUserManagerService, MockUserManagerService>();
            //sync service
            Mvx.RegisterType<ISyncService, SyncService>();
            //sync server service
            Mvx.RegisterType<ISyncServerService, MockSyncServerService>();
            //product storage service
            Mvx.RegisterType<IProductStorageService, ProductStorageService>();
            //cart service
            Mvx.RegisterType<ICartService, CartService>();
            //order service
            Mvx.RegisterType<IOrderService, OrderService>();
            //filter service
            Mvx.RegisterType<IFilterService, FilterService>();
            //product repository
            Mvx.RegisterType<ISqlLiteProductRepository, SqlLiteProductRepository>();
        }
    }
}
