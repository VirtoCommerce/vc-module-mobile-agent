using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using VirtoCommerce.Mobile.iOS.UI;
using VirtoCommerce.Mobile.ViewModels;
using Xamarin.Themes;

namespace VirtoCommerce.Mobile.iOS.Views
{
    public class LoginView : MvxViewController
    {
        public LoginView() : base(null, null)
        {
            View.BackgroundColor = Consts.ColorMainBg;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            CreateView();
            var set = this.CreateBindingSet<LoginView, LoginViewModel>();
            set.Bind(_login).To(x => x.Login);
            set.Bind(_login).For(x => x.Enabled).To(x => x.IsBusy).WithConversion(new NativConvertors.InvertBoolConvertor());
            set.Bind(_pass).To(x => x.Password);
            set.Bind(_pass).For(x => x.Enabled).To(x => x.IsBusy).WithConversion(new NativConvertors.InvertBoolConvertor());
            set.Bind(_loginButton).To(x => x.LoginCommand);
            set.Bind(_loginButton).For(x => x.Enabled).To(x => x.IsBusy).WithConversion(new NativConvertors.InvertBoolConvertor());
            set.Bind(_message).For(x => x.Hidden).To(x => x.HideShowError);
            set.Bind(_message).For(x => x.Text).To(x => x.Message);
            set.Bind(_busyIndicator).For(x => x.Hidden).To(x => x.IsBusy).WithConversion(new NativConvertors.InvertBoolConvertor());
            set.Apply();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            NavigationController.NavigationBarHidden = true;
        }

        #region View

        private UITextField _login;
        private UITextField _pass;
        private UIButton _loginButton;
        private UIView _container;
        private UILabel _message;
        private UIActivityIndicatorView _busyIndicator;
        private void CreateView()
        {
            View = new UIView()
            {
                BackgroundColor = Consts.ColorMainBg
            };
            _container = new UIView(new CGRect(0, 0, 211, 152));
            _login = new UITextField(new CGRect(0, 0, 211, 30))
            {
                Placeholder = "Login",
                BorderStyle = UITextBorderStyle.Bezel
            };
            _pass = new UITextField(new CGRect(0, 38, 211, 30))
            {
                SecureTextEntry = true,
                Placeholder = "Password",
                BorderStyle = UITextBorderStyle.Bezel
            };
            _loginButton = Helpers.UICreator.CreateSimpleButton("Login");// new UIButton();
            _loginButton.Frame = new CGRect(0, 76, 211, 30);
            _message = new UILabel(new CGRect(0, 114, 211, 30))
            {
                TextColor = Consts.ColorRed
            };
            _showKbNotification = UIKeyboard.Notifications.ObserveDidShow(DidShowKeyboard);
            _hideKbNotification = UIKeyboard.Notifications.ObserveDidHide(DidHideKeyboard);
            _busyIndicator = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.Gray);
            _busyIndicator.Frame = new CGRect(0, 114, 211, 30);
            _container.AddSubviews(_login, _pass, _loginButton, _message, _busyIndicator);
            View.Add(_container);
        }
        private NSObject _showKbNotification;
        private NSObject _hideKbNotification;
        private bool _showKb;
        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            _container.Center = new CGPoint(View.Frame.Size.Width / 2, View.Frame.Size.Height / 2);
        }

        private void DidShowKeyboard(object o, UIKeyboardEventArgs e)
        {
            if (!_showKb)
            {
                var keyboardSize = UIKeyboard.BoundsFromNotification(e.Notification);
                _container.Center = new CGPoint(_container.Center.X, _container.Center.Y - keyboardSize.Height / 2);
                _showKb = !_showKb;
            }
        }
        private void DidHideKeyboard(object o, UIKeyboardEventArgs e)
        {
            if (_showKb)
            {
                var keyboardSize = UIKeyboard.BoundsFromNotification(e.Notification);
                _container.Center = new CGPoint(_container.Center.X, _container.Center.Y + keyboardSize.Height / 2);
                _showKb = !_showKb;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _showKbNotification.Dispose();
            _hideKbNotification.Dispose();
        }
        #endregion
    }
}
