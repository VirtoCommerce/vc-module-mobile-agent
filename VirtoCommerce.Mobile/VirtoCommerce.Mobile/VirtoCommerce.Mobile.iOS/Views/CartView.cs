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
using Xamarin.Themes;

namespace VirtoCommerce.Mobile.iOS.Views
{
    public class CartView : MvxViewController
    {
        public CartViewModel CartViewModel { get { return ViewModel as CartViewModel; } }
        private const int _padding = 10;
        public CartView() : base(null, null)
        {
            Title = "Cart";
            View.BackgroundColor = Consts.ColorMainBg;
            CreateView();
            var bindingSet = this.CreateBindingSet<CartView, CartViewModel>();
            bindingSet.Bind(_createOrderButton).To(x => x.CreateOrderCommand);
            bindingSet.Bind(_createOrderButton).For(x => x.Enabled).To(x => x.CanCreateOrder);
            bindingSet.Bind(_cartItems).For(x => x.Hidden).To(x => x.HideProductList);
            bindingSet.Bind(_infoView).For(x => x.Hidden).To(x => x.HideProductList);
            bindingSet.Bind(_emptyMessageLabel).For(x => x.Hidden).To(x => x.HideEmptyMessage);
            bindingSet.Apply();
        }

        private void UpdateCartView()
        {
            ((CartSource)_cartItems.Source).Cart = CartViewModel.Cart;
            _cartItems.ReloadData();
            //
            ((TotalSource)_totalView.Source).Data = GetTotalData();
            _totalView.ReloadData();
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
                TextFont = UIFont.FromName(Consts.FontNameBold, 17)
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
            totalViewFrame.Width = _infoView.Frame.Width;
            totalViewFrame.Height = _totalView.Source.RowsInSection(_totalView, 0) * _totalView.RowHeight;
            _totalView.Frame = totalViewFrame;
            //payments 
            var paymentsViewFrame = _paymentMethods.Frame;
            paymentsViewFrame.Y = totalViewFrame.Y + totalViewFrame.Height;
            paymentsViewFrame.Width = infoViewFrame.Width;
            paymentsViewFrame.Height = _paymentMethods.Source.RowsInSection(_paymentMethods, 0) * _paymentMethods.RowHeight + 60;
            _paymentMethods.Frame = paymentsViewFrame;
            _paymentMethods.SizeToFit();
            //create order button
            var createOrderButtonFrame = _createOrderButton.Frame;
            createOrderButtonFrame.Width = _infoView.Frame.Width - _padding * 2;
            createOrderButtonFrame.Height = 50;
            createOrderButtonFrame.X = _padding;
            createOrderButtonFrame.Y = paymentsViewFrame.Height + _padding + paymentsViewFrame.Y;
            _createOrderButton.Frame = createOrderButtonFrame;
            //border
            var borderViewFrame = _borderView.Frame;
            borderViewFrame.Height = View.Frame.Height;
            borderViewFrame.X = cartItemsFrame.Width + cartItemsFrame.X;
            borderViewFrame.Y = 0;
            _borderView.Frame = borderViewFrame;
        }

        #region View
        private UITableView _cartItems;
        private UITableView _paymentMethods;
        private UITableView _totalView;
        private UIView _infoView;
        private UIView _borderView;
        private UIButton _createOrderButton;
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
            _infoView = new UIView();
            Add(_infoView);
            //total
            _totalView = new UITableView(new RectangleF(_padding, _padding, 250, 200), UITableViewStyle.Plain);
            _totalView.Source = new TotalSource(GetTotalData());
            _totalView.RowHeight = 30;
            _totalView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            _totalView.ScrollEnabled = true;
            _infoView.Add(_totalView);
            //payment methods
            _paymentMethods = new UITableView(new RectangleF(0, 0, 250, 250), UITableViewStyle.Grouped);
            _paymentMethods.BackgroundColor = Consts.ColorMainBg;
            _paymentMethods.Source = new PaymentSource(_paymentMethods, CartViewModel.PaymentMethods);
            _paymentMethods.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            _paymentMethods.RowHeight = 30;
            _paymentMethods.ScrollEnabled = true;
            _paymentMethods.AllowsMultipleSelection = false;
            _infoView.Add(_paymentMethods);
            //create
            _createOrderButton = Helpers.UICreator.CreateSimpleButton("Create order");
            _infoView.Add(_createOrderButton);
            //border view
            _borderView = new UIView(new RectangleF(0, 0, 1, 1));
            _borderView.BackgroundColor = UIColor.LightGray;
            Add(_borderView);
            //empty message label 
            _emptyMessageLabel = new UILabel()
            {
                Text = "YOUR CART IS CURRENTLY EMPTY.",
                TextColor = Consts.ColorMain,
                Font = UIFont.FromName(Consts.FontNameRegular, 30)
            };
            Add(_emptyMessageLabel);

        }
        #endregion

        #region old cart
        /*public CartViewModel CartViewModel { get { return (CartViewModel)ViewModel; } }
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
        #endregion*/
        #endregion
    }
}
