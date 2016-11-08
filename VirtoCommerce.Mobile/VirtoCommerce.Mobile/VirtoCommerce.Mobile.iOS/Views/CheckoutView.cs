using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using UIKit;
using VirtoCommerce.Mobile.iOS.NativConvertors;
using VirtoCommerce.Mobile.iOS.UI;
using VirtoCommerce.Mobile.iOS.UI.Cart;
using VirtoCommerce.Mobile.iOS.UI.Order;
using VirtoCommerce.Mobile.ViewModels;
using Xamarin.Themes;

namespace VirtoCommerce.Mobile.iOS.Views
{
    public class CheckoutView: MvxViewController
    {
        public CheckoutViewModel CheckoutViewModel { get { return ViewModel as CheckoutViewModel; } }
        private const int _padding = 10;
        public CheckoutView() : base(null, null)
        {
            Title = "Order";
            View.BackgroundColor = UIColor.FromPatternImage(GridlockTheme.SharedTheme.ViewBackground);
            CreateView();
            var bindingSet = this.CreateBindingSet<CheckoutView, CheckoutViewModel>();
            bindingSet.Bind(_totalLabel).For(x => x.Text).To(x => x.Cart.FormattedSubTotal).WithConversion(new TotalConvertor());
            bindingSet.Bind(_createOrderButton).To(x => x.CreateOrderCommand);
            bindingSet.Apply();
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
            var totalLabelFrame = _totalLabel.Frame;
            totalLabelFrame.Width = _infoView.Frame.Width;
            totalLabelFrame.Height = 30;
            _totalLabel.Frame = totalLabelFrame;
            //payments 
            var paymentsViewFrame = _paymentMethods.Frame;
            paymentsViewFrame.Y = totalLabelFrame.Y + totalLabelFrame.Height;
            paymentsViewFrame.Width = infoViewFrame.Width;
            paymentsViewFrame.Height = (int)(infoViewFrame.Height * 0.66);
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
        private UIView _infoView;
        private UIView _borderView;
        private UILabel _totalLabel;
        private UIButton _createOrderButton;

        private void CreateView()
        {
            //cart items
            _cartItems = new UITableView(new RectangleF(0, 0, 250, 250), UITableViewStyle.Plain);
            _cartItems.Source = new CartSource(_cartItems, CheckoutViewModel.Cart, x => { }, false);
            _cartItems.RowHeight = CartCell.RowHeight;
            _cartItems.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            _cartItems.ScrollEnabled = true;
            Add(_cartItems);
            //info view
            _infoView = new UIView();
            Add(_infoView);
            //total
            _totalLabel = new UILabel
            {
                Font = UIFont.FromName(Consts.FontNameRegular, 20),
                TextColor = Consts.ColorRed,
                TextAlignment = UITextAlignment.Center
            };
            _infoView.Add(_totalLabel);
            //payment methods
            _paymentMethods = new UITableView(new RectangleF(0, 0, 250, 250), UITableViewStyle.Grouped);
            _paymentMethods.BackgroundColor = UIColor.FromPatternImage(GridlockTheme.SharedTheme.ViewBackground);
            _paymentMethods.Source = new PaymentSource(_paymentMethods, CheckoutViewModel.PaymentMethods);
            _paymentMethods.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            _paymentMethods.RowHeight = UITableView.AutomaticDimension;
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
            
        }
        #endregion
    }
}