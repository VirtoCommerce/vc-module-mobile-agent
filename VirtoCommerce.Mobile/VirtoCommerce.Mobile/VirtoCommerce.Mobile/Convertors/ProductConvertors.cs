using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.ApiClient.Models;
using VirtoCommerce.Mobile.Entities;

namespace VirtoCommerce.Mobile.Convertors
{
    public static class ProductConvertors
    {
        public static ProductEntity ApiProductToProductEntity(this ApiClient.Models.Product product)
        {
            return new ProductEntity
            {
                Id = product.Id,
                CatalogId = product.CatalogId,
                CategoryId = product.CategoryId,
                Code = product.Code,
                CreatedBy = product.CreatedBy,
                CreatedDate = product.CreatedDate,
                DownloadExpiration = product.DownloadExpiration,
                DownloadType = product.DownloadType,
                EnableReview = product.EnableReview,
                Gtin = product.Gtin,
                HasUserAgreement = product.HasUserAgreement,
                Height = product.Height,
                IndexingDate = product.IndexingDate,
                ImgSrc = Path.GetFileName(product.ImgSrc),
                IsActive = product.IsActive,
                IsBuyable = product.IsBuyable,
                Length = product.Length,
                ManufacturerPartNumber = product.ManufacturerPartNumber,
                MaxNumberOfDownload = product.MaxNumberOfDownload,
                MaxQuantity = product.MaxQuantity,
                MeasureUnit = product.MeasureUnit,
                MinQuantity = product.MinQuantity,
                ModifiedBy = product.ModifiedBy,
                ModifiedDate = product.ModifiedDate,
                Name = product.Name,
                Outline = product.Outline,
                PackageType = product.PackageType,
                Path = product.Path,
                Priority = product.Priority,
                ProductType = product.ProductType,
                ShippingType = product.ShippingType,
                TaxType = product.TaxType,
                TitularItemId = product.TitularItemId,
                TrackInventory = product.TrackInventory,
                Vendor = product.Vendor,
                Weight = product.Weight,
                WeightUnit = product.WeightUnit,
                Width = product.Width
            };
        }
        public static Model.Product ProductEntityToProduct(this ProductEntity product)
        {
            return new Model.Product
            {
                Id = product.Id,
                CatalogId = product.CatalogId,
                CategoryId = product.CategoryId,
                Code = product.Code,
                CreatedBy = product.CreatedBy,
                CreatedDate = product.CreatedDate,
                DownloadExpiration = product.DownloadExpiration,
                DownloadType = product.DownloadType,
                EnableReview = product.EnableReview,
                Gtin = product.Gtin,
                HasUserAgreement = product.HasUserAgreement,
                Height = product.Height,
                IsActive = product.IsActive,
                IsBuyable = product.IsBuyable,
                Length = product.Length,
                ManufacturerPartNumber = product.ManufacturerPartNumber,
                MaxNumberOfDownload = product.MaxNumberOfDownload,
                MaxQuantity = product.MaxQuantity,
                MeasureUnit = product.MeasureUnit,
                MinQuantity = product.MinQuantity,
                ModifiedBy = product.ModifiedBy,
                ModifiedDate = product.ModifiedDate,
                Name = product.Name,
                Outline = product.Outline,
                PackageType = product.PackageType,
                Path = product.Path,
                Priority = product.Priority,
                ProductType = product.ProductType,
                ShippingType = product.ShippingType,
                TaxType = product.TaxType,
                TitularItemId = product.TitularItemId,
                TrackInventory = product.TrackInventory,
                Vendor = product.Vendor,
                Weight = product.Weight,
                WeightUnit = product.WeightUnit,
                Width = product.Width,
                TitleImage = product.ImgSrc
            };
        }
    }
}
