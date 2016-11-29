using UIKit;
using MvvmCross.iOS.Views;
using VirtoCommerce.Mobile.ViewModels;
using VirtoCommerce.Mobile.iOS.UI;
using MvvmCross.Binding.BindingContext;

namespace VirtoCommerce.Mobile.iOS.Views
{
    public class ThanksView : MvxViewController
    {

        public ThanksViewModel ThanksViewModel { get { return ViewModel as ThanksViewModel; } }
        public ThanksView() : base(null, null)
        {
            Title = "Thanks";
            View.BackgroundColor = Consts.ColorMainBg;
            CreateView();
            var bindingSet = this.CreateBindingSet<ThanksView, ThanksViewModel>();
            bindingSet.Bind(_continueButton).To(x => x.GoToMainCommand);
            bindingSet.Apply();
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            //text
            _thanksLabel.SizeToFit();
            _thanksLabel.Center = new CoreGraphics.CGPoint(View.Frame.Width / 2, View.Frame.Height / 2);
            //
            var continueBtnFrame = _continueButton.Frame;
            continueBtnFrame.Width = View.Frame.Width - Consts.Padding * 2;
            continueBtnFrame.Height = Consts.ButtonHeight;
            continueBtnFrame.X = Consts.Padding;
            continueBtnFrame.Y = View.Frame.Height - continueBtnFrame.Height - Consts.Padding;
            _continueButton.Frame = continueBtnFrame;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            NavigationItem.HidesBackButton = true;
        }

        #region View
        public UILabel _thanksLabel;
        public UIButton _continueButton;

        public void CreateView()
        {
            //
            _thanksLabel = new UILabel()
            {
                TextColor = Consts.ColorBlack,
                TextAlignment = UITextAlignment.Center,
                Font = UIFont.FromName(Consts.FontNameRegular, 30),
                Text = "Thanks"
            };
            Add(_thanksLabel);
            //
            _continueButton = Helpers.UICreator.CreateSimpleButton("Continue shopping");
            Add(_continueButton);
        }
        #endregion
    }
}