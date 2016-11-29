using MvvmCross.Core.ViewModels;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.ViewModels
{
    public class FilterItemViewModel : MvxViewModel
    {
        public bool IsSelect { get; set; }
        public FilterItem FilterItem { set; get; }
        public Filter Filter { set; get; }
    }
}
