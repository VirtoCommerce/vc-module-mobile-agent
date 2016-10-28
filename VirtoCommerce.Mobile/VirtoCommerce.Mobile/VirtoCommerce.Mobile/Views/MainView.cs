using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VirtoCommerce.Mobile.Views
{
    public class MainView:MasterDetailPage
    {
        public MainView(MenuView masterPage, RootView detailPage)
        {
            Master = masterPage;
            Detail = detailPage;
        }
    }
}
