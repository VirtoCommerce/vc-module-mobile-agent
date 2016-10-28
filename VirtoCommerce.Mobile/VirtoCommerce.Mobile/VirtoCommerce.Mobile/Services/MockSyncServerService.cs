using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Model;
using VirtoCommerce.Mobile.Responses;

namespace VirtoCommerce.Mobile.Services
{
    public class MockSyncServerService : ISyncServerService
    {
        public async Task<ServerResponseCollection<Filter>> GetFilters()
        {
            await Task.Delay(2000);
            return new ServerResponseCollection<Filter>();
        }

        public async Task<ServerResponseCollection<Product>> GetProducts()
        {
            await Task.Delay(2000);
            return new ServerResponseCollection<Product>()
            {
                Data = new Product[] {
                    new Product
                    {
                        Name = "Prod 1",
                        Id = Guid.NewGuid().ToString()
                    },
                    new Product {
                        Name = "Prod 2",
                        Id = Guid.NewGuid().ToString()
                    }
                }
            };
        }
    }
}
