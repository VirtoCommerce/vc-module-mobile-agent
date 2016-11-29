using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace VirtoCommerce.Mobile.ApiClient.Models
{
    public partial class Product
    {
        /// <summary>
        /// Initializes a new instance of the Product class.
        /// </summary>
        public Product() { }

        /// <summary>
        /// Initializes a new instance of the Product class.
        /// </summary>
        public Product(string manufacturerPartNumber = default(string), string gtin = default(string), string code = default(string), string name = default(string), string catalogId = default(string), string categoryId = default(string), string outline = default(string), string path = default(string), DateTime? indexingDate = default(DateTime?), string titularItemId = default(string), bool? isBuyable = default(bool?), bool? isActive = default(bool?), bool? trackInventory = default(bool?), int? maxQuantity = default(int?), int? minQuantity = default(int?), string productType = default(string), string weightUnit = default(string), double? weight = default(double?), string packageType = default(string), string measureUnit = default(string), double? height = default(double?), double? length = default(double?), double? width = default(double?), bool? enableReview = default(bool?), int? maxNumberOfDownload = default(int?), DateTime? downloadExpiration = default(DateTime?), string downloadType = default(string), bool? hasUserAgreement = default(bool?), string shippingType = default(string), string taxType = default(string), string vendor = default(string), int? priority = default(int?), string imgSrc = default(string), IList<Property> properties = default(IList<Property>), IList<Image> images = default(IList<Image>), IList<Asset> assets = default(IList<Asset>), IList<Product> variations = default(IList<Product>), IList<CategoryLink> links = default(IList<CategoryLink>), IList<EditorialReview> reviews = default(IList<EditorialReview>), IList<ProductAssociation> associations = default(IList<ProductAssociation>), IList<string> securityScopes = default(IList<string>), string seoObjectType = default(string), IList<SeoInfo> seoInfos = default(IList<SeoInfo>), IList<Outline> outlines = default(IList<Outline>), DateTime? createdDate = default(DateTime?), DateTime? modifiedDate = default(DateTime?), string createdBy = default(string), string modifiedBy = default(string), string id = default(string))
        {
            ManufacturerPartNumber = manufacturerPartNumber;
            Gtin = gtin;
            Code = code;
            Name = name;
            CatalogId = catalogId;
            CategoryId = categoryId;
            Outline = outline;
            Path = path;
            IndexingDate = indexingDate;
            TitularItemId = titularItemId;
            IsBuyable = isBuyable;
            IsActive = isActive;
            TrackInventory = trackInventory;
            MaxQuantity = maxQuantity;
            MinQuantity = minQuantity;
            ProductType = productType;
            WeightUnit = weightUnit;
            Weight = weight;
            PackageType = packageType;
            MeasureUnit = measureUnit;
            Height = height;
            Length = length;
            Width = width;
            EnableReview = enableReview;
            MaxNumberOfDownload = maxNumberOfDownload;
            DownloadExpiration = downloadExpiration;
            DownloadType = downloadType;
            HasUserAgreement = hasUserAgreement;
            ShippingType = shippingType;
            TaxType = taxType;
            Vendor = vendor;
            Priority = priority;
            ImgSrc = imgSrc;
            Properties = properties;
            Images = images;
            Assets = assets;
            Variations = variations;
            Links = links;
            Reviews = reviews;
            Associations = associations;
            SecurityScopes = securityScopes;
            SeoObjectType = seoObjectType;
            SeoInfos = seoInfos;
            Outlines = outlines;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            Id = id;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "manufacturerPartNumber")]
        public string ManufacturerPartNumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "gtin")]
        public string Gtin { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "catalogId")]
        public string CatalogId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "categoryId")]
        public string CategoryId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "outline")]
        public string Outline { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "indexingDate")]
        public DateTime? IndexingDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "titularItemId")]
        public string TitularItemId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isBuyable")]
        public bool? IsBuyable { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isActive")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "trackInventory")]
        public bool? TrackInventory { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "maxQuantity")]
        public int? MaxQuantity { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "minQuantity")]
        public int? MinQuantity { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "productType")]
        public string ProductType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "weightUnit")]
        public string WeightUnit { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "weight")]
        public double? Weight { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "packageType")]
        public string PackageType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "measureUnit")]
        public string MeasureUnit { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "height")]
        public double? Height { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "length")]
        public double? Length { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "width")]
        public double? Width { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "enableReview")]
        public bool? EnableReview { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "maxNumberOfDownload")]
        public int? MaxNumberOfDownload { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "downloadExpiration")]
        public DateTime? DownloadExpiration { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "downloadType")]
        public string DownloadType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hasUserAgreement")]
        public bool? HasUserAgreement { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "shippingType")]
        public string ShippingType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "taxType")]
        public string TaxType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "vendor")]
        public string Vendor { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "priority")]
        public int? Priority { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "imgSrc")]
        public string ImgSrc { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public IList<Property> Properties { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "images")]
        public IList<Image> Images { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "assets")]
        public IList<Asset> Assets { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "variations")]
        public IList<Product> Variations { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "links")]
        public IList<CategoryLink> Links { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "reviews")]
        public IList<EditorialReview> Reviews { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "associations")]
        public IList<ProductAssociation> Associations { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "securityScopes")]
        public IList<string> SecurityScopes { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "seoObjectType")]
        public string SeoObjectType { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "seoInfos")]
        public IList<SeoInfo> SeoInfos { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "outlines")]
        public IList<Outline> Outlines { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdDate")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "modifiedDate")]
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "modifiedBy")]
        public string ModifiedBy { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "prices")]
        public IList<Price> Prices { set; get; }
    }
}
