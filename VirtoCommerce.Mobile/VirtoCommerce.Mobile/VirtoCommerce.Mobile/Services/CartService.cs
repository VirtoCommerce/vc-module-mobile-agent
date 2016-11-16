using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Model;
using VirtoCommerce.Mobile.Repositories;
using VirtoCommerce.Mobile.Convertors;

namespace VirtoCommerce.Mobile.Services
{
    public class CartService : ICartService
    {
        private readonly IProductStorageService _productService;
        private readonly IGlobalEventor _eventor;
        private readonly ICartRepository _cartRepository;
        public CartService(IProductStorageService productService, IGlobalEventor eventor, ICartRepository cartRepository)
        {
            _eventor = eventor;
            _productService = productService;
            _cartRepository = cartRepository;
        }

        public Cart GetCart()
        {
            
            var cartItems = _cartRepository.GetAllCartItems();
            if (cartItems.Count == 0)
                return null;
            var cart = new Cart();
            foreach (var item in cartItems)
            {
                var cartItem = item.CartItemEntityToCartItem();
                cartItem.Product = _productService.GetProduct(cartItem.Id);
                cartItem.SubTotal = (cartItem.Product.Price?.Sale ?? 0) * cartItem.Quantity;
                cart.CartItems.Add(cartItem);
            }
            cart.SubTotal = cart.CartItems.Sum(x => x.SubTotal);
            cart.Total = cart.SubTotal;
            //Todo create setting currency shop
            cart.Currency = new Currency
            {
                Code = "USD",
                Symbol ="$"
            };
            return cart;
        }

        public Cart UpdateCartItem(CartItem cartItem)
        {
            if (cartItem.Quantity != 0)
            {
                _cartRepository.AddOrUpdateCartItem(cartItem.CartItemToCartItemEntity());
            }
            else
            {
                _cartRepository.RemoveCartItem(cartItem.Id);
            }
            _eventor.Publish(new Events.CartChangeEvent());
            return GetCart();
        }

        public Cart AddToCart(string id)
        {
            _cartRepository.AddOrUpdateCartItem(new Entities.CartItemEntity { Count = 1, Id = id });
            _eventor.Publish(new Events.CartChangeEvent());
            return GetCart();
        }

        public Cart RemoveFromCart(string id)
        {
            _cartRepository.RemoveCartItem(id);
            _eventor.Publish(new Events.CartChangeEvent());
            return GetCart();
        }

        public int CountInCart()
        {
            return _cartRepository.CountInCart();
        }
    }
}
