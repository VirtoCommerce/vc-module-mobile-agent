using System.Linq;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Enums;
using VirtoCommerce.Mobile.Responses;
using VirtoCommerce.Mobile.Convertors;

namespace VirtoCommerce.Mobile.Services
{
    public class SyncService : ISyncService
    {
        private readonly ISyncServerService _syncServerService;
        private readonly IProductStorageService _productStorageService;
        private readonly IThemeStorageService _themeStorageService;
        private readonly IShippingMethodsService _shippingMethodsService;
        private readonly IPaymentMethodService _paymentMethodsService;
        private readonly IOrderService _orderService;

        public SyncService(IOrderService orderService, ISyncServerService serverSyncService, IProductStorageService productStorageService, IThemeStorageService themeStorageService, IShippingMethodsService shippingMethodsService, IPaymentMethodService paymentMethodsService)
        {
            _orderService = orderService;
            _syncServerService = serverSyncService;
            _productStorageService = productStorageService;
            _themeStorageService = themeStorageService;
            _shippingMethodsService = shippingMethodsService;
            _paymentMethodsService = paymentMethodsService;
        }
        public async Task<SyncResponse> SyncProducts()
        {
            var syncResponse = new SyncResponse();
            //get products from server
            var products = await _syncServerService.GetProducts();
            if (products.Status != ResponseStatus.Ok)
            {
                syncResponse.SyncStatus = SyncStatus.Error;
                syncResponse.Message = products.Message;
                return syncResponse;
            }
            _productStorageService.SaveProducts(products.Data);
            return syncResponse;
        }

        public async Task<SyncResponse> SyncCurrency()
        {
            var syncResponse = new SyncResponse();
            //get currency from server
            var currency = await _syncServerService.GetCurrency();
            if (currency.Status != ResponseStatus.Ok)
            {
                syncResponse.SyncStatus = SyncStatus.Error;
                syncResponse.Message = currency.Message;
                return syncResponse;
            }
            _productStorageService.SaveCurrency(currency.Data);
            return syncResponse;
        }

        public async Task<SyncResponse> SyncFilters()
        {
            var syncResponse = new SyncResponse();
            //get filters from server
            var filters = await _syncServerService.GetFilters();
            if (filters.Status != ResponseStatus.Ok)
            {
                syncResponse.SyncStatus = SyncStatus.Error;
                syncResponse.Message = filters.Message;
                return syncResponse;
            }
            return syncResponse;
        }

        public async Task<SyncResponse> SyncTheme()
        {
            var syncResponse = new SyncResponse();
            var theme = await _syncServerService.GetTheme();
            if (theme.Status != ResponseStatus.Ok)
            {
                syncResponse.SyncStatus = SyncStatus.Error;
                syncResponse.Message = theme.Message;
                return syncResponse;
            }
            _themeStorageService.SaveTheme(theme.Data);
            return syncResponse;
        }

       public async  Task<SyncResponse> SyncShippingMethods() {
            var syncResponse = new SyncResponse();
            var shippingMethods = await _syncServerService.GetShippingMethods();
            if (shippingMethods.Status != ResponseStatus.Ok)
            {
                syncResponse.SyncStatus = SyncStatus.Error;
                syncResponse.Message = shippingMethods.Message;
                return syncResponse;
            }
            _shippingMethodsService.SaveShippingMethods(shippingMethods.Data);
            return syncResponse;
        }

        public async Task<SyncResponse> SyncPaymentMethods()
        {
            var syncResponse = new SyncResponse();
            var shippingMethods = await _syncServerService.GetPaymentMethods();
            if (shippingMethods.Status != ResponseStatus.Ok)
            {
                syncResponse.SyncStatus = SyncStatus.Error;
                syncResponse.Message = shippingMethods.Message;
                return syncResponse;
            }
            _paymentMethodsService.SaveMethods(shippingMethods.Data);
            return syncResponse;
        }

        public async Task<SyncResponse> SyncOrders()
        {
            var syncResponse = new SyncResponse();
            var orders = _orderService.GetNotSyncOrders();
            var orderResult = await _syncServerService.SendOrders(orders.Select(x => x.ModelToApiModel()).ToArray());
            if (orderResult.Status != ResponseStatus.Ok)
            {
                syncResponse.SyncStatus = SyncStatus.Error;
                syncResponse.Message = orderResult.Message;
                return syncResponse;
            }
            if (orderResult.Data)
            {
                foreach (var order in orders)
                {
                    order.IsSync = true;
                }
                _orderService.SetSyncStatusOrders(orders);
            }
            return syncResponse;
        }
    }
}
