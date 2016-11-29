using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System.Linq;
using VirtoCommerce.Mobile.Services;

namespace VirtoCommerce.Mobile.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private CartViewModel _cartViewModel;
        private ProductsGridViewModel _productsGridViewModel;
        private readonly IGlobalEventor _eventor;
        private readonly ICartService _cartService;

        public IGlobalEventor Eventor { get { return _eventor; } }

        public string CountInCart { get { return _cartService.GetCart()?.CartItems.Sum(x => x.Quantity).ToString(); } }

        public CartViewModel CartViewModel
        {
            set { _cartViewModel = value; RaisePropertyChanged(); }
            get { return _cartViewModel; }
        }

        public ProductsGridViewModel ProductsGridViewModel
        {
            set { _productsGridViewModel = value; RaisePropertyChanged(); }
            get { return _productsGridViewModel; }
        }

        public MainViewModel(ICartService cartService, IGlobalEventor eventor)
        {
            _eventor = eventor;
            _cartService = cartService;

            ProductsGridViewModel = Mvx.IocConstruct<ProductsGridViewModel>();
            CartViewModel = Mvx.IocConstruct<CartViewModel>();
        }
    }
}
