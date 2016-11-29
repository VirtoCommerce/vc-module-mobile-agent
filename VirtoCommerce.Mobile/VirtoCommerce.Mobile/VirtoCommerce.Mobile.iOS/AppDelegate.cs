using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;
using Foundation;
using UIKit;
using VirtoCommerce.Mobile.Services;
using VirtoCommerce.Mobile.iOS.NativConvertors;
using ToastIOS;
using VirtoCommerce.Mobile.Helpers;
using Xamarin.Forms;

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
            Forms.Init();
            //Xamarin.Themes.GridlockTheme.Apply();
            //init theme
            
            //
            var setup = new Setup(this, Window);
            setup.Initialize();

            var startup = Mvx.Resolve<IMvxAppStart>();
            Mvx.Resolve<IGlobalEventor>().Subscribe<Events.SyncEvent>(SetSyncIndicator);
            SetTheme();
            startup.Start();
            
            Window.MakeKeyAndVisible();

            return true;
        }
        private void SetSyncIndicator(Events.SyncEvent eventArgs)
        {
            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = !eventArgs.IsEnd;
            if (eventArgs.IsEnd)
            {
                Mvx.Resolve<IGlobalEventor>().Unsubscribe<Events.SyncEvent>(SetSyncIndicator);
                var toaster = Toast.MakeText(string.IsNullOrEmpty(eventArgs.Message) ? "Sync complete" : eventArgs.Message).SetDuration(1500).SetCornerRadius(0).SetBgAlpha(1).SetGravity(ToastGravity.Center);
                SetTheme();
                
                if (eventArgs.IsError)
                {
                    toaster.Show(ToastType.Error);
                }
                else if (eventArgs.IsWarning)
                {
                    toaster.Show(ToastType.Warning);
                }
                else {
                    toaster.Show(ToastType.Info);
                }
            }
        }
        private void SetTheme()
        {
            var theme = Mvx.Resolve<IThemeStorageService>().GetTheme();
            //set theme values
            if (theme != null)
            {
                var refresh = false;
                var newMain = theme.MainColor.ToUIColor();
                if (!ComapareColors(UI.Consts.ColorMain, newMain))
                {
                    refresh = true;
                }
                UI.Consts.ColorMain = newMain;

                if (SyncManager.SyncComplete && refresh)
                {
                    var startup = Mvx.Resolve<IMvxAppStart>();
                    startup.Start();
                }
                
            }
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
        }
        private bool ComapareColors(UIColor color1, UIColor color2)
        {
            
            return color1.Equals(color2);
        }
    }
}