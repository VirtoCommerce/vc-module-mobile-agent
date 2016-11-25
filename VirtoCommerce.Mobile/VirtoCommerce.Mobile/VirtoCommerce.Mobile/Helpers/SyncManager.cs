using MvvmCross.Platform;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Enums;
using VirtoCommerce.Mobile.Events;
using VirtoCommerce.Mobile.Responses;
using VirtoCommerce.Mobile.Services;

namespace VirtoCommerce.Mobile.Helpers
{
    public class SyncManager
    {
        public static async Task<bool> Sync()
        {
            if (SyncComplete)
                return true;

            Mvx.Resolve<IGlobalEventor>().Publish(new SyncEvent(false));
            SyncRun = true;
            var syncService = Mvx.Resolve<ISyncService>();
            if (!CrossConnectivity.Current.IsConnected)
            {
                SendEvent(new SyncResponse
                {
                    Message = "No connection to the server",
                    SyncStatus = SyncStatus.NotConnected
                });
                return false;
            }
            var result = await syncService.SyncFilters();
            if (result.SyncStatus != SyncStatus.Ok)
            {
                SendEvent(result);
                return false;
            }
            result = await syncService.SyncProducts();
            if (result.SyncStatus != SyncStatus.Ok)
            {
                SendEvent(result);
                return false;
            }
            result = await syncService.SyncShippingMethods();
            if (result.SyncStatus != SyncStatus.Ok)
            {
                SendEvent(result);
                return false;
            }
            result = await syncService.SyncPaymentMethods();
            if (result.SyncStatus != SyncStatus.Ok)
            {
                SendEvent(result);
                return false;
            }
            result = await syncService.SyncCurrency();
            if (result.SyncStatus != SyncStatus.Ok)
            {
                SendEvent(result);
                return false;
            }
            
            result = await syncService.SyncTheme();
            if (result.SyncStatus != SyncStatus.Ok)
            {
                SendEvent(result);
                return false;
            }
            result = await syncService.SyncOrders();
            if (result.SyncStatus != SyncStatus.Ok)
            {
                SendEvent(result);
                return false;
            }
            SendEvent(result);
            return true;
        }

        private static void SendEvent(SyncResponse response)
        {
            SyncRun = false;
            SyncComplete = true;
            var syncEvent = new SyncEvent(true);
            switch (response.SyncStatus)
            {
                case SyncStatus.NotConnected:
                    syncEvent.SetWarning(true).SetMessage(response.Message);
                    break;
                case SyncStatus.Error:
                    syncEvent.SetError(true).SetMessage(response.Message);
                    break;
            }
            Mvx.Resolve<IGlobalEventor>().Publish(syncEvent);
        }

        public static bool SyncRun { set; get; }
        public static bool SyncComplete { get; set; }

    }
}
