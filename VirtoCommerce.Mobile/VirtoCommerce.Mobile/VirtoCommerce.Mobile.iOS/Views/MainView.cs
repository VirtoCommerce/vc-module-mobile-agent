using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using VirtoCommerce.Mobile.ViewModels;

namespace VirtoCommerce.Mobile.iOS.Views
{
    public class MainView : MvxTabBarViewController
    {
        private int _createdSoFarCount = 0;
        public bool _constracted = false;
        public MainView()
        {
            _constracted = true;
           ViewDidLoad();
        }

        protected MainViewModel MainViewModel
        {
            get { return (MainViewModel)ViewModel; }
        }

        public override void ViewDidLoad()
        {
            if (!_constracted)
                return;
            base.ViewDidLoad();
            
            if (ViewModel == null)
                return;
            var viewControllers = new UIViewController[] {
                CreateTabFor("Products","home", MainViewModel.ProductsGridViewModel),
                CreateTabFor("Cart","cart_menu", MainViewModel.CartViewModel),
            };
            ViewControllers = viewControllers;
            SelectedViewController = viewControllers[0];
        }
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            NavigationController.NavigationBarHidden = true;
        }
        private UIViewController CreateTabFor(string title, string imageName, IMvxViewModel viewModel)
        {
            var controller = new UINavigationController();
            var screen = this.CreateViewControllerFor(viewModel) as UIViewController;
            SetTitleAndTabBarItem(screen, title, imageName);
            controller.PushViewController(screen, false);
            return controller;
        }
        private void SetTitleAndTabBarItem(UIViewController screen, string title, string imageName)
        {
            screen.Title = title;
            screen.TabBarItem = new UITabBarItem(title, UIImage.FromBundle(imageName + ".png"),
                                                 _createdSoFarCount);
            _createdSoFarCount++;
        }
    }
}
