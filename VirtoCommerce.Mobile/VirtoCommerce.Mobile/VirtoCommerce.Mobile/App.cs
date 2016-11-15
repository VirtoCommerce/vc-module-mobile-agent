using Microsoft.Practices.Unity;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtoCommerce.Mobile.ApiClient;
using VirtoCommerce.Mobile.ApiClient.Api;
using VirtoCommerce.Mobile.Repositories;
using VirtoCommerce.Mobile.Services;

namespace VirtoCommerce.Mobile
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {

        private const string _appKey = "27e0d789f12641049bd0e939185b4fd2";
        private const string _secretKey = "34f0a3c12c9dbb59b63b5fece955b7b2b9a3b20f84370cba1524dd5c53503a2e2cb733536ecf7ea1e77319a47084a3a2c9d94d36069a432ecc73b72aeba6ea78";
        private const string _subFolder = "";
        private string _baseUrl = "http://192.168.88.186:8099/";

        public override void Initialize()
        {
            Mvx.RegisterType<IMvxAppStart, AppStart>();
            //user manager
            Mvx.RegisterType<IUserManagerService, UserManagerService>();
            //sync service
            Mvx.RegisterType<ISyncService, SyncService>();
            //sync server service
            Mvx.RegisterType<ISyncServerService, SyncServerService>();
            //product storage service
            Mvx.RegisterType<IProductStorageService, ProductStorageService>();
            //cart service
            Mvx.RegisterType<ICartService, CartService>();
            //order service
            Mvx.RegisterType<IOrderService, OrderService>();
            //filter service
            Mvx.RegisterType<IFilterService, FilterService>();
            //product repository
            Mvx.RegisterType<IProductRepository, SqlLiteProductRepository>();
            //global eventor
            Mvx.RegisterSingleton<IGlobalEventor>(new GlobalEventor());
            //register api client
            Mvx.RegisterSingleton<BaseApiClient>(new HmacApiClient(_baseUrl, _appKey, _secretKey, _subFolder));
            //user repository
            Mvx.RegisterType<IUserRepository, PreferencesUserRepository>();
            #region Api
            Mvx.RegisterType<ILoginApi, LoginApi>();
            Mvx.RegisterType<IProductApi, ProductApi>();
            #endregion
        }
    }
}
