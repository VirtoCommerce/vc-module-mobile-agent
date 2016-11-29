using System.Linq;
using VirtoCommerce.Mobile.ApiClient.Models;
using VirtoCommerce.Mobile.Entities;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.Convertors
{
    public static class PropertyConvertors
    {
        public static ProductPropertyEntity ApiPropertyValueToPropertyEntity(this PropertyValue pv, Property pr, string productId)
        {
            return new ProductPropertyEntity
            {
                PropertyName = pv.PropertyName,
                PropertyId = pv.PropertyId,
                Alias = pv.Alias,
                Id = pv.Id,
                LanguageCode = pv.LanguageCode,
                ValueType = pv.ValueType,
                Value = !string.IsNullOrEmpty(pv.ValueId) ? pr.DictionaryValues?.FirstOrDefault(x => x.Id == pv.Id)?.Value : pv.Value,
                PropertyDisplayName = pr.DisplayNames?.FirstOrDefault(x => x.LanguageCode == pv.LanguageCode)?.Name ?? pv.PropertyName,
                ProductId = productId
            };
        }

        public static ProductProperty PropertyEntityToProperty(this ProductPropertyEntity prop)
        {
            return new ProductProperty
            {
                Alias = prop.Alias,
                LanguageCode = prop.LanguageCode,
                ProductId = prop.ProductId,
                DisplayName = prop.PropertyDisplayName,
                PropertyId = prop.PropertyId,
                PropertyName = prop.PropertyName,
                Value = prop.Value,
                ValueType = prop.ValueType
            };
        }
    }
}
