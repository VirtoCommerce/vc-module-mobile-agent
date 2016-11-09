using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.Platform.WeakSubscription;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using UIKit;
using VirtoCommerce.Mobile.iOS.NativConvertors;
using VirtoCommerce.Mobile.iOS.UI;
using VirtoCommerce.Mobile.iOS.UI.Cart;
using VirtoCommerce.Mobile.Model;
using VirtoCommerce.Mobile.ViewModels;
using Xamarin.Themes;

namespace VirtoCommerce.Mobile.iOS.Views
{
    public class CartView : MvxViewController
    {
        public CartViewModel CartViewModel { get { return (CartViewModel)ViewModel; } }
        private const int _padding = 10;
        private IDisposable _subscribeCartChange;
        public CartView() : base(null, null)
        {
            Title = "Cart";
            View.BackgroundColor = Consts.ColorMainBg;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            CreateView();
            var bindingSet = this.CreateBindingSet<CartView, CartViewModel>();
            bindingSet.Bind(_subTotal).For(x => x.Text).To(x => x.FormattedSubTotal).WithConversion(new SubtotalConvertor());
            bindingSet.Bind(_subTotal).For(x => x.Hidden).To(x => x.HideProductList).WithConversion(new SubtotalConvertor());
            bindingSet.Bind(_toCheckOutButton).To(x => x.ToCheckoutCommand);
            bindingSet.Bind(_cartItems).For(x => x.Hidden).To(x => x.HideProductList);
            bindingSet.Bind(_emptyMessageLabel).For(x => x.Hidden).To(x => x.HideEmptyMessage);
            bindingSet.Apply();
            _subscribeCartChange = ((INotifyPropertyChanged)ViewModel).WeakSubscribe<Cart>("Cart", (s, e) =>
            {
                UpdateCartView();
            });
        }

        private void UpdateCartView()
        {
            ((CartSource)_cartItems.Source).Cart = CartViewModel.Cart;
            _cartItems.ReloadData();
        }

        private void UpdateCart(CartItem cartItem)
        {
            CartViewModel.UpdateCart(cartItem);
            UpdateCartView();
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            //button
            var checkoutBtnFrame = _toCheckOutButton.Frame;
            checkoutBtnFrame.Width = View.Frame.Width - _padding * 2;
            checkoutBtnFrame.Height = 50;
            var tabSupperView = ((UINavigationController)ParentViewController).ParentViewController as UITabBarController;
            if (tabSupperView != null)
            {
                checkoutBtnFrame.Y = View.Frame.Height - tabSupperView.TabBar.Frame.Height - checkoutBtnFrame.Height - _padding;
            }
            else
            {
                checkoutBtnFrame.Y = View.Frame.Height - checkoutBtnFrame.Height - _padding;
            }
            checkoutBtnFrame.X = _padding;
            _toCheckOutButton.Frame = checkoutBtnFrame;
            //subtotal
            _subTotal.SizeToFit();
            var subtotalFrame = _subTotal.Frame;
            subtotalFrame.Width = View.Frame.Width;
            subtotalFrame.Y = checkoutBtnFrame.Y - subtotalFrame.Height;
            _subTotal.Frame = subtotalFrame;
            //items
            var cartItemsFrame = _cartItems.Frame;
            cartItemsFrame.Width = View.Frame.Width - _padding * 2;
            cartItemsFrame.Height = View.Frame.Height - (View.Frame.Height - checkoutBtnFrame.Y) - _subTotal.Frame.Height - _padding;
            cartItemsFrame.X = _padding;
            cartItemsFrame.Y = _padding;
            _cartItems.Frame = cartItemsFrame;
            //empty message
            _emptyMessageLabel.SizeToFit();
            _emptyMessageLabel.Center = new CoreGraphics.CGPoint(View.Frame.Width / 2, View.Frame.Height / 2);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _subscribeCartChange?.Dispose();
        }

        #region View
        private UITableView _cartItems;
        private UIButton _toCheckOutButton;
        private UILabel _subTotal;
        private UILabel _emptyMessageLabel;

        private void CreateView()
        {
            //cart items
            _cartItems = new UITableView(new RectangleF(0, 0, 250, 250), UITableViewStyle.Plain);
            _cartItems.Source = new CartSource(_cartItems, CartViewModel.Cart, UpdateCart);
            _cartItems.RowHeight = CartCell.RowHeight;
            _cartItems.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            _cartItems.ScrollEnabled = true;
            Add(_cartItems);
            //sub total
            _subTotal = new UILabel()
            {
                Font = UIFont.FromName(Consts.FontNameRegular, 30),
                TextColor = Consts.ColorRed,
                TextAlignment = UITextAlignment.Center
            };
            Add(_subTotal);
            //to checkout
            _toCheckOutButton = Helpers.UICreator.CreateSimpleButton("Checkout");
            Add(_toCheckOutButton);
            //empty message
            _emptyMessageLabel = new UILabel()
            {
                Text = "Cart is empty",
                TextColor = Consts.ColorMain,
                Font = UIFont.FromName(Consts.FontNameRegular, 30)
            };
            Add(_emptyMessageLabel);
        }
        #endregion
    }
}
