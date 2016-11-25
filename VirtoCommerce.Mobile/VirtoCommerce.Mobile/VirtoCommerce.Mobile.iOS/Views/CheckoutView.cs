using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.Platform.WeakSubscription;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using UIKit;
using VirtoCommerce.Mobile.iOS.NativConvertors;
using VirtoCommerce.Mobile.iOS.UI;
using VirtoCommerce.Mobile.iOS.UI.Cart;
using VirtoCommerce.Mobile.iOS.UI.Order;
using VirtoCommerce.Mobile.Model;
using VirtoCommerce.Mobile.ViewModels;

namespace VirtoCommerce.Mobile.iOS.Views
{
    public class CheckoutView : MvxViewController
    {
        public CheckoutViewModel CheckoutViewModel { get { return ViewModel as CheckoutViewModel; } }
        private const int _padding = 10;
        private IDisposable _subscribeBackbuttonShowChange;
        private IDisposable _subscribeButtonTitleChange;
        private IDisposable _subscribeCartChange;


        public CheckoutView() : base(null, null)
        {
            Title = "Order";
            View.BackgroundColor = Consts.ColorMainBg;
            CreateView();
            var bindingSet = this.CreateBindingSet<CheckoutView, CheckoutViewModel>();
            bindingSet.Bind(_nextButton).To(x => x.NextCommand);
            _subscribeButtonTitleChange = ((INotifyPropertyChanged)ViewModel).WeakSubscribe<string>("NextButtonTitle", (s, e) =>
            {
                _nextButton.SetTitle(CheckoutViewModel.NextButtonTitle, UIControlState.Normal);
            });
            bindingSet.Bind(_backButton).To(x => x.BackCommand);
            bindingSet.Bind(_backButton).For(x => x.Hidden).To(x => x.ShowBackButton).WithConversion(new InvertBoolConvertor());
            _subscribeBackbuttonShowChange = ((INotifyPropertyChanged)ViewModel).WeakSubscribe<bool>("ShowBackButton", (s, e) =>
            {
                ResizeMainView();
            });
            _subscribeCartChange = ((INotifyPropertyChanged)ViewModel).WeakSubscribe<Cart>("Cart", (s, e) =>
            {
                UpdateTotalData();
            });
            bindingSet.Bind(_customerInfo).For(x => x.Hidden).To(x => x.ShowCustomerInfo).WithConversion(new InvertBoolConvertor());
            bindingSet.Bind(_paymentMethods).For(x => x.Hidden).To(x => x.ShowPaymentInfo).WithConversion(new InvertBoolConvertor());
            bindingSet.Bind(_shippingMethods).For(x => x.Hidden).To(x => x.ShowShippingInfo).WithConversion(new InvertBoolConvertor());
            bindingSet.Apply();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            NavigationController.NavigationBarHidden = false;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _subscribeBackbuttonShowChange?.Dispose();
            _subscribeButtonTitleChange?.Dispose();
            _subscribeCartChange?.Dispose();
        }

        private void UpdateTotalData()
        {
            ((TotalSource)_totalView.Source).Data = GetTotalData();
            _totalView.ReloadData();
        }

        private List<TotalRowData> GetTotalData()
        {
            var result = new List<TotalRowData>();

            result.Add(new TotalRowData
            {
                Header = "Subtotal",
                Value = CheckoutViewModel.Cart?.FormattedSubTotal,
                TextColor = Consts.ColorBlack,
                TextFont = UIFont.FromName(Consts.FontNameRegular, 17)
            });
            result.Add(new TotalRowData
            {
                Header = "Discount",
                Value = CheckoutViewModel.Cart?.FormattedDiscount,
                TextColor = Consts.ColorBlack,
                TextFont = UIFont.FromName(Consts.FontNameRegular, 17)
            });
            result.Add(new TotalRowData
            {
                Header = "Shipment",
                Value = CheckoutViewModel.Cart?.FormattedShipment,
                TextColor = Consts.ColorBlack,
                TextFont = UIFont.FromName(Consts.FontNameRegular, 17)
            });
            result.Add(new TotalRowData
            {
                Header = "Taxes",
                Value = CheckoutViewModel.Cart?.FormattedTaxes,
                TextColor = Consts.ColorBlack,
                TextFont = UIFont.FromName(Consts.FontNameRegular, 17)
            });

            result.Add(new TotalRowData
            {
                Header = "Total",
                Value = CheckoutViewModel.Cart?.FormattedTotal,
                TextColor = Consts.ColorBlack,
                TextFont = UIFont.FromName(Consts.FontNameBold, 17)
            });
            return result;
        }

