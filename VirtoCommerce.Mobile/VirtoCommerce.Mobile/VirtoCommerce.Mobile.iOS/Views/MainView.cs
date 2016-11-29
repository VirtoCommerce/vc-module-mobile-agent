using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using UIKit;
using VirtoCommerce.Mobile.Events;
using VirtoCommerce.Mobile.ViewModels;

namespace VirtoCommerce.Mobile.iOS.Views
{
    public class MainView : MvxTabBarViewController
    {
        private int _createdSoFarCount = 0;
        public bool _constracted = false;
        private UIViewController _cartController;
        public MainView()
        {
            _constracted = true;
            ViewDidLoad();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            MainViewModel.Eventor.Unsubscribe<CartChangeEvent>(UpdateCartBage);
            MainViewModel.Eventor.Unsubscribe<OpenCartEvent>(SetCart);
        }

        protected MainViewModel MainViewModel
        {
            get { return (MainViewModel)ViewModel; }
        }

        private void UpdateCartBage(BaseEvent eventArgs)
        {
            _cartController.TabBarItem.BadgeColor = UIColor.Red;
            _cartController.TabBarItem.BadgeValue = MainViewModel.CountInCart;
        }

        private void SetCart(OpenCartEvent arg)
        {
            SelectedViewController = _cartController;
        }


        public override void ViewDidLoad()
        {
            if (!_constracted)
                return;
            base.ViewDidLoad();

            if (ViewModel == null)
                return;
            var viewControllers = new UIViewController[] {
                CreateTabFor("Products","products-black", MainViewModel.ProductsGridViewModel),
               (_cartController =  CreateTabFor("Cart","cart-black", MainViewModel.CartViewModel)),
            };
            MainViewModel.Eventor.Subscribe<CartChangeEvent>(UpdateCartBage);
            MainViewModel.Eventor.Subscribe<OpenCartEvent>(SetCart);
            UpdateCartBage(null);
            ViewControllers = viewControllers;
            TabBar.TintColor = UI.Consts.ColorMain;
            TabBar.BarTintColor = UI.Consts.ColorSecondBg;
            TabBar.Layer.BorderWidth = 0;
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
            screen.TabBarItem = new UITabBarItem(title, UIImage.FromBundle(imageName + ".png").Scale(new CoreGraphics.CGSize(25, 25)),
                                                 _createdSoFarCount);
            _createdSoFarCount++;
        }
    }
}
