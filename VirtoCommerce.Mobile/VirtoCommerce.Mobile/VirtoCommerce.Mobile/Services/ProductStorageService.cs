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
            var currency = new Currency
            {
                Code = "USD",
                Symbol = "$"
            };
            var products = new List<Product> {
                new Product {
                    Id = "1",
                    TitleImage = "1.png",
                    Name= "Lorem ipsum dolor sit amet 1",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud",
                    Price = new Price {
                       Currency = currency,
                        List  = 1,
                        Sale = 1
                    }
                },
                new Product {
                    Id = "2",
                    Name= "Lorem ipsum dolor sit amet, consectetur adipisicing elit 2",
                    TitleImage = "2.png",
                    Price = new Price {
Currency = currency,
                        List = Convert.ToDecimal(25.50),
                        Sale = 20
                    }
                },
                new Product {
                    Id = "3",
                    TitleImage = "3.png",
                    Name= "Incididunt ut labore et dolore 3",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit",
                    Price = new Price {
   Currency = currency,
                        List = Convert.ToDecimal(15.30),
                        Sale = 40
                    }
                },
                new Product {
                    Id = "4",
                    TitleImage = "4.png",
                    Name= "It, sed do eiusmod tempor incididunt ut labore et dolore magna  4",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt",
                    Price = new Price {
Currency = currency,
                        List = Convert.ToDecimal(1025.15),
                        Sale = 1000
                    }
                },
                new Product {
                    Id = "5",
                    Name= "Prod 5",
                    TitleImage = "5.png",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud",
                    Price = new Price {
Currency = currency,
                        List = Convert.ToDecimal(10000),
                        Sale = 5000
                    }
                },
                new Product {
                    Id = "6",
                    TitleImage = "6.png",
                    Name= "Lorem ipsum dolor sit amet 6",
                    Manufacture = "Polaroid",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud",
                    Price = new Price {
Currency = currency,
                        List = Convert.ToDecimal(25.50),
                        Sale = 20
                    },
                    Properties = new [] {
                        new ProductProperty {
                            Name = "Size",
                            Value = "Medium"
                        },
                        new ProductProperty {
                            Name = "Bride Size",
                            Value = "10 mm"
                        },
                        new ProductProperty {
                            Name = "Temple Size",
                            Value = "142 mm"
                        },
                        new ProductProperty {
                            Name = "Eye Size",
                            Value = "10mm"
                        },
                        new ProductProperty {
                            Name = "Gender",
                            Value = "Female"
                        },
                        new ProductProperty {
                            Name = "Model No.",
                            Value = "VC 0315"
                        },
                        new ProductProperty {
                            Name = "Frame colour",
                            Value = "Red"
                        },
                        new ProductProperty {
                            Name = "Weight",
                            Value = "15g"
                        },
                        new ProductProperty {
                            Name = "Material",
                            Value = "Flexible Light-Weight"
                        },
                        new ProductProperty {
                            Name = "Product Warranty",
                            Value = "1 Year"
                        },
                    }
                },new Product {
                    Id = "7",
                    TitleImage = "7.png",
                    Name= "Prod 7",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Price = new Price {
Currency = currency,
                        List = Convert.ToDecimal(325.01),
                        Sale = Convert.ToDecimal(200.2)
                    }
                },
                new Product {
                    Id = "8",
                    TitleImage = "8.png",
                    Name= "Prod 8",
                    Description = "Lorem ipsum dolor sit amet",
                    Price = new Price {
Currency = currency,
                        Sale = 10
                    }

                }
            };
            /*for (var i = 0; i < 1000; i++)
            {
                products.Add(products[0]);
            }*/
            return products;
        }

        public int GetProductsCount()
        {
            return 1;
        }

        public bool SaveProducts(ICollection<ApiClient.Models.Product> products)
        {
            try
            {
                _productRepository.StartTransaction();
                foreach (var prod in products)
                {
                    //save main product
                    if (!_productRepository.SaveProduct(prod.ToProductEntity()))
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
                            LanguageCode = review.LanguageCode
                        };
                    }
                }
                _productRepository.EndTransaction();
            }
            catch {
                _productRepository.RollBackTransaction();
                return false;
            }
            return true;
        }
    }
}