        #region View
        private UITableView _cartItems;
        private UIView _infoView;
        private UIView _borderView;
        private UITableView _totalView;
        private UIView _mainInfo;
        private UIButton _nextButton;
        private UIButton _backButton;
        private UITableView _customerInfo;
        private UITableView _paymentMethods;
        private UITableView _shippingMethods;

        private void CreateView()
        {

            CreateInfo();
            CreateMainInfo();
            //border view
            _borderView = new UIView(new RectangleF(0, 0, 1, 1));
            _borderView.BackgroundColor = UIColor.LightGray;
            Add(_borderView);
            
        }

        private void CreateInfo()
        {
            //info view
            _infoView = new UIView();
            Add(_infoView);
            //cart items
            _cartItems = new UITableView(new RectangleF(0, 0, 250, 250), UITableViewStyle.Plain);
            _cartItems.Source = new CartSource(_cartItems, CheckoutViewModel.Cart, x => { }, false);
            _cartItems.RowHeight = CartCell.RowHeight;
            _cartItems.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            _cartItems.ScrollEnabled = true;
            _infoView.Add(_cartItems);
            //total
            _totalView = new UITableView(new RectangleF(_padding, _padding, 250, 200), UITableViewStyle.Plain);
            _totalView.Source = new TotalSource(GetTotalData());
            _totalView.RowHeight = 30;
            _totalView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            _totalView.ScrollEnabled = true;
            _infoView.Add(_totalView);
        }

        private List<KeyValuePair<string, Customer>> GetCustomerInfoData()
        {
            var result = new List<KeyValuePair<string, Customer>>();
            result.Add(new KeyValuePair<string, Customer>("Email",CheckoutViewModel.Customer));
            result.Add(new KeyValuePair<string, Customer>("First name", CheckoutViewModel.Customer));
            result.Add(new KeyValuePair<string, Customer>("Last name", CheckoutViewModel.Customer));
            result.Add(new KeyValuePair<string, Customer>("Company name", CheckoutViewModel.Customer));
            result.Add(new KeyValuePair<string, Customer>("Address", CheckoutViewModel.Customer));
            result.Add(new KeyValuePair<string, Customer>("Apt, suite etc.", CheckoutViewModel.Customer));
            result.Add(new KeyValuePair<string, Customer>("City", CheckoutViewModel.Customer));
            result.Add(new KeyValuePair<string, Customer>("Country", CheckoutViewModel.Customer));
            result.Add(new KeyValuePair<string, Customer>("Postal code", CheckoutViewModel.Customer));
            result.Add(new KeyValuePair<string, Customer>("Phone", CheckoutViewModel.Customer));
            return result;
        }

