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
using VirtoCommerce.Mobile.iOS.UI.Order;
using VirtoCommerce.Mobile.Model;
using VirtoCommerce.Mobile.ViewModels;
using System.Linq;
using Xamarin.Themes;

namespace VirtoCommerce.Mobile.iOS.Views
{
    public class CartView : MvxViewController
    {
        public CartViewModel CartViewModel { get { return ViewModel as CartViewModel; } }
        private const int _padding = 10;
        private IDisposable _subscribeCartChange;
        public CartView() : base(null, null)
        {
            Title = "Cart";
            View.BackgroundColor = Consts.ColorMainBg;
            CreateView();
            var bindingSet = this.CreateBindingSet<CartView, CartViewModel>();
            bindingSet.Bind(_chekoutButton).To(x => x.ToCheckoutCommand);
            //bindingSet.Bind(_chekoutButton).For(x => x.Enabled).To(x => x.CanCreateOrder);
            bindingSet.Bind(_cartItems).For(x => x.Hidden).To(x => x.HideProductList);
            bindingSet.Bind(_infoView).For(x => x.Hidden).To(x => x.HideProductList);
            bindingSet.Bind(_emptyMessageLabel).For(x => x.Hidden).To(x => x.HideEmptyMessage);
            _subscribeCartChange = ((INotifyPropertyChanged)ViewModel).WeakSubscribe<Cart>("Cart", (s, e) =>
            {
                UpdateCartView();
            });
            bindingSet.Apply();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _subscribeCartChange?.Dispose();
        }

        private void UpdateCartView()
        {
            ((CartSource)_cartItems.Source).Cart = CartViewModel.Cart;
            _cartItems.ReloadData();
            //
            ((TotalSource)_totalView.Source).Data = GetTotalData();
            _totalView.ReloadData();
            //

        }

        private void UpdateCart(CartItem cartItem)
        {
            CartViewModel.UpdateCart(cartItem);
            UpdateCartView();
        }

        private List<TotalRowData> GetTotalData()
        {
            var result = new List<TotalRowData>();

            result.Add(new TotalRowData {
                Header = "Subtotal",
                Value = CartViewModel.Cart?.FormattedSubTotal,
                TextColor = Consts.ColorBlack,
                TextFont = UIFont.FromName(Consts.FontNameRegular, 17)
            });
            result.Add(new TotalRowData
            {
                Header = "Discount",
                Value = CartViewModel.Cart?.FormattedDiscount,
                TextColor = Consts.ColorBlack,
                TextFont = UIFont.FromName(Consts.FontNameRegular, 17)
            });
            result.Add(new TotalRowData
            {
                Header = "Taxes",
                Value = CartViewModel.Cart?.FormattedTaxes,
                TextColor = Consts.ColorBlack,
                TextFont = UIFont.FromName(Consts.FontNameRegular, 17)
            });

            result.Add(new TotalRowData
            {
                Header = "Total",
                Value = CartViewModel.Cart?.FormattedTotal,
                TextColor = Consts.ColorBlack,
                TextFont = UIFont.FromName(Consts.FontNameBold, 20)
            });
            return result;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            NavigationController.NavigationBarHidden = false;
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            //cart items
            var cartItemsFrame = _cartItems.Frame;
            cartItemsFrame.Width = (int)(View.Frame.Width * 0.66);
            cartItemsFrame.Height = View.Frame.Height;
            _cartItems.Frame = cartItemsFrame;
            //info view
            var infoViewFrame = _infoView.Frame;
            infoViewFrame.Width = View.Frame.Width - cartItemsFrame.Width;
            infoViewFrame.Height = View.Frame.Height;

            infoViewFrame.X = cartItemsFrame.Width;
            infoViewFrame.Y = 0;
            _infoView.Frame = infoViewFrame;
            //total
            var totalViewFrame = _totalView.Frame;
            totalViewFrame.Width = _infoView.Frame.Width - _padding * 2;
            totalViewFrame.Height = _totalView.Source.RowsInSection(_totalView, 0) * _totalView.RowHeight + 50;
            _totalView.Frame = totalViewFrame;
            _totalView.ReloadData();
            //create order button
            var createOrderButtonFrame = _chekoutButton.Frame;
            createOrderButtonFrame.Width = _infoView.Frame.Width - _padding * 2;
            createOrderButtonFrame.Height = 50;
            createOrderButtonFrame.X = _padding;
            createOrderButtonFrame.Y = totalViewFrame.Height + 50 + totalViewFrame.Y;
            _chekoutButton.Frame = createOrderButtonFrame;
            //empty message
            _emptyMessageLabel.SizeToFit();
            _emptyMessageLabel.Center = new CoreGraphics.CGPoint(View.Frame.Width / 2, View.Frame.Height / 2);
        }

        #region View
        private UITableView _cartItems;
        private UITableView _totalView;
        private UIView _infoView;
        private UIButton _chekoutButton;
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
            //info view
            _infoView = new UIView() {
                BackgroundColor = Consts.ColorSecondBg
            };
            Add(_infoView);
            //total
            _totalView = new UITableView(new RectangleF(_padding, _padding, 100, 200), UITableViewStyle.Grouped);
            _totalView.BackgroundColor = Consts.ColorTransparent;
            _totalView.Source = new TotalSource(GetTotalData());
            _totalView.RowHeight = 30;
            _totalView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            _totalView.ScrollEnabled = false;
            _infoView.Add(_totalView);
            //create
            _chekoutButton = Helpers.UICreator.CreateSimpleButton("Checkout");
            _chekoutButton.BackgroundColor = UIColor.White;
            _infoView.Add(_chekoutButton);
            //empty message label 
            _emptyMessageLabel = new UILabel()
            {
                Text = "YOUR CART IS CURRENTLY EMPTY.",
                TextColor = Consts.ColorMain,
                Font = UIFont.FromName(Consts.FontNameRegular, 30)
            };
            Add(_emptyMessageLabel);
            //
        }
        #endregion
    }
}
