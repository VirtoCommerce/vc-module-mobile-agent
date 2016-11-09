using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.ViewModels
{
    public class PaymnetMethodViewModel:MvxViewModel
    {
        private PaymentMethod _paymentMethod;
        private bool _isSelect;
        private MvxCommand _commandCheck;
        public PaymnetMethodViewModel(PaymentMethod method, MvxCommand commandCheck)
        {
            _paymentMethod = method;
            _commandCheck = commandCheck;
        }
        public PaymentMethod PaymentMethod
        {
            get
            {
                return _paymentMethod;
            }
        }
        /// <summary>
        /// For notification from VM to button and etc.
        /// </summary>
        public Action NotificationSelectChange { set; get; }
        public bool IsSelect
        {
            set
            {
                _isSelect = value;
                NotificationSelectChange?.Invoke();
                _commandCheck?.CanExecute();
                RaisePropertyChanged();
            }
            get { return _isSelect; }
        }
    }
}
