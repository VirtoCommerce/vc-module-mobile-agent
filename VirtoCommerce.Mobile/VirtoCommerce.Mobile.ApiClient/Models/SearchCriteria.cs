using Newtonsoft.Json;
using System.Collections.Generic;

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
        public SearchCriteria(string storeId = default(string), string responseGroup = default(string), string keyword = default(string), bool? searchInChildren = default(bool?), bool? searchInVariations = default(bool?), string categoryId = default(string), IList<string> categoryIds = default(IList<string>), string catalogId = default(string), IList<string> catalogIds = default(IList<string>), string languageCode = default(string), string code = default(string), string sort = default(string), bool? hideDirectLinkedCategories = default(bool?), IList<PropertyValue> propertyValues = default(IList<PropertyValue>), string currency = default(string), double? startPrice = default(double?), double? endPrice = default(double?), int? skip = default(int?), int? take = default(int?), System.DateTime? indexDate = default(System.DateTime?), string pricelistId = default(string), IList<string> pricelistIds = default(IList<string>), IList<string> terms = default(IList<string>), IList<string> facets = default(IList<string>), string outline = default(string), bool? withHidden = default(bool?), bool? onlyBuyable = default(bool?), bool? onlyWithTrackingInventory = default(bool?), string productType = default(string), IList<string> productTypes = default(IList<string>), string vendorId = default(string), IList<string> vendorIds = default(IList<string>), System.DateTime? startDateFrom = default(System.DateTime?))
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
        [JsonProperty(PropertyName = "storeId")]
        public string StoreId { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'none', 'withProducts',
        /// 'withCategories', 'withProperties', 'withCatalogs',
        /// 'withVariations', 'withPriceRanges', 'withOutlines', 'full'
        /// </summary>
        [JsonProperty(PropertyName = "responseGroup")]
        public string ResponseGroup { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "keyword")]
        public string Keyword { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "searchInChildren")]
        public bool? SearchInChildren { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "searchInVariations")]
        public bool? SearchInVariations { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "categoryId")]
        public string CategoryId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "categoryIds")]
        public IList<string> CategoryIds { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "catalogId")]
        public string CatalogId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "catalogIds")]
        public IList<string> CatalogIds { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "languageCode")]
        public string LanguageCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sort")]
        public string Sort { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hideDirectLinkedCategories")]
        public bool? HideDirectLinkedCategories { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "propertyValues")]
        public IList<PropertyValue> PropertyValues { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "startPrice")]
        public double? StartPrice { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "endPrice")]
        public double? EndPrice { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "skip")]
        public int? Skip { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "take")]
        public int? Take { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "indexDate")]
        public System.DateTime? IndexDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "pricelistId")]
        public string PricelistId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "pricelistIds")]
        public IList<string> PricelistIds { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "terms")]
        public IList<string> Terms { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "facets")]
        public IList<string> Facets { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "outline")]
        public string Outline { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "withHidden")]
        public bool? WithHidden { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "onlyBuyable")]
        public bool? OnlyBuyable { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "onlyWithTrackingInventory")]
        public bool? OnlyWithTrackingInventory { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "productType")]
        public string ProductType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "productTypes")]
        public IList<string> ProductTypes { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "vendorId")]
        public string VendorId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "vendorIds")]
        public IList<string> VendorIds { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "startDateFrom")]
        public System.DateTime? StartDateFrom { get; set; }

    }
}
