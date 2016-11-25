using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.ViewModels
{
    public class SelectViewModel<T>:MvxViewModel where T:class
    {
        private T _method;
        private bool _isSelect;
        private MvxCommand _commandCheck;
        public SelectViewModel(T method, MvxCommand commandCheck)
        {
            _method = method;
            _commandCheck = commandCheck;
        }
        public T Method
        {
            get
            {
                return _method;
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
