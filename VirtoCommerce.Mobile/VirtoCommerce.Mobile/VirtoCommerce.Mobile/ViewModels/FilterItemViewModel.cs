using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.ViewModels
{
    public class FilterItemViewModel : MvxViewModel
    {
        public bool IsSelect { get; set; }
        public FilterItem FilterItem { set; get; }
    }
}
