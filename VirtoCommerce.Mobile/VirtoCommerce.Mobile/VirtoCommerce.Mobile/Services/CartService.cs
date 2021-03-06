﻿using System;
using System.Linq;
using VirtoCommerce.Mobile.Model;
using VirtoCommerce.Mobile.Repositories;
using VirtoCommerce.Mobile.Convertors;
using VirtoCommerce.Mobile.Events;

namespace VirtoCommerce.Mobile.Services
{
    public class CartService : ICartService
    {
        private readonly IProductStorageService _productService;
        private readonly IGlobalEventor _eventor;
        private readonly ICartRepository _cartRepository;
        private readonly ITaxService _taxService;
        private readonly IShippingMethodsService _shipmentService;
        public CartService(IProductStorageService productService, IGlobalEventor eventor, ICartRepository cartRepository, ITaxService taxService, IShippingMethodsService shipmentService)
        {
            _eventor = eventor;
            _productService = productService;
            _cartRepository = cartRepository;
            _taxService = taxService;
            _shipmentService = shipmentService;
        }

        public Cart GetCart()
        {
            var cartItems = _cartRepository.GetAllCartItems();
            if (cartItems.Count == 0)
                return null;
            var cart = new Cart
            {
                Currency = _productService.GetCurrentCurrency()
            };
            foreach (var item in cartItems)
            {
                var cartItem = item.CartItemEntityToCartItem();
                cartItem.Product = _productService.GetProduct(cartItem.Id);
                cartItem.SubTotal = (cartItem.Product.Price?.Sale ?? 0) * cartItem.Quantity;
                cartItem.Discount = (cartItem.Product.Price?.List - cartItem.Product.Price?.Sale ?? 0) * cartItem.Quantity;
                cartItem.Currency = cart.Currency;
                cart.CartItems.Add(cartItem);
            }
            
            cart.SubTotal = cart.CartItems.Sum(x => x.SubTotal);
            cart.Taxes = cart.SubTotal * Convert.ToDecimal(_taxService.GetCurrentTax().Percent / 100);
            cart.Discount = cart.CartItems.Sum(x => x.Discount);
            cart.Total = cart.SubTotal + cart.Taxes + cart.Shipment;
            return cart;
        }

        public Cart GetCartWithShipment(string shipmentId)
        {
            var cart = GetCart();
            var shipmentRate = _shipmentService.GetAllShippingMethods().SelectMany(x => x.MethodRates).FirstOrDefault(x => x.Id == shipmentId)?.Rate ?? 0;
            cart.Shipment = shipmentRate;
            cart.Total = cart.SubTotal + cart.Taxes + cart.Shipment;
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
            _eventor.Publish(new CartChangeEvent());
            return GetCart();
        }

        public Cart AddToCart(string id)
        {
            _cartRepository.AddOrUpdateCartItem(new Entities.CartItemEntity { Count = 1, Id = id });
            _eventor.Publish(new CartChangeEvent());
            return GetCart();
        }

        public Cart RemoveFromCart(string id)
        {
            _cartRepository.RemoveCartItem(id);
            _eventor.Publish(new CartChangeEvent());
            return GetCart();
        }

        public int CountInCart()
        {
            return _cartRepository.CountInCart();
        }

        public bool ClearCart()
        {
            return _cartRepository.ClearCart();
        }

    }
}
