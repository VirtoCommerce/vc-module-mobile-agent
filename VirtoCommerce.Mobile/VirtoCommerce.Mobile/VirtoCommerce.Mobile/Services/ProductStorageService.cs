using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.Services
{
    public class ProductStorageService : IProductStorageService
    {
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
            return new[] {
                new Product {
                    Id = "1",
                    Name= "Lorem ipsum dolor sit amet 1",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud",
                    Price = new Price {
                        CurrencyCode = "USD",
                        CurrencySymbol = "$",
                        List  = 1,
                        Sale = 1
                    }
                },
                new Product {
                    Id = "2",
                    Name= "Lorem ipsum dolor sit amet, consectetur adipisicing elit 2",
                    Price = new Price {
                        CurrencyCode = "USD",
                        CurrencySymbol = "$",
                        List = Convert.ToDecimal(25.50),
                        Sale = 20
                    }
                },
                new Product {
                    Id = "3",
                    Name= "Incididunt ut labore et dolore 3",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit",
                    Price = new Price {
                        CurrencyCode = "USD",
                        CurrencySymbol = "$",
                        List = Convert.ToDecimal(15.30),
                        Sale = 40
                    }
                },
                new Product {
                    Id = "4",
                    Name= "It, sed do eiusmod tempor incididunt ut labore et dolore magna  4",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt",
                    Price = new Price {
                        CurrencyCode = "USD",
                        CurrencySymbol = "$",
                        List = Convert.ToDecimal(1025.15),
                        Sale = 1000
                    }
                },
                new Product {
                    Id = "5",
                    Name= "Prod 5",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud",
                    Price = new Price {
                        CurrencyCode = "USD",
                        CurrencySymbol = "$",
                        List = Convert.ToDecimal(10000),
                        Sale = 5000
                    }
                },
                new Product {
                    Id = "6",
                    Name= "Lorem ipsum dolor sit amet 6",
                    Manufacture = "Polaroid",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud",
                    Price = new Price {
                        CurrencyCode = "USD",
                        CurrencySymbol = "$",
                        List = Convert.ToDecimal(25.50),
                        Sale = 20
                    },
                    Properties = new [] {
                        new ProductProperty {
                            Name = "Prop 1",
                            Value = "Value 1"
                        }
                    }
                },new Product {
                    Id = "7",
                    Name= "Prod 7",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Price = new Price {
                        CurrencyCode = "USD",
                        CurrencySymbol = "$",
                        List = Convert.ToDecimal(325.01),
                        Sale = Convert.ToDecimal(200.2)
                    }
                },
                new Product {
                    Id = "8",
                    Name= "Prod 8",
                    Description = "Lorem ipsum dolor sit amet",
                    Price = new Price {
                        CurrencyCode = "USD",
                        CurrencySymbol = "$",
                        Sale = 10
                    }
                    
                }
            };
        }

        public bool SaveProducts(ICollection<Product> products)
        {
            return true;
        }
    }
}
