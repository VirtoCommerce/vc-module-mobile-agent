using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using System;
using System.Collections.Generic;
using System.Text;
using VirtoCommerce.Mobile.ViewModels;

namespace VirtoCommerce.Mobile.iOS.Views
{
    public partial class LoginView : MvxViewController
    {
        public LoginView() : base("LoginView", null)
        {

        }

        public LoginView(IntPtr ptr) : base(ptr)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var set = this.CreateBindingSet<LoginView, LoginViewModel>();
            set.Bind(Login).To(vm => vm.Login);
            set.Bind(Password).To(vm => vm.Password);
            set.Bind(LoginButton).To(vm => vm.LoginCommand);
            set.Apply();
        }
    }
}

