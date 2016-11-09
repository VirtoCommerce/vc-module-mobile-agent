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
        #region Services
        private ICartService _cartService;
        #endregion

        #region Fields
        private Cart _cart;
        private MvxCommand _toCheckoutCommand;
        #endregion

        #region Constructor
        public CartViewModel(ICartService cartService)
        {
            _cartService = cartService;
            Cart = _cartService.GetCart();
        }
        #endregion

        #region Properties
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
        public MvxCommand ToCheckoutCommand
        {
            get
            {
                return _toCheckoutCommand ?? (_toCheckoutCommand = new MvxCommand(() => { ShowViewModel<CheckoutViewModel>(); }, () => Cart != null));
            }
        }
        public bool HideEmptyMessage { get { return Cart != null; } }
        public bool HideProductList { get { return Cart == null; } }
        #endregion

        #region Methods
        public void UpdateCart(CartItem cartItem)
        {
            Cart = _cartService.UpdateCartItem(cartItem);
        }
        #endregion
    }
}
