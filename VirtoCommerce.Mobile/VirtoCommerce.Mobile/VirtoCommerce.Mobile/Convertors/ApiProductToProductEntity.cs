using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Entities;

namespace VirtoCommerce.Mobile.Convertors
{
    public static class ApiProductToProductEntity
    {
        public static ProductEntity ToProductEntity(this ApiClient.Models.Product product)
        {
            return new ProductEntity();
        }
    }
}
