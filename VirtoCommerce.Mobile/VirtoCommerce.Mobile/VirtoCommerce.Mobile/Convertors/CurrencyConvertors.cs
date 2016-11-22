using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Convertors
{
    public static class CurrencyConvertors
    {
        public static Entities.CurrencyEntity ApiToEntities(this ApiClient.Models.Currency currency)
        {
            return new Entities.CurrencyEntity
            {
                Code = currency.Code,
                CustomFormatting = currency.CustomFormatting,
                ExchangeRate = currency.ExchangeRate,
                Name = currency.Name,
                Symbol = currency.Symbol
            };
        }

        public static Model.Currency EntitiesToModel(this Entities.CurrencyEntity currency)
        {
            return new Model.Currency
            {
                Code = currency.Code,
                Symbol = currency.Symbol
            };
        }
    }
}
