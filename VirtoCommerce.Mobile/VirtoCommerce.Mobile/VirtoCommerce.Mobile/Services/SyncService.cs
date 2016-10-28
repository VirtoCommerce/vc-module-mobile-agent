using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Enums;
using VirtoCommerce.Mobile.Model;
using VirtoCommerce.Mobile.Responses;

namespace VirtoCommerce.Mobile.Services
{
    public class SyncService : ISyncService
    {
        private readonly ISyncServerService _syncServerService;
        private readonly IProductStorageService _productStorageService;
        public SyncService(ISyncServerService serverSyncService, IProductStorageService productStorageService)
        {
            _syncServerService = serverSyncService;
            _productStorageService = productStorageService;
        }
        public async Task<SyncResponse> SyncProducts()
        {
            var syncResponse = new SyncResponse();
            //get products from server
            var products = await _syncServerService.GetProducts();
            if (products.Status != ResponseStatus.Ok)
            {
                syncResponse.SyncStatus = SyncStatus.Error;
                syncResponse.Message = products.Message;
                return syncResponse;
            }
            _productStorageService.SaveProducts(products.Data);
            return syncResponse;
        }

        public async Task<SyncResponse> SyncFilters()
        {
            var syncResponse = new SyncResponse();
            //get filters from server
            var filters = await _syncServerService.GetFilters();
            if (filters.Status != ResponseStatus.Ok)
            {
                syncResponse.SyncStatus = SyncStatus.Error;
                syncResponse.Message = filters.Message;
                return syncResponse;
            }
            return syncResponse;
        }

    }
}
