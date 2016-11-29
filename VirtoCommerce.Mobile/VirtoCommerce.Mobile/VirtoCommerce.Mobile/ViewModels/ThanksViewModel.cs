using MvvmCross.Core.ViewModels;

namespace VirtoCommerce.Mobile.ViewModels
{
    public class ThanksViewModel : MvxViewModel
    {
        private MvxCommand _goToMainCommand;
        public MvxCommand GoToMainCommand
        {
            get
            {
                return _goToMainCommand ?? (_goToMainCommand = new MvxCommand(() =>
                {
                    ShowViewModel<MainViewModel>();
                }));
            }
        }
    }
}
