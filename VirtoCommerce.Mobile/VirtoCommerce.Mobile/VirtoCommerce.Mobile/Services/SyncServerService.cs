using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.ApiClient.Api;
using VirtoCommerce.Mobile.Entities;
using VirtoCommerce.Mobile.Model;
using VirtoCommerce.Mobile.Responses;
using VirtoCommerce.Mobile.Convertors;
using VirtoCommerce.Mobile.ApiClient.Exceptions;
using VirtoCommerce.Mobile.Helpers;
using VirtoCommerce.Mobile.ApiClient.Models;

namespace VirtoCommerce.Mobile.Services
{
    public class SyncServerService : ISyncServerService
    {
        private readonly IProductApi _productApi;
        private readonly IThemeApi _themeApi;
        private readonly IShippingApi _shippingApi;
        private readonly IPaymentApi _paymentApi;
        private readonly IOrderApi _orderApi;
        public SyncServerService(IProductApi productApi, IThemeApi themeApi, IShippingApi shippingApi, IPaymentApi paymentApi, IOrderApi orderApi)
        {
            _themeApi = themeApi;
            _productApi = productApi;
            _shippingApi = shippingApi;
            _paymentApi = paymentApi;
            _orderApi = orderApi;
        }


        public async Task<ServerResponseCollection<Filter>> GetFilters()
        {
            await Task.Delay(1);
            return new ServerResponseCollection<Filter>() {
                Status = Enums.ResponseStatus.Ok,
            };
        }

        public async Task<ServerResponseCollection<ApiClient.Models.Product>> GetProducts()
        {
            var result = new ServerResponseCollection<ApiClient.Models.Product>();
            try
            {
                var requestResult = await _productApi.GetProductsAsync(Settings.CurrentUser?.Name);
                var products = requestResult.Products.ToArray();
                foreach (var price in requestResult.Prices)
                {
                    products.First(x => x.Id == price.ProductId).Prices = price.Prices;
                }
                result.Data = products;
                result.Status = Enums.ResponseStatus.Ok;
            }
            catch (NoInternetConnectionException)
            {
                result.Status = Enums.ResponseStatus.NotConnected;
                result.Message = "No connection to the server";
            }
            catch (Exception ex)
            {
                result.Status = Enums.ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
            
        }

        public async Task<ServerResponse<MobileTheme>> GetTheme()
        {
            var result = new ServerResponse<MobileTheme>();
            try
            {
                var requestResult = await _themeApi.GetThemeAsync(Settings.CurrentUser?.Name);

                result.Data = requestResult;
                result.Status = Enums.ResponseStatus.Ok;
            }
            catch (NoInternetConnectionException)
            {
                result.Status = Enums.ResponseStatus.NotConnected;
                result.Message = "No connection to the server";
            }
            catch (Exception ex)
            {
                result.Status = Enums.ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServerResponse<ApiClient.Models.Currency>> GetCurrency()
        {
            var result = new ServerResponse<ApiClient.Models.Currency>();
            try
            {
                var requestResult = await _productApi.GetCurrency(Settings.CurrentUser?.Name);

                result.Data = requestResult;
                result.Status = Enums.ResponseStatus.Ok;
            }
            catch (NoInternetConnectionException)
            {
                result.Status = Enums.ResponseStatus.NotConnected;
                result.Message = "No connection to the server";
            }
            catch (Exception ex)
            {
                result.Status = Enums.ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServerResponseCollection<ApiClient.Models.ShippingMethod>> GetShippingMethods()
        {
            var result = new ServerResponseCollection<ApiClient.Models.ShippingMethod>();
            try
            {
                var requestResult = await _shippingApi.GetShippingMethodsAsync(Settings.CurrentUser?.Name);

                result.Data = requestResult;
                result.Status = Enums.ResponseStatus.Ok;
            }
            catch (NoInternetConnectionException)
            {
                result.Status = Enums.ResponseStatus.NotConnected;
                result.Message = "No connection to the server";
            }
            catch (Exception ex)
            {
                result.Status = Enums.ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServerResponseCollection<ApiClient.Models.PaymentMethod>> GetPaymentMethods()
        {
            var result = new ServerResponseCollection<ApiClient.Models.PaymentMethod>();
            try
            {
                var requestResult = await _paymentApi.GetPaymentMethodsAsync(Settings.CurrentUser?.Name);
                result.Data = requestResult;
                result.Status = Enums.ResponseStatus.Ok;
            }
            catch (NoInternetConnectionException)
            {
                result.Status = Enums.ResponseStatus.NotConnected;
                result.Message = "No connection to the server";
            }
            catch (Exception ex)
            {
                result.Status = Enums.ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServerResponse<bool>> SendOrders(ICollection<ApiClient.Models.Order> orders)
        {
            var result = new ServerResponse<bool>();
            try
            {
                if (orders.Count != 0)
                {
                    var requestResult = await _orderApi.SyncOrdersAsync(orders, Settings.CurrentUser?.Name);
                    result.Data = requestResult;
                }
                else
                {
                    result.Data = true;
                }
                result.Status = Enums.ResponseStatus.Ok;
            }
            catch (NoInternetConnectionException)
            {
                result.Status = Enums.ResponseStatus.NotConnected;
                result.Message = "No connection to the server";
            }
            catch (Exception ex)
            {
                result.Status = Enums.ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
