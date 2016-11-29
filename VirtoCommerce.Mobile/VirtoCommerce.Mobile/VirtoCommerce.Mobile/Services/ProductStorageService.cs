using System;
using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Mobile.Model;
using VirtoCommerce.Mobile.Repositories;
using VirtoCommerce.Mobile.Convertors;
using VirtoCommerce.Mobile.Entities;
using Xamarin.Forms;
using System.IO;
using ApiModel = VirtoCommerce.Mobile.ApiClient.Models;

namespace VirtoCommerce.Mobile.Services
{
    public class ProductStorageService : IProductStorageService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILocalStorageImageService _imageService;
        public ProductStorageService(IProductRepository productRepository)
        {
            _imageService = DependencyService.Get<ILocalStorageImageService>();
            _productRepository = productRepository;
        }
        public ICollection<Product> GetAllProducts()
        {
            return GetProducts(0, int.MaxValue);
        }

        private Product PrepareProduct(Product product, CurrencyEntity currency)
        {
            
            product.Reviews = _productRepository.GetReviewsByProduct(product.Id).Select(x => x.ReviewEntityToReview()).ToArray();
            product.Images = _productRepository.GetImagesByProduct(product.Id).Select(x => x.PhysicalPath).ToArray();
            product.TitleImage = product.Images.FirstOrDefault(x => Path.GetFileName(x) == product.TitleImage);
            product.Price = _productRepository.GetPricesByProduct(product.Id).FirstOrDefault(x => x.Currency == currency.Code)?.PriceEntityToPrice(currency);
            product.Properties = _productRepository.GetProductProperties(product.Id).Select(x => x.PropertyEntityToProperty()).ToArray();
            return product;
        }

        public Product GetProduct(string id)
        {
            var product = _productRepository.GetProductById(id).ProductEntityToProduct();
            if (product != null)
            {
                PrepareProduct(product, _productRepository.GetCurrentCurrency());
            }
            return product;
        }

        public ICollection<Product> GetProducts(int start, int count)
        {
            var result = _productRepository.GetAllProducts().Skip(start).Take(count).Select(x => x.ProductEntityToProduct()).ToArray();
            var currency = _productRepository.GetCurrentCurrency();
            foreach (var prod in result)
            {
                PrepareProduct(prod, currency);
            }
            return result.ToArray();
        }

        public int GetProductsCount()
        {
            return _productRepository.GetProductCount();
        }


        public bool SaveProducts(ICollection<ApiModel.Product> products)
        {
            try
            {
                _productRepository.StartTransaction();
                foreach (var prod in products)
                {

                    //save main product
                    if (!_productRepository.SaveProduct(prod.ApiProductToProductEntity()))
                    {
                        continue;
                    }
                    //set
                    if (prod.Images == null)
                    {
                        prod.Images = new ApiModel.Image[0];
                    }
                    if (prod.Prices == null)
                    {
                        prod.Prices = new ApiModel.Price[0];
                    }
                    if (prod.Reviews == null)
                    {
                        prod.Reviews = new ApiModel.EditorialReview[0];
                    }
                    if (prod.Properties == null)
                    {
                        prod.Properties = new ApiModel.Property[0];
                    }

                    //save images for product
                    foreach (var image in prod.Images)
                    {
                        var imgEntity = new ImageEntity
                        {
                            Id = image.Id,
                            ProductId = prod.Id,
                            PhysicalPath = _imageService.SaveImage(new Model.Image
                            {
                                Name = image.Name,
                                Path = image.Url
                            }, prod.Id)
                        };
                        _productRepository.SaveImage(imgEntity);
                    }
                    //delete old images
                    var oldImages = _productRepository.GetImagesByProduct(prod.Id);
                    foreach (var image in oldImages)
                    {
                        if (prod.Images.FirstOrDefault(x => x.Id == image.Id) == null)
                        {
                            _productRepository.DeleteImageById(image.Id);
                        }
                    }
                    //save reviews 
                    foreach (var review in prod.Reviews)
                    {
                        var reviewEntity = new ReviewEntity
                        {
                            Id = review.Id,
                            Content = review.Content,
                            ReviewType = review.ReviewType,
                            LanguageCode = review.LanguageCode,
                            ProductId = prod.Id
                        };
                        _productRepository.SaveReview(reviewEntity);
                    }
                    //delete old reviews
                    var oldReviews = _productRepository.GetReviewsByProduct(prod.Id);
                    foreach (var review in oldReviews)
                    {
                        if (prod.Reviews.FirstOrDefault(x => x.Id == review.Id) == null)
                        {
                            _productRepository.DeleteReviewById(review.Id);
                        }
                    }
                    //save price
                    foreach (var price in prod.Prices)
                    {
                        _productRepository.SavePrice(price.PriceApiToPriceEntity());
                    }
                    //delete old prices
                    var oldPrices = _productRepository.GetPricesByProduct(prod.Id);
                    foreach (var price in oldPrices)
                    {
                        if (prod.Prices.FirstOrDefault(x => x.Id == price.Id) == null)
                        {
                            _productRepository.DeletePriceById(price.Id);
                        }
                    }
                    //save properties
                    foreach (var prop in prod.Properties)
                    {
                        foreach (var propVl in prop.Values)
                        {
                            _productRepository.SaveProductProperty(propVl.ApiPropertyValueToPropertyEntity(prop, prod.Id));
                        }
                    }
                    //delete old properties
                    var oldProperties = _productRepository.GetProductProperties(prod.Id);
                    foreach (var property in oldProperties)
                    {
                        if (prod.Properties.SelectMany(x => x.Values).FirstOrDefault(x => x.Id == property.Id) == null)
                        {
                            _productRepository.DeletePropertyById(property.Id);
                        }
                    }
                }
                _productRepository.EndTransaction();
                _productRepository.StartTransaction();
                //delete product that not include in new list products
                var allProducts = _productRepository.GetAllProducts();
                foreach (var product in allProducts)
                {
                    if (products.FirstOrDefault(x => x.Id == product.Id) == null)
                    {
                        _productRepository.DeleteProductById(product.Id);
                    }
                }
                _productRepository.EndTransaction();
            }
            catch (Exception)
            {
                _productRepository.RollBackTransaction();
                return false;
            }
            return true;
        }

        public bool SaveCurrency(ApiModel.Currency currency)
        {
            return _productRepository.SaveCurrency(currency.ApiToEntities());
        }

        public Currency GetCurrentCurrency()
        {
            var currency = _productRepository.GetCurrentCurrency();
            if (currency != null)
            {
                return currency.EntitiesToModel();
            }
            else
            {
                return new Currency
                {
                    Code = "USD",
                    Symbol = "$"
                };
            }
        }

        public ICollection<Product> GetProductByFilter(FilterRequest request)
        {
            var products = GetAllProducts().ToList();

            foreach (var filter in request.Filters)
            {
                for (int i = 0; i < products.Count; i++)
                {
                    var prop = products[i].Properties.FirstOrDefault(x => x.PropertyId == filter.PropertyId);
                    if (prop != null)
                    {
                        if (filter.Items.Where(w => prop.Value == w.Value).Count() == 0)
                        {
                            products.Remove(products[i]);
                            i--;
                        }
                    }
                }
            }
            return products;
        }
    }
}
