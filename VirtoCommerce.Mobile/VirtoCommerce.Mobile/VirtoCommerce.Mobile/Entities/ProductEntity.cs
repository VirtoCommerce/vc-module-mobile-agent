using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public System.DateTime? CreatedDate { get; set; }
        public System.DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        //
        //public System.Collections.Generic.IList<Property> Properties { get; set; }
        //public System.Collections.Generic.IList<Image> Images { get; set; }
        //public System.Collections.Generic.IList<Asset> Assets { get; set; }
        //public System.Collections.Generic.IList<Product> Variations { get; set; }
        //public System.Collections.Generic.IList<CategoryLink> Links { get; set; }
        //public System.Collections.Generic.IList<EditorialReview> Reviews { get; set; }
        //public System.Collections.Generic.IList<ProductAssociation> Associations { get; set; }
        //public System.Collections.Generic.IList<string> SecurityScopes { get; set; }
        //public string SeoObjectType { get; private set; }
        //public System.Collections.Generic.IList<SeoInfo> SeoInfos { get; set; }
        //public System.Collections.Generic.IList<Outline> Outlines { get; set; }
    }
}
