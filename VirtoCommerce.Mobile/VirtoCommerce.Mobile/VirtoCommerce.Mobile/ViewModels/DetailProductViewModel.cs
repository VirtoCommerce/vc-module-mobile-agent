using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Model;
using VirtoCommerce.Mobile.Services;

namespace VirtoCommerce.Mobile.ViewModels
{
    public class DetailProductViewModel : MvxViewModel
    {
        #region Constructor
        public DetailProductViewModel(IProductStorageService productService, ICartService cartService, IGlobalEventor globalEventor)
        {
            _productService = productService;
            _cartService = cartService;
            _globalEventor = globalEventor;
            _globalEventor.Subscribe<Events.CartChangeEvent>(CartChange);
        }
        #endregion

        #region Services
        private readonly IProductStorageService _productService;
        private readonly ICartService _cartService;
        private readonly IGlobalEventor _globalEventor;
        #endregion

        #region Private field
        private MvxCommand _addToCartCommand;
        private MvxCommand _cartOpenCommand;
        #endregion

        #region Public properties

        public string CountInCart
        {
            get
            {
                var count = _cartService.CountInCart();
                return "Cart " + (count == 0 ? string.Empty : $"({count.ToString()})");
            }
        }
        public bool HideDescription { set; get; } = true;
        public bool HideProperties { set; get; }
        public Product Product { set; get; }
        public string ProductDescription
        {
            get
            {
                return (Product.Reviews.FirstOrDefault(x => x.ReviewType == "FullReview")?.Content) ?? Product.Reviews.FirstOrDefault()?.Content;
            }
        }
        public MvxCommand AddToCartCommand
        {
            get
            {
                return _addToCartCommand ?? (_addToCartCommand = new MvxCommand(() => { if (Product != null) _cartService.AddToCart(Product.Id); }));
            }
        }

        public MvxCommand OpenCartCommad {
            get
            {
                return _cartOpenCommand ?? (_cartOpenCommand = new MvxCommand(() => { _globalEventor.Publish(new Events.OpenCartEvent()); Close(this); }));
            }
        }
        #endregion


        #region Public methods
        public void SetSegment(int segment)
        {
            switch (segment)
            {
                case 0:
                    HideDescription = true;
                    HideProperties = false;
                    break;
                case 1:
                    HideDescription = false;
                    HideProperties = true;
                    break;
            }
            RaisePropertyChanged("HideDescription");
            RaisePropertyChanged("HideProperties");

        }

        public void Init(string id)
        {
            Product = _productService.GetProduct(id);
        }

        public void UnSubscribeEventor()
        {
            _globalEventor.UnSubcribe<Events.CartChangeEvent>(CartChange);
        }
        #endregion

        #region Private methods
        private void CartChange(Events.CartChangeEvent arg)
        {
            RaisePropertyChanged("CountInCart");
        }
        #endregion



    }
}
