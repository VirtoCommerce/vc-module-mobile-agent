using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Model;
using VirtoCommerce.Mobile.Services;

namespace VirtoCommerce.Mobile.ViewModels
{
    public class CartViewModel : MvxViewModel
    {
        private ICartService _cartService;
        private Cart _cart;
        public CartViewModel(ICartService cartService)
        {
            _cartService = cartService;
            Cart = _cartService.GetCart();
        }
        public Cart Cart
        {
            set
            {
                _cart = value;
                RaiseAllPropertiesChanged();
            }
            get { return _cart; }
        }

        public string FormattedSubTotal
        {
            get { return Cart?.FormattedSubTotal; }
        }

        public void UpdateCart(CartItem cartItem)
        {
            Cart = _cartService.UpdateCartItem(cartItem);
        }
    }
}
