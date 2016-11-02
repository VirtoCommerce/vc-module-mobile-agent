using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Services;
using Xamarin.Forms;

namespace VirtoCommerce.Mobile.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        private readonly IUserManagerService _userManagerService;
        private bool _isError;
        private string _message;
        private string _login;
        private string _pass;
        public LoginViewModel(IUserManagerService userManagerService)
        {
            _userManagerService = userManagerService;
        }
       
        public string Login
        {
            set
            {
                _login = value;
                HideShowError = true;
                RaisePropertyChanged();
            }
            get { return _login; }
        }
        public string Password
        {
            set
            {
                _pass = value;
                HideShowError = true;
                RaisePropertyChanged();
            }
            get
            {
                return _pass;
            }
        }

        public bool HideShowError
        {
            set
            {
                _isError = !value;
                RaisePropertyChanged();
            }
            get
            {
                return !_isError;
            }
        }

        public string Message
        {
            set
            {
                _message = value;
                RaisePropertyChanged();
            }
            get { return _message; }
        }

        private IMvxCommand _loginCommand;
        public IMvxCommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new MvxCommand(() =>
                 {
                     if (_userManagerService.Login(Login, Password) != null)
                     {
                         ShowViewModel<MainViewModel>();
                     }
                     else
                     {
                         HideShowError = false;
                         Message = "Incorrect login or password";
                     }
                 }));
            }
        }
    }
}
