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
        private readonly INavigationService _navigationService;
        public LoginViewModel(IUserManagerService userManagerService, INavigationService navigationService)
        {
            _userManagerService = userManagerService;
            _navigationService = navigationService;
        }
        public string Login { set; get; }
        public string Password { set; get; }

        private IMvxCommand _loginCommand;
        public IMvxCommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new MvxCommand(() =>
                 {
                     if (_userManagerService.Login(Login, Password) != null)
                     {
                         _navigationService.NavigateToMainPage();
                     }
                 }));
            }
        }
    }
}
