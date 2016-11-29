using System.Collections.Generic;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.ApiClient.Models;

namespace VirtoCommerce.Mobile.ApiClient.Api
{
    public class ProductApi : BaseApi, IProductApi
    {
        public ProductApi(BaseApiClient client) : base(client)
        { }
        public async Task<SyncProductResponseResult> GetProductsAsync(string userLogin)
        {
            if (string.IsNullOrEmpty(userLogin))
                return new SyncProductResponseResult();
            var result = await Client.GetRequestAsync<SyncProductResponseResult>($"api/mobile/sync/product/{userLogin}");
            return result;
        }

        public async Task<ICollection<Product>> GetProductsWithReviewsAsync(string ids)
        {
            var result = await Client.GetRequestAsync<ICollection<Product>>($"api/catalog/products?ids={ids}&respGroup=16");
            return result;
        }

        public async Task<ProductPricesSearchResult> GetProductPricesAsync(string ids)
        {
            var result = await Client.GetRequestAsync<ProductPricesSearchResult>($"api/catalog/products/prices/search?ProductIds={ids}");
            return result;
        }

        public async Task<Currency> GetCurrency(string userLogin)
        {
            return await Client.GetRequestAsync<Currency>($"api/mobile/sync/currency/{userLogin}");
        }
    }
}
