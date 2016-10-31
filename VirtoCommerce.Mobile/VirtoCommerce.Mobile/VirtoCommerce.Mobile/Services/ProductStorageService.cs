using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.Services
{
    public class ProductStorageService : IProductStorageService
    {
        public ICollection<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public ICollection<Product> GetProduct(string id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Product> GetProducts(int start, int count)
        {
            return new[] {
                new Product {
                    Id = Guid.NewGuid().ToString(),
                    Name= "Prod 1",
                },
                new Product {
                    Id = Guid.NewGuid().ToString(),
                    Name= "Prod 2",
                }
            };
        }

        public bool SaveProducts(ICollection<Product> products)
        {
            return true;
        }
    }
}
