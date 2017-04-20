using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtoCommerce.Domain.Pricing.Model;

namespace VirtoCommerce.Mobile.SyncModule.Web.Convertors
{
    public static class PriceConverter
    {
        public static Models.Price ToWebModel(this Price price)
        {
            var retVal = new Models.Price();
            retVal.InjectFrom(price);
            retVal.Currency = price.Currency;
            if (price.Pricelist != null)
            {
                retVal.PriceListName = price.Pricelist.Name;
            }
            return retVal;
        }

        public static Price ToCoreModel(this Models.Price price)
        {
            var retVal = new Price();
            retVal.InjectFrom(price);
            retVal.Currency = price.Currency;
            return retVal;
        }


    }
}