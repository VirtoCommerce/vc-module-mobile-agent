using System;

namespace VirtoCommerce.Mobile.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string ManufacturerPartNumber { get; set; }
        public string Gtin { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string CatalogId { get; set; }
        public string CategoryId { get; set; }
        public string Outline { get; set; }
        public string Path { get; set; }
        public System.DateTime? IndexingDate { get; set; }
        public string TitularItemId { get; set; }
        public bool? IsBuyable { get; set; }
        public bool? IsActive { get; set; }
        public bool? TrackInventory { get; set; }
        public int? MaxQuantity { get; set; }
        public int? MinQuantity { get; set; }
        public string ProductType { get; set; }
        public string WeightUnit { get; set; }
        public double? Weight { get; set; }
        public string PackageType { get; set; }
        public string MeasureUnit { get; set; }
        public double? Height { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public bool? EnableReview { get; set; }
        public int? MaxNumberOfDownload { get; set; }
        public System.DateTime? DownloadExpiration { get; set; }
        public string DownloadType { get; set; }
        public bool? HasUserAgreement { get; set; }
        public string ShippingType { get; set; }
        public string TaxType { get; set; }
        public string Vendor { get; set; }
        public int? Priority { get; set; }
        public string ImgSrc { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

    }
}
