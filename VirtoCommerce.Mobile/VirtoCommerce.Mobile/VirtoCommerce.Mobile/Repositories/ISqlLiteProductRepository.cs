using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Entities;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.Repositories
{
    public interface ISqlLiteProductRepository
    {
        ProductEntity GetProductById(string id);
        ProductEntity SaveProduct(ProductEntity product);
    }
}
