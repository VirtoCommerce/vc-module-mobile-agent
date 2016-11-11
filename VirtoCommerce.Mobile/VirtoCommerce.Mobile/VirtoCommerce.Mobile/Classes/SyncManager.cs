using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Services;

namespace VirtoCommerce.Mobile.Classes
{
    public class SyncManager
    {
        public static async Task<bool> Sync()
        {
            if (SyncComplete)
                return true;
            SyncRun = true;
            await Task.Delay(5000);
            var syncService = Mvx.Resolve<ISyncService>();
            await syncService.SyncFilters();
            await syncService.SyncProducts();
            SyncRun = false;
            SyncComplete = true;
            return true;
        }
        public static bool SyncRun { set; get; }
        public static bool SyncComplete { get; set; }

    }
}
