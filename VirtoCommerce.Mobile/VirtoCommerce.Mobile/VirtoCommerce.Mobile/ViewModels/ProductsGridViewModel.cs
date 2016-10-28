using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Services;
using Xamarin.Forms;

namespace VirtoCommerce.Mobile.ViewModels
{
    public class ProductsGridViewModel : ViewModelBase
    {
        private readonly INavigationService _navigation;
        public ProductsGridViewModel(INavigationService navigation)
        {
            Title = "Products";
            _navigation = navigation;
        }
    }
}
