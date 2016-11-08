using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
