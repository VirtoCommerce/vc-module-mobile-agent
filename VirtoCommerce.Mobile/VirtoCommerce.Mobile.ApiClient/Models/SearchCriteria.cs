using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public partial class SearchCriteria
    {
        /// <summary>
        /// Initializes a new instance of the SearchCriteria class.
        /// </summary>
        public SearchCriteria() { }

        /// <summary>
        /// Initializes a new instance of the SearchCriteria class.
        /// </summary>
        /// <param name="responseGroup">Possible values include: 'none',
        /// 'withProducts', 'withCategories', 'withProperties',
        /// 'withCatalogs', 'withVariations', 'withPriceRanges',
        /// 'withOutlines', 'full'</param>
        public SearchCriteria(string storeId = default(string), string responseGroup = default(string), string keyword = default(string), bool? searchInChildren = default(bool?), bool? searchInVariations = default(bool?), string categoryId = default(string), System.Collections.Generic.IList<string> categoryIds = default(System.Collections.Generic.IList<string>), string catalogId = default(string), System.Collections.Generic.IList<string> catalogIds = default(System.Collections.Generic.IList<string>), string languageCode = default(string), string code = default(string), string sort = default(string), bool? hideDirectLinkedCategories = default(bool?), System.Collections.Generic.IList<PropertyValue> propertyValues = default(System.Collections.Generic.IList<PropertyValue>), string currency = default(string), double? startPrice = default(double?), double? endPrice = default(double?), int? skip = default(int?), int? take = default(int?), System.DateTime? indexDate = default(System.DateTime?), string pricelistId = default(string), System.Collections.Generic.IList<string> pricelistIds = default(System.Collections.Generic.IList<string>), System.Collections.Generic.IList<string> terms = default(System.Collections.Generic.IList<string>), System.Collections.Generic.IList<string> facets = default(System.Collections.Generic.IList<string>), string outline = default(string), bool? withHidden = default(bool?), bool? onlyBuyable = default(bool?), bool? onlyWithTrackingInventory = default(bool?), string productType = default(string), System.Collections.Generic.IList<string> productTypes = default(System.Collections.Generic.IList<string>), string vendorId = default(string), System.Collections.Generic.IList<string> vendorIds = default(System.Collections.Generic.IList<string>), System.DateTime? startDateFrom = default(System.DateTime?))
        {
            StoreId = storeId;
            ResponseGroup = responseGroup;
            Keyword = keyword;
            SearchInChildren = searchInChildren;
            SearchInVariations = searchInVariations;
            CategoryId = categoryId;
            CategoryIds = categoryIds;
            CatalogId = catalogId;
            CatalogIds = catalogIds;
            LanguageCode = languageCode;
            Code = code;
            Sort = sort;
            HideDirectLinkedCategories = hideDirectLinkedCategories;
            PropertyValues = propertyValues;
            Currency = currency;
            StartPrice = startPrice;
            EndPrice = endPrice;
            Skip = skip;
            Take = take;
            IndexDate = indexDate;
            PricelistId = pricelistId;
            PricelistIds = pricelistIds;
            Terms = terms;
            Facets = facets;
            Outline = outline;
            WithHidden = withHidden;
            OnlyBuyable = onlyBuyable;
            OnlyWithTrackingInventory = onlyWithTrackingInventory;
            ProductType = productType;
            ProductTypes = productTypes;
            VendorId = vendorId;
            VendorIds = vendorIds;
            StartDateFrom = startDateFrom;
        }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "storeId")]
        public string StoreId { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'none', 'withProducts',
        /// 'withCategories', 'withProperties', 'withCatalogs',
        /// 'withVariations', 'withPriceRanges', 'withOutlines', 'full'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "responseGroup")]
        public string ResponseGroup { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "keyword")]
        public string Keyword { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "searchInChildren")]
        public bool? SearchInChildren { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "searchInVariations")]
        public bool? SearchInVariations { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "categoryId")]
        public string CategoryId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "categoryIds")]
        public System.Collections.Generic.IList<string> CategoryIds { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "catalogId")]
        public string CatalogId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "catalogIds")]
        public System.Collections.Generic.IList<string> CatalogIds { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "languageCode")]
        public string LanguageCode { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "sort")]
        public string Sort { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "hideDirectLinkedCategories")]
        public bool? HideDirectLinkedCategories { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "propertyValues")]
        public System.Collections.Generic.IList<PropertyValue> PropertyValues { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "startPrice")]
        public double? StartPrice { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "endPrice")]
        public double? EndPrice { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "skip")]
        public int? Skip { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "take")]
        public int? Take { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "indexDate")]
        public System.DateTime? IndexDate { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "pricelistId")]
        public string PricelistId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "pricelistIds")]
        public System.Collections.Generic.IList<string> PricelistIds { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "terms")]
        public System.Collections.Generic.IList<string> Terms { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "facets")]
        public System.Collections.Generic.IList<string> Facets { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "outline")]
        public string Outline { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "withHidden")]
        public bool? WithHidden { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "onlyBuyable")]
        public bool? OnlyBuyable { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "onlyWithTrackingInventory")]
        public bool? OnlyWithTrackingInventory { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "productType")]
        public string ProductType { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "productTypes")]
        public System.Collections.Generic.IList<string> ProductTypes { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "vendorId")]
        public string VendorId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "vendorIds")]
        public System.Collections.Generic.IList<string> VendorIds { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "startDateFrom")]
        public System.DateTime? StartDateFrom { get; set; }

    }
}
