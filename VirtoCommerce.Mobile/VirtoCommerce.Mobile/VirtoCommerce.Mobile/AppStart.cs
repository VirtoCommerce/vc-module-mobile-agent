using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Services;
using VirtoCommerce.Mobile.ViewModels;

namespace VirtoCommerce.Mobile
{
    public class AppStart: MvxNavigatingObject, IMvxAppStart
    {
        private readonly IUserManagerService _userManager;

        public AppStart(IUserManagerService userManager)
        {
            _userManager = userManager;
        }

        public void Start(object hint = null)
        {
            if (_userManager.IsLogin())
            {
                ShowViewModel<MainViewModel>();
            }
            else
            {
                ShowViewModel<LoginViewModel>();
            }
        }
    }
}
