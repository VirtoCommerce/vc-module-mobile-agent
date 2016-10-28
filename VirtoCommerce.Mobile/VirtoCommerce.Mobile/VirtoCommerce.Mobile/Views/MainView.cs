using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Services;
using Xamarin.Forms;

namespace VirtoCommerce.Mobile.Views
{
    public class MainView:MasterDetailPage
    {
        public MainView(MenuView masterPage, RootView detailPage, ISyncService syncService)
        {
            Master = masterPage;
            Detail = detailPage;
        }
    }
}
