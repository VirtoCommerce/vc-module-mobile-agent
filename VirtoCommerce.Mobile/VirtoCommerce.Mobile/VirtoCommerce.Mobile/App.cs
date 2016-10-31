using Microsoft.Practices.Unity;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtoCommerce.Mobile.Services;
using VirtoCommerce.Mobile.ViewModels;
using VirtoCommerce.Mobile.Views;
using Xamarin.Forms;

namespace VirtoCommerce.Mobile
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public static bool SyncComplete { get; set; }

        public override void Initialize()
        {
           /* CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();*/
            RegisterAppStart<LoginViewModel>();
            //user manager
            Mvx.RegisterType<IUserManagerService, MockUserManagerService>();
            //navigation service
            Mvx.RegisterType<INavigationService, NavigationService>();
            //sync service
            Mvx.RegisterType<ISyncService, SyncService>();
            //sync server service
            Mvx.RegisterType<ISyncServerService, MockSyncServerService>();
            //product storage service
            Mvx.RegisterType<IProductStorageService, ProductStorageService>();
        }
    }
}
