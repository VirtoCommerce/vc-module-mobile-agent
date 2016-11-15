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

namespace VirtoCommerce.Mobile.Services
{
    public class SyncServerService : ISyncServerService
    {
        private readonly IProductApi _productApi;
        public SyncServerService(IProductApi productApi)
        {
            _productApi = productApi;
        }
        public async Task<ServerResponseCollection<Filter>> GetFilters()
        {
            await Task.Delay(2000);
            return new ServerResponseCollection<Filter>() {
                Status = Enums.ResponseStatus.Ok,
            };
        }

        public async Task<ServerResponseCollection<ApiClient.Models.Product>> GetProducts()
        {
            var result = new ServerResponseCollection<ApiClient.Models.Product>();
            try
            {
                var products = await _productApi.GetProductsAsync();
                result.Data = products.Products.ToArray();
                result.Status = Enums.ResponseStatus.Ok;
            }
            catch (NoInternetConnectionException)
            {
                result.Status = Enums.ResponseStatus.NotConnected;
                result.Message = "No connection to the server";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
            
        }
    }
}
