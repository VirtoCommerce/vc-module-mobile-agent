using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Model;
using VirtoCommerce.Mobile.Repositories;
using VirtoCommerce.Mobile.Convertors;
using VirtoCommerce.Mobile.Entities;
using Xamarin.Forms;
using System.IO;

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
            throw new NotImplementedException();
        }

        public Product GetProduct(string id)
        {
            return GetProducts(0, 100).First(x => x.Id == id);
        }

        public ICollection<Product> GetProducts(int start, int count)
        {
            var result = _productRepository.GetAllProducts().Skip(start).Take(count).Select(x=>x.ProductEntityToProduct()).ToArray();
            foreach (var prod in result)
            {
                prod.Reviews = _productRepository.GetReviewsByProduct(prod.Id).Select(x => x.ReviewEntityToReview()).ToArray();
                prod.Images = _productRepository.GetImagesByProduct(prod.Id).Select(x => x.PhysicalPath).ToArray();
                prod.TitleImage = prod.Images.FirstOrDefault(x => Path.GetFileName(x) == prod.TitleImage);
                prod.Price = _productRepository.GetAllPricesByProduct(prod.Id).FirstOrDefault()?.PriceEntityToPrice();
                prod.Properties = _productRepository.GetProductProperties(prod.Id).Select(x => x.PropertyEntityToProperty()).ToArray();
            }
            return result.ToArray();
        }

        public int GetProductsCount()
        {
            return _productRepository.GetProductCount();
        }

        public bool SaveProducts(ICollection<ApiClient.Models.Product> products)
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
                    //save price
                    foreach (var price in prod.Prices)
                    {
                        _productRepository.SavePrice(price.PriceApiToPriceEntity());
                    }
                    //save properties
                    foreach (var prop in prod.Properties)
                    {
                        foreach (var propVl in prop.Values)
                        {
                            _productRepository.SaveProductProperty(propVl.ApiPropertyValueToPropertyEntity(prop, prod.Id));
                        }
                    }
                }
                _productRepository.EndTransaction();
            }
            catch (Exception ex){
                _productRepository.RollBackTransaction();
                return false;
            }
            return true;
        }
    }
}
