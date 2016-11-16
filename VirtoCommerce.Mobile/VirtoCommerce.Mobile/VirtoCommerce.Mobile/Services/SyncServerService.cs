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
                var products = (await _productApi.GetProductsAsync()).Products.ToArray();
                int count = 20;
                int countRequestes =  products.Length / count + 1;

                
                for(var i = 0;i<countRequestes;i++)
                {
                    var ids = string.Join(",", products.Skip(i * count).Take(count).Select(x => x.Id));
                    if (!string.IsNullOrEmpty(ids))
                    {
                        var productWithReviews = await _productApi.GetProductsWithReviewsAsync(ids);
                        var productPrices = (await _productApi.GetProductPricesAsync(ids)).ProductPrices;
                        foreach (var prod in productWithReviews)
                        {
                            products.First(x => x.Id == prod.Id).Reviews = prod.Reviews;
                        }
                        foreach (var prod in productPrices)
                        {
                            products.First(x => x.Id == prod.ProductId).Prices = prod.Prices;
                        }
                    }
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
                throw ex;
            }
            return result;
            
        }
    }
}
