using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Entities;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.Convertors
{
    public static class PriceConvertors
    {
        public static PriceEntity PriceApiToPriceEntity(this ApiClient.Models.Price price)
        {
            return new PriceEntity
            {
                Currency = price.Currency,
                Id = price.Id,
                List = price.List,
                MinQuantity = price.MinQuantity,
                PricelistId = price.PricelistId,
                PriceListName = price.PriceListName,
                ProductId = price.ProductId,
                Sale = price.Sale,
                CreatedBy = price.CreatedBy,
                CreatedDate = price.CreatedDate,
                ModifiedBy = price.ModifiedBy,
                ModifiedDate = price.ModifiedDate
            };
        }

        public static Price PriceEntityToPrice(this PriceEntity price, CurrencyEntity currency)
        {
            return new Price
            {
                List = Convert.ToDecimal(price.List),
                Sale = Convert.ToDecimal(price.Sale),
                Currency = currency.EntitiesToModel()
            };
        }
    }
}
