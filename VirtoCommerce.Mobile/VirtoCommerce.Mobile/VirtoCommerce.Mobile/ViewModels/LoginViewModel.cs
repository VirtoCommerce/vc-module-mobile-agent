using MvvmCross.Core.ViewModels;
using VirtoCommerce.Mobile.Services;

namespace VirtoCommerce.Mobile.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        #region Services
        private readonly IUserManagerService _userManagerService;
        #endregion

        #region Private fields
        private bool _isError;
        private string _message;
        private string _login;
        private string _pass;
        private IMvxCommand _loginCommand;
        private bool _isBusy;
        #endregion

        #region Constructor
        public LoginViewModel(IUserManagerService userManagerService)
        {
            _userManagerService = userManagerService;
        }
        #endregion

        #region Public properties

        public bool IsBusy
        {
            set { _isBusy = value; RaisePropertyChanged(); }
            get { return _isBusy; }
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

        public IMvxCommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand = new MvxCommand(async () =>
                 {
                     HideShowError = true;
                     IsBusy = true;
                     if (await _userManagerService.LoginAsync(Login, Password) != null)
                     {
                         ShowViewModel<MainViewModel>();
                     }
                     else
                     {
                         HideShowError = false;
                         Message = "Incorrect login or password";
                     }
                     IsBusy = false;
                 }));
            }
        }
        #endregion
    }
}
