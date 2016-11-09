using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;
using Foundation;
using UIKit;

namespace VirtoCommerce.Mobile.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxApplicationDelegate
    {
        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            //Xamarin.Themes.GridlockTheme.Apply();
            //init theme
            UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);
            UINavigationBar.Appearance.BarTintColor = UI.Consts.ColorMain;
            UINavigationBar.Appearance.Translucent = false;
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes
            {
                TextColor = UIColor.White
            });
            UINavigationBar.Appearance.TintColor = UIColor.White;
            UISegmentedControl.Appearance.TintColor = UI.Consts.ColorMain;
            UISegmentedControl.Appearance.SetTitleTextAttributes(new UITextAttributes { TextColor = UI.Consts.ColorMain }, UIControlState.Normal);
            UITableViewCell.Appearance.TintColor = UI.Consts.ColorMain;
            //
            var setup = new Setup(this, Window);
            setup.Initialize();
            var startup = Mvx.Resolve<IMvxAppStart>();
            startup.Start();

            Window.MakeKeyAndVisible();

            return true;
        }
    }
}