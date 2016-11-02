using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.ViewModels
{
    public class MainViewModel: MvxViewModel
    {
        private CartViewModel _cartViewModel;

        public CartViewModel CartViewModel
        {
            set { _cartViewModel = value; RaisePropertyChanged(); }
            get { return _cartViewModel; }
        }

        private ProductsGridViewModel _productsGridViewModel;

        public ProductsGridViewModel ProductsGridViewModel
        {
            set { _productsGridViewModel = value; RaisePropertyChanged(); }
            get { return _productsGridViewModel; }
        }

        public MainViewModel()
        {
            ProductsGridViewModel = Mvx.IocConstruct<ProductsGridViewModel>();
            CartViewModel = Mvx.IocConstruct<CartViewModel>();
        }
    }
}
