using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform.Platform;
using UIKit;
using VirtoCommerce.Mobile.iOS.Views;

namespace VirtoCommerce.Mobile.iOS
{
    public class Setup : MvxIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }
        
        public Setup(MvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter)
            : base(applicationDelegate, presenter)
        {
        }
        protected override IMvxIosViewPresenter CreatePresenter()
        {
            return new CustomPresentor(ApplicationDelegate, Window);
        }
        protected override IMvxApplication CreateApp()
        {
            return new App();
        }
        
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }

    public class CustomPresentor : MvxIosViewPresenter
    {
        public CustomPresentor(IUIApplicationDelegate applicationDelegate, UIWindow window) : base(applicationDelegate, window)
        {
        }
        public override void Show(IMvxIosView view)
        {
            base.Show(view);
            /*var mainView = view as MainView;
            if (mainView != null)
            {
                mainView.
            }
            else
            {
                ((MvxViewController)view).NavigationController.NavigationBarHidden = false;
            }*/
            
        }
    }
}
