using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.ViewModels
{
    public class PaymnetMethodViewModel
    {
        private PaymentMethod _paymentMethod;
        private bool _isSelect;
        public PaymnetMethodViewModel(PaymentMethod method)
        {
            _paymentMethod = method;
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
            set { _isSelect = value; NotificationSelectChange?.Invoke(); }
            get { return _isSelect; }
        }
    }
}
