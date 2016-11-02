using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Model;
using VirtoCommerce.Mobile.Services;
using Xamarin.Forms;

namespace VirtoCommerce.Mobile.ViewModels
{
    public class ProductsGridViewModel : MvxViewModel
    {
        #region Services
        private readonly IProductStorageService _productsStorageService;
        private readonly ICartService _cartService;
        #endregion

        #region Private field
        private readonly ISyncService _syncService;
        private string _status = "";
        private bool _isSync;
        private bool _hideBusy = true;
        private int _countProductPerPage = 20;
        private ICollection<Product> _products = new Product[0];
        #endregion

        #region Constructor
        public ProductsGridViewModel(ISyncService syncService, IProductStorageService productService, ICartService cartService)
        {
            _syncService = syncService;
            _productsStorageService = productService;
            _cartService = cartService;
           /* if (!App.SyncComplete)
            {
                RunSync();
            }
            else
            {
                GetProducts(0, _countProductPerPage);
            }*/
            GetProducts(0, _countProductPerPage);
        }
        #endregion

        #region Public properties
        public string Status
        {
            set { _status = value; RaisePropertyChanged(); }
            get { return _status; }
        }
        public bool HideBusy {
            get { return _hideBusy; }
            set { _hideBusy = value; RaisePropertyChanged(); }
        }
        public bool IsSync
        {
            get { return _isSync; }
            set
            {
                _isSync = value;
                HideBusy = !_isSync;
                RaisePropertyChanged();
            }
        }

        public ICollection<Product> Products
        {
            set
            {
                _products = value;
                RaisePropertyChanged();
            }
            get
            {
                return _products;
            }
        }
        #endregion

        #region Public methods
        public void GetProducts(int start, int count)
        {
            Products = _productsStorageService.GetProducts(start, count);
        }

        public void ShowProductDetail(int index)
        {
            ShowViewModel<DetailProductViewModel>(new { id = Products.ElementAt(index).Id });
        }

        public void AddToCart(Product product)
        {
            _cartService.AddToCart(product.Id);
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Run sync with server
        /// </summary>
        private async void RunSync()
        {
            IsSync = true;
            Status = "Sync filter";
            await _syncService.SyncFilters();
            Status = "Sync products";
            await _syncService.SyncProducts();
            Status = "";
            App.SyncComplete = true;
            IsSync = false;
            GetProducts(0, _countProductPerPage);
        }
        #endregion
    }
}

