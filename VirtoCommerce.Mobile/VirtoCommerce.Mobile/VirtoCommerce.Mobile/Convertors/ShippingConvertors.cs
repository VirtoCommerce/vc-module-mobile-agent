using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Convertors
{
    public static class ShippingConvertors
    {
        public static Entities.ShippingMethodEntity ApiModelToEntity(this ApiClient.Models.ShippingMethod method)
        {
            return new Entities.ShippingMethodEntity {
                Id = method.Id,
                Name = method.Name
            };
        }

        public static Model.ShippingMethod EntityToModel(this Entities.ShippingMethodEntity entity)
        {
            return new Model.ShippingMethod
            {
                Name = entity.Name,
                Id = entity.Id
            };
        }

        public static Entities.ShippingRateEntity ApiModelToEntity(this ApiClient.Models.ShippingRate rate)
        {
            return new Entities.ShippingRateEntity
            {
                Id = rate.OptionName,
                OptionName = rate.OptionName,
                DiscountAmount = (double)rate.DiscountAmount,
                DiscountAmountWithTax = (double)rate.DiscountAmountWithTax,
                OptionDescription = rate.OptionDescription,
                Rate = (double)rate.Rate,
                RateWithTax = (double)rate.RateWithTax
            };
        }

        public static Model.ShippingMethodRate EntityToMedel(this Entities.ShippingRateEntity rate)
        {
            return new Model.ShippingMethodRate
            {
                Rate = (decimal)rate.Rate,
                Name = rate.OptionName,
                Id = rate.Id
            };
        }
    }
}
