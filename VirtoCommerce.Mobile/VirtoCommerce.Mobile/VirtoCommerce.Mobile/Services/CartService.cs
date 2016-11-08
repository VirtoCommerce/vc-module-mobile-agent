using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.Services
{
    public class CartService : ICartService
    {
        private readonly IProductStorageService _productService;
        public CartService(IProductStorageService productService)
        {
            _productService = productService;
        }

        public Cart GetCart()
        {
            var prods = _productService.GetProducts(0, int.MaxValue);
            var cart = new Cart()
            {
                SubTotal = 25,
                Currency = new Currency
                {
                    CurrencySymbol = "$"
                },
                CartItems = new List<CartItem> {
                    new CartItem {
                        Product = prods.ElementAt(6),
                        Quantity = 1,
                        SubTotal = 10,
                        Currency = new Currency
                {
                    CurrencySymbol = "$"
                }
                    },new CartItem {
                        Product = prods.ElementAt(3),
                        Currency = new Currency
                {
                    CurrencySymbol = "$"
                },
                        Quantity = 1
                    },new CartItem {
                        Product = prods.ElementAt(5),
                        Currency = new Currency
                {
                    CurrencySymbol = "$"
                },
                        Quantity = 1
                    },
                    new CartItem {
                        Product = prods.ElementAt(2),
                        Currency = new Currency
                {
                    CurrencySymbol = "$"
                },
                        Quantity = 1
                    },
                    new CartItem {
                        Product = prods.ElementAt(2),
                        Currency = new Currency
                {
                    CurrencySymbol = "$"
                },
                        Quantity = 1
                    },new CartItem {
                        Product = prods.ElementAt(2),
                        Currency = new Currency
                {
                    CurrencySymbol = "$"
                },
                        Quantity = 1
                    },new CartItem {
                        Product = prods.ElementAt(2),
                        Currency = new Currency
                {
                    CurrencySymbol = "$"
                },
                        Quantity = 1
                    },new CartItem {
                        Product = prods.ElementAt(2),
                        Quantity = 1,
                        Currency = new Currency
                {
                    CurrencySymbol = "$"
                }
                    },new CartItem {
                        Product = prods.ElementAt(2),
                        Quantity = 1,Currency = new Currency
                {
                    CurrencySymbol = "$"
                }
                    },new CartItem {
                        Product = prods.ElementAt(2),
                        Quantity = 1,
                        Currency = new Currency
                {
                    CurrencySymbol = "$"
                }
                    },new CartItem {
                        Product = prods.ElementAt(2),
                        Quantity = 1,
                        Currency = new Currency
                {
                    CurrencySymbol = "$"
                }
                    },new CartItem {
                        Product = prods.ElementAt(2),
                        Quantity = 1,
                        Currency = new Currency
                {
                    CurrencySymbol = "$"
                }
                    },
                }
            };
            for (var i = 0; i < 250; i++)
            {
                cart.CartItems.Add(cart.CartItems[0]);
            }
            return cart;
        }


        public Cart UpdateCartItem(CartItem cartItem)
        {
            var cart = GetCart();
            var item = cart.CartItems.FirstOrDefault(x => x.Product.Id == cartItem.Product.Id);
            if (item != null)
            {
                if (cartItem.Quantity == 0)
                {
                    cart.CartItems.Remove(item);
                }
                else
                {
                    item.Quantity = cartItem.Quantity;
                    item.SubTotal = (cartItem.Product.Price?.Sale * item.Quantity) ?? 0;
                }
            }
            cart.SubTotal = new Random().Next();
            return cart;
        }

        Cart ICartService.AddToCart(string id)
        {
            throw new NotImplementedException();
        }

        Cart ICartService.RemoveFromCart(string id)
        {
            throw new NotImplementedException();
        }
    }
}
