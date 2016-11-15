using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Product(string manufacturerPartNumber = default(string), string gtin = default(string), string code = default(string), string name = default(string), string catalogId = default(string), string categoryId = default(string), string outline = default(string), string path = default(string), System.DateTime? indexingDate = default(System.DateTime?), string titularItemId = default(string), bool? isBuyable = default(bool?), bool? isActive = default(bool?), bool? trackInventory = default(bool?), int? maxQuantity = default(int?), int? minQuantity = default(int?), string productType = default(string), string weightUnit = default(string), double? weight = default(double?), string packageType = default(string), string measureUnit = default(string), double? height = default(double?), double? length = default(double?), double? width = default(double?), bool? enableReview = default(bool?), int? maxNumberOfDownload = default(int?), System.DateTime? downloadExpiration = default(System.DateTime?), string downloadType = default(string), bool? hasUserAgreement = default(bool?), string shippingType = default(string), string taxType = default(string), string vendor = default(string), int? priority = default(int?), string imgSrc = default(string), System.Collections.Generic.IList<Property> properties = default(System.Collections.Generic.IList<Property>), System.Collections.Generic.IList<Image> images = default(System.Collections.Generic.IList<Image>), System.Collections.Generic.IList<Asset> assets = default(System.Collections.Generic.IList<Asset>), System.Collections.Generic.IList<Product> variations = default(System.Collections.Generic.IList<Product>), System.Collections.Generic.IList<CategoryLink> links = default(System.Collections.Generic.IList<CategoryLink>), System.Collections.Generic.IList<EditorialReview> reviews = default(System.Collections.Generic.IList<EditorialReview>), System.Collections.Generic.IList<ProductAssociation> associations = default(System.Collections.Generic.IList<ProductAssociation>), System.Collections.Generic.IList<string> securityScopes = default(System.Collections.Generic.IList<string>), string seoObjectType = default(string), System.Collections.Generic.IList<SeoInfo> seoInfos = default(System.Collections.Generic.IList<SeoInfo>), System.Collections.Generic.IList<Outline> outlines = default(System.Collections.Generic.IList<Outline>), System.DateTime? createdDate = default(System.DateTime?), System.DateTime? modifiedDate = default(System.DateTime?), string createdBy = default(string), string modifiedBy = default(string), string id = default(string))
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
        [Newtonsoft.Json.JsonProperty(PropertyName = "manufacturerPartNumber")]
        public string ManufacturerPartNumber { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "gtin")]
        public string Gtin { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "catalogId")]
        public string CatalogId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "categoryId")]
        public string CategoryId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "outline")]
        public string Outline { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "path")]
        public string Path { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "indexingDate")]
        public System.DateTime? IndexingDate { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "titularItemId")]
        public string TitularItemId { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "isBuyable")]
        public bool? IsBuyable { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "isActive")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "trackInventory")]
        public bool? TrackInventory { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "maxQuantity")]
        public int? MaxQuantity { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "minQuantity")]
        public int? MinQuantity { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "productType")]
        public string ProductType { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "weightUnit")]
        public string WeightUnit { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "weight")]
        public double? Weight { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "packageType")]
        public string PackageType { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "measureUnit")]
        public string MeasureUnit { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "height")]
        public double? Height { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "length")]
        public double? Length { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "width")]
        public double? Width { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "enableReview")]
        public bool? EnableReview { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "maxNumberOfDownload")]
        public int? MaxNumberOfDownload { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "downloadExpiration")]
        public System.DateTime? DownloadExpiration { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "downloadType")]
        public string DownloadType { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "hasUserAgreement")]
        public bool? HasUserAgreement { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "shippingType")]
        public string ShippingType { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "taxType")]
        public string TaxType { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "vendor")]
        public string Vendor { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "priority")]
        public int? Priority { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "imgSrc")]
        public string ImgSrc { get; private set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties")]
        public System.Collections.Generic.IList<Property> Properties { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "images")]
        public System.Collections.Generic.IList<Image> Images { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "assets")]
        public System.Collections.Generic.IList<Asset> Assets { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "variations")]
        public System.Collections.Generic.IList<Product> Variations { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "links")]
        public System.Collections.Generic.IList<CategoryLink> Links { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "reviews")]
        public System.Collections.Generic.IList<EditorialReview> Reviews { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "associations")]
        public System.Collections.Generic.IList<ProductAssociation> Associations { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "securityScopes")]
        public System.Collections.Generic.IList<string> SecurityScopes { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "seoObjectType")]
        public string SeoObjectType { get; private set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "seoInfos")]
        public System.Collections.Generic.IList<SeoInfo> SeoInfos { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "outlines")]
        public System.Collections.Generic.IList<Outline> Outlines { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "createdDate")]
        public System.DateTime? CreatedDate { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "modifiedDate")]
        public System.DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "modifiedBy")]
        public string ModifiedBy { get; set; }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

    }
}
