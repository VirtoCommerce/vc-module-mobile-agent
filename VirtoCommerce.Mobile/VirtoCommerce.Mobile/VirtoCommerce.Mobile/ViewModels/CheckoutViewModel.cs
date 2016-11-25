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
    public class CheckoutViewModel : MvxViewModel
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private Action<ShippingMethodRate> _selectRate;
        private MvxCommand _nextCommad;
        private MvxCommand _backCommnad;
        private bool _canCreateOrder;
        private bool _showCustomerInfo = true;
        private bool _showShippingInfo;
        private bool _showPaymentInfo;
        private bool _showBackButton;
        private string _nextButtonTitle = "Shipping methods";
        private string _shippingMethodId;


        public Customer Customer { set; get; }

        public bool CanCreateOrder
        {
            set { _canCreateOrder = value; RaisePropertyChanged(); }
            get { return _canCreateOrder; }
        }

        public string NextButtonTitle
        {
            set { _nextButtonTitle = value; RaisePropertyChanged(); }
            get { return _nextButtonTitle; }
        }


        public bool ShowBackButton
        {
            set { _showBackButton = value; RaisePropertyChanged(); }
            get { return _showBackButton; }
        }

        public bool ShowCustomerInfo {
            set {
                _showCustomerInfo = value;
                if (value)
                {
                    NextButtonTitle = "Shipping methods";
                    ShowPaymentInfo = false;
                    ShowShippingInfo = false;
                }
                RaisePropertyChanged();
            }
            get {
                return _showCustomerInfo;
            }
        }
        public bool ShowShippingInfo
        {
            get
            {
                return _showShippingInfo;
            }
            set
            {

                _showShippingInfo = value;
                if (value)
                {
                    NextButtonTitle = "Payment methods";
                    ShowPaymentInfo = false;
                    ShowCustomerInfo = false;
                }
                RaisePropertyChanged();
            }
        }

        public bool ShowPaymentInfo
        {
            set
            {
                _showPaymentInfo = value;
                if (value)
                {
                    NextButtonTitle = "Create order";
                    ShowCustomerInfo = false;
                    ShowShippingInfo = false;
                }
                RaisePropertyChanged();
            }
            get { return _showPaymentInfo; }
        }

        public MvxCommand NextCommand
        {
            get
            {
                return _nextCommad ?? (_nextCommad = new MvxCommand(() =>
                {
                    if (ShowCustomerInfo)
                    {
                        ShowShippingInfo = true;
                        
                        ShowBackButton = true;
                    }
                    else if (ShowShippingInfo)
                    {
                        ShowPaymentInfo = true;
                        ShowBackButton = true;
                    }
                    else
                    {
                        _orderService.CreateOreder(new OrderCreateCreteria {
                            Cart = Cart,
                            Customer = Customer,
                            PaymentId = PaymentMethods.FirstOrDefault(x => x.IsSelect).Method.Id,
                            ShippingId = _shippingMethodId
                        });
                        ShowViewModel<ThanksViewModel>();
                        Close(this);
                    }
                }));
            }
        }

        public MvxCommand BackCommand {
            get
            {
                return _backCommnad ?? (_backCommnad = new MvxCommand(() =>
                {
                    if (ShowPaymentInfo)
                    {
                        ShowShippingInfo = true;
                        ShowBackButton = true;
                    }
                    else if (ShowShippingInfo)
                    {
                        ShowCustomerInfo = true;
                        ShowBackButton = false;
                    }
                }));
            }
        }

        public Cart Cart { set; get; }
        public ICollection<SelectViewModel<PaymentMethod>> PaymentMethods { set; get; }
        public ICollection<SelectViewModel<ShippingMethodRate>> ShippingMethods { set; get; }

        public Action<ShippingMethodRate> SelectRateAction
        {
            get
            {
                return _selectRate ?? (_selectRate = new Action<ShippingMethodRate>(r =>
                {
                    Cart = _cartService.GetCartWithShipment(r.Id);
                    _shippingMethodId = r.Id;
                    RaisePropertyChanged("Cart");
                }));
            }
        }

        public CheckoutViewModel(ICartService cartService, IOrderService orderService)
        {
            _cartService = cartService;
            _orderService = orderService;
            Cart = _cartService.GetCart();
            PaymentMethods = _orderService.PaymentMethods().Select(x => new SelectViewModel<PaymentMethod>(x, NextCommand)).ToArray();
            ShippingMethods = _orderService.ShippingMethods().SelectMany(x => x.MethodRates).Select(x => new SelectViewModel<ShippingMethodRate>(x, _nextCommad)).ToArray();
            Customer = new Customer();
        }
    }
}
