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
        private readonly INavigationService _navigationService;
        public INavigationService NavigationService { get { return _navigationService; } }
        private readonly ISyncService _syncService;
        private string _status = "";
        private bool _isSync;
        private bool _displayTable = true;
        public string Status
        {
            set { _status = value; RaisePropertyChanged(); }
            get { return _status; }
        }
        public bool DisplayTable {
            get { return _displayTable; }
            set { _displayTable = value; RaisePropertyChanged(); }
        }
        public bool IsSync
        {
            get { return _isSync; }
            set { _isSync = value; _displayTable = !_isSync; RaisePropertyChanged(); }
        }

        public ProductsGridViewModel(INavigationService navigation, ISyncService syncService)
        {
            Title = "Products";
            _syncService = syncService;
            _navigationService = navigation;
            if (!App.SyncComplete)
            {
                RunSync();
            }
        }
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
        }
    }
}
