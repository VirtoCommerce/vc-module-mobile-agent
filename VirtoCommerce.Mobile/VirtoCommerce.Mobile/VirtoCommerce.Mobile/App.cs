using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using VirtoCommerce.Mobile.ApiClient;
using VirtoCommerce.Mobile.ApiClient.Api;
using VirtoCommerce.Mobile.Repositories;
using VirtoCommerce.Mobile.Services;

namespace VirtoCommerce.Mobile
{
    public class App : MvxApplication
    {

        private const string _appKey = "27e0d789f12641049bd0e939185b4fd2";
        private const string _secretKey = "34f0a3c12c9dbb59b63b5fece955b7b2b9a3b20f84370cba1524dd5c53503a2e2cb733536ecf7ea1e77319a47084a3a2c9d94d36069a432ecc73b72aeba6ea78";
        private const string _subFolder = "";
        private string _baseUrl = "http://192.168.1.148:8099/";

        public override void Initialize()
        {
            Mvx.RegisterType<IMvxAppStart, AppStart>();

            #region Services
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
            //global eventor
            Mvx.RegisterSingleton<IGlobalEventor>(new GlobalEventor());
            //tax service
            Mvx.RegisterType<ITaxService, TaxService>();
            //theme service
            Mvx.RegisterType<IThemeStorageService, ThemeStorageService>();
            //shipping service
            Mvx.RegisterType<IShippingMethodsService, ShippingMethodsService>();
            Mvx.RegisterType<IPaymentMethodService, PaymentMethodService>();
            #endregion

            #region Repositories
            Mvx.RegisterType<IUserRepository, PreferencesUserRepository>();
            Mvx.RegisterType<IProductRepository, SqlLiteProductRepository>();
            Mvx.RegisterType<ICartRepository, SqlLiteCartRepository>();
            Mvx.RegisterType<IThemeSettingsRepository, SqlLiteThemeSettingsRepository>();
            Mvx.RegisterType<IShippingRepository, SqlLiteShippingRepository>();
            Mvx.RegisterType<IPaymentRepository, SqlLitePaymentRepository>();
            Mvx.RegisterType<IOrderRepository, SqlLiteOrderRepository>();
            #endregion

            #region Api
            //base api client
            Mvx.RegisterSingleton<BaseApiClient>(new HmacApiClient(_baseUrl, _appKey, _secretKey, _subFolder));
            //
            Mvx.RegisterType<IPaymentApi, PaymentApi>();
            Mvx.RegisterType<ILoginApi, LoginApi>();
            Mvx.RegisterType<IProductApi, ProductApi>();
            Mvx.RegisterType<IThemeApi, ThemeApi>();
            Mvx.RegisterType<IShippingApi, ShippingApi>();
            Mvx.RegisterType<IOrderApi, OrderApi>();


            #endregion
        }
    }
}
