using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.ApiClient.Models;

namespace VirtoCommerce.Mobile.ApiClient.Api
{
    public class ProductApi : BaseApi, IProductApi
    {
        public ProductApi(BaseApiClient client) : base(client)
        { }
        public async Task<CatalogSearchResult> GetProductsAsync()
        {
            var result = await Client.PostJsonRequestAsync<CatalogSearchResult, SearchCriteria>("api/catalog/search", new SearchCriteria()
            {
                CategoryId = "2459df4f7dcd4f90b86085cc491a664b",
                ResponseGroup = "withProducts",
                Take = int.MaxValue
            });
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
    }
}