        private void CreateMainInfo() {
            //main info view
            _mainInfo = new UIView();
            Add(_mainInfo);
            //customer info
            _customerInfo = new UITableView(new RectangleF(0, 0, 250, 250), UITableViewStyle.Grouped);
            _customerInfo.BackgroundColor = Consts.ColorMainBg;
            _customerInfo.Source = new CustomerInfoSource(_customerInfo, GetCustomerInfoData());
            _customerInfo.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            _customerInfo.RowHeight = UITableView.AutomaticDimension;
            _customerInfo.ScrollEnabled = true;
            _customerInfo.AllowsMultipleSelection = false;
            _mainInfo.Add(_customerInfo);
            //payment methods
            _paymentMethods = new UITableView(new RectangleF(0, 0, 250, 250), UITableViewStyle.Grouped);
            _paymentMethods.BackgroundColor = Consts.ColorMainBg;
            _paymentMethods.Source = new PaymentSource(_paymentMethods, CheckoutViewModel.PaymentMethods);
            _paymentMethods.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            _paymentMethods.RowHeight = UITableView.AutomaticDimension;
            _paymentMethods.ScrollEnabled = true;
            _paymentMethods.AllowsMultipleSelection = false;
            _mainInfo.Add(_paymentMethods);
            //shipping methods
            _shippingMethods = new UITableView(new RectangleF(0, 0, 250, 250), UITableViewStyle.Grouped);
            _shippingMethods.BackgroundColor = Consts.ColorMainBg;
            _shippingMethods.Source = new ShippingSource(_shippingMethods, CheckoutViewModel.ShippingMethods, CheckoutViewModel.SelectRateAction);
            _shippingMethods.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            _shippingMethods.RowHeight = UITableView.AutomaticDimension;
            _shippingMethods.ScrollEnabled = true;
            _shippingMethods.AllowsMultipleSelection = false;
            _mainInfo.Add(_shippingMethods);
            //next button
            _nextButton = Helpers.UICreator.CreateSimpleButton("Shipping method");
            _mainInfo.Add(_nextButton);
            //back button
            _backButton = Helpers.UICreator.CreateSimpleButton("Back");
            _mainInfo.Add(_backButton);

        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();



            //payments 
            /*var paymentsViewFrame = _paymentMethods.Frame;
            paymentsViewFrame.Y = totalViewFrame.Y + totalViewFrame.Height;
            paymentsViewFrame.Width = infoViewFrame.Width;
            paymentsViewFrame.Height = (int)(infoViewFrame.Height * 0.66);
            _paymentMethods.Frame = paymentsViewFrame;
            _paymentMethods.SizeToFit();*/
            //create order button
            /* var createOrderButtonFrame = _createOrderButton.Frame;
             createOrderButtonFrame.Width = _infoView.Frame.Width - _padding * 2;
             createOrderButtonFrame.Height = 50;
             createOrderButtonFrame.X = _padding;
             createOrderButtonFrame.Y = paymentsViewFrame.Height + _padding + paymentsViewFrame.Y;
             _createOrderButton.Frame = createOrderButtonFrame;*/
            ResizeMainView();
            ResizeInfoView();
        }
        private void ResizeMainView() {
            var mainInfoFrame = _mainInfo.Frame;
            mainInfoFrame.Width = (int)(View.Frame.Width * 0.5);
            mainInfoFrame.Height = (int)(View.Frame.Height);
            _mainInfo.Frame = mainInfoFrame;
            if (CheckoutViewModel.ShowBackButton)
            {

                //back button
                var backButtonFrame = _backButton.Frame;
                backButtonFrame.Width = (mainInfoFrame.Width - _padding * 2) / 2;
                backButtonFrame.Height = Consts.ButtonHeight;
                backButtonFrame.X = _padding;
                backButtonFrame.Y = mainInfoFrame.Height - _padding - Consts.ButtonHeight;
                _backButton.Frame = backButtonFrame;
                //button
                var buttonFrame = _nextButton.Frame;
                buttonFrame.Width = (mainInfoFrame.Width - _padding * 2) / 2;
                buttonFrame.Height = Consts.ButtonHeight;
                buttonFrame.X = backButtonFrame.Width + backButtonFrame.X + _padding;
                buttonFrame.Y = mainInfoFrame.Height - _padding - Consts.ButtonHeight;
                _nextButton.Frame = buttonFrame;
            }
            else
            {
                //button
                var buttonFrame = _nextButton.Frame;
                buttonFrame.Width = mainInfoFrame.Width - _padding * 2;
                buttonFrame.Height = Consts.ButtonHeight;
                buttonFrame.X = _padding;
                buttonFrame.Y = mainInfoFrame.Height - _padding - Consts.ButtonHeight;
                _nextButton.Frame = buttonFrame;
            }
            //customer info
            var customerInfoFrame = _customerInfo.Frame;
            customerInfoFrame.Width = mainInfoFrame.Width - _padding * 2;
            customerInfoFrame.Height = mainInfoFrame.Height - _padding * 3 - Consts.ButtonHeight;
            customerInfoFrame.X = _padding;
            customerInfoFrame.Y = _padding;
            _shippingMethods.Frame = _paymentMethods.Frame = _customerInfo.Frame = customerInfoFrame;
            
        }
        private void ResizeInfoView() {
            //info view
            var infoViewFrame = _infoView.Frame;
            infoViewFrame.Width = (int)(View.Frame.Width * 0.5);
            infoViewFrame.Height = View.Frame.Height;
            infoViewFrame.X = (int)(View.Frame.Width * 0.5);
            infoViewFrame.Y = 0;
            _infoView.Frame = infoViewFrame;
            //total
            var totalViewFrame = _totalView.Frame;
            totalViewFrame.Width = _infoView.Frame.Width - _padding;
            totalViewFrame.Height = _totalView.RowHeight * _totalView.Source.RowsInSection(_totalView, 0);
            totalViewFrame.X = _padding;
            totalViewFrame.Y = _padding;
            _totalView.Frame = totalViewFrame;
            //cart items
            var cartItemsFrame = _cartItems.Frame;
            cartItemsFrame.Width = infoViewFrame.Width - _padding;
            cartItemsFrame.Height = infoViewFrame.Height - totalViewFrame.Height - (_padding * 2);
            cartItemsFrame.X = _padding;
            cartItemsFrame.Y = totalViewFrame.Y + totalViewFrame.Height + _padding;
            _cartItems.Frame = cartItemsFrame;
            //border
            var borderViewFrame = _borderView.Frame;
            borderViewFrame.Height = View.Frame.Height;
            borderViewFrame.X = cartItemsFrame.Width + cartItemsFrame.X;
            borderViewFrame.Y = 0;
            _borderView.Frame = borderViewFrame;
        }
        #endregion
    }
}