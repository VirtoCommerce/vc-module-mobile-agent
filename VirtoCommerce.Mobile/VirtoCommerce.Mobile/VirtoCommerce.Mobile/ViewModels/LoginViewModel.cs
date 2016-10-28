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
    public class LoginViewModel : ViewModelBase
    {
        private readonly IUserManagerService _userManagerService;
        private readonly INavigationService _navigationService;
        public LoginViewModel(IUserManagerService userManagerService, INavigationService navigationService)
        {
            _userManagerService = userManagerService;
            _navigationService = navigationService;
            Title = "Login";
        }
        public string Login { set; get; }
        public string Password { set; get; }

        private Command _loginCommand;
        public Command LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new Command(() =>
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
