using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Mobile.Helpers;
using VirtoCommerce.Mobile.Model;
using VirtoCommerce.Mobile.Services;

namespace VirtoCommerce.Mobile.ViewModels
{
    public class ProductsGridViewModel : MvxViewModel
    {
        #region Services
        private readonly IProductStorageService _productsStorageService;
        private readonly ICartService _cartService;
        private readonly IFilterService _filterService;
        private readonly ISyncService _syncService;
        private readonly IGlobalEventor _globalEventor;
        #endregion

        #region Private field
        private string _status = "";
        private bool _isSync;
        private bool _hideBusy = true;
        private int _countProductPerPage = 20;
        private ICollection<Product> _products = new Product[0];
        private ICollection<Filter> _filters;
        #endregion

        #region Constructor
        public ProductsGridViewModel(ISyncService syncService, IProductStorageService productService, ICartService cartService, IFilterService filterService, IGlobalEventor globalEventor)
        {
            _syncService = syncService;
            _productsStorageService = productService;
            _cartService = cartService;
            _filterService = filterService;
            _globalEventor = globalEventor;
            if (!SyncManager.SyncComplete && _productsStorageService.GetProductsCount() == 0)
            {
                RunSync();
            }
            else
            {
                GetProducts(0, _countProductPerPage);
                RunBackgroundAsync();
                _globalEventor.Subscribe<Events.SyncEvent>(SyncComplate);
            }
        }

        #endregion

        #region Public properties
        public string Status
        {
            set { _status = value; RaisePropertyChanged(); }
            get { return _status; }
        }
        public bool HideBusy
        {
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

        public ICollection<Filter> Filters
        {
            get { return _filters ?? (_filters = _filterService.GetProductFilters()); }
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

        public void ApplyFilters(FilterRequest filterRequst)
        {
            Products = _productsStorageService.GetProductByFilter(filterRequst);
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Run sync with server
        /// </summary>
        private async void RunSync()
        {
            IsSync = true;
            Status = "Sync";
            await SyncManager.Sync();
            IsSync = false;
            GetProducts(0, _countProductPerPage);
        }
        /// <summary>
        /// Run sync in background
        /// </summary>
        private async void RunBackgroundAsync()
        {
            await SyncManager.Sync();
        }
        /// <summary>
        /// Sync complete 
        /// </summary>
        /// <param name="arg"></param>
        private void SyncComplate(Events.SyncEvent arg)
        {
            if (arg.IsEnd)
            {
                _globalEventor.Unsubscribe<Events.SyncEvent>(SyncComplate);
                GetProducts(0, _countProductPerPage);
            }
        }

        #endregion
    }
}

