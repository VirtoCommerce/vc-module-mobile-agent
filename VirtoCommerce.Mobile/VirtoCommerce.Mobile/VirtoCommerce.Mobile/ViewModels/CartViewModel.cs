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
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly IGlobalEventor _globalEventor;
        #endregion

        #region Fields
        private Cart _cart;
        private MvxCommand _checkoutCommand;
        #endregion

        #region Constructor
        public CartViewModel(ICartService cartService, IOrderService orderService, IGlobalEventor globalEventor)
        {
            _cartService = cartService;
            _orderService = orderService;
            _globalEventor = globalEventor;
            _globalEventor.Subscribe<Events.CartChangeEvent>(arg =>
            {
                Cart = _cartService.GetCart();
            });
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

        public bool HideEmptyMessage { get { return Cart != null; } }
        public bool HideProductList { get { return Cart == null; } }


        public MvxCommand ToCheckoutCommand
        {
            get
            {
                return _checkoutCommand ?? (_checkoutCommand = new MvxCommand(() =>
                {
                    ShowViewModel<CheckoutViewModel>();
                }));
            }
        }
        #endregion

        #region Methods
        public void UpdateCart(CartItem cartItem)
        {
            Cart = _cartService.UpdateCartItem(cartItem);
        }
        #endregion

        

        
    }
}
