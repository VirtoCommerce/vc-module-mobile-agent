using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Views;
using Xamarin.Forms;

namespace VirtoCommerce.Mobile.Services
{
    public class NavigationService : INavigationService
    {
        private readonly INavigation _navigation;
        

        public NavigationService()
        {

        }

        public async void NavigateTo(Page page)
        {
            if (_navigation != null)
            {
                await _navigation.PushAsync(page);
            }
        }

        public void NavigateToMainPage()
        {
            Application.Current.MainPage = App.UnityContainer.Resolve<MainView>();
        }

        public async void Pop()
        {
            if (_navigation != null)
            {
                await _navigation.PopAsync();
            }
        }
    }
}
