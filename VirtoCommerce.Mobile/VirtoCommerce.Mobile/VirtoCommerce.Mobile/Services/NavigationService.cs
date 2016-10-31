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
        public INavigation Navigation { set; get; }

        public async void NavigateTo(Page page)
        {
            if (Navigation != null)
            {
                await Navigation.PushAsync(page);
            }
        }

        public void NavigateToMainPage()
        {
            //Application.Current.MainPage = App.UnityContainer.Resolve<ProductsGridView>();
        }

        public async void Pop()
        {
            if (Navigation != null)
            {
                await Navigation.PopAsync();
            }
        }
    }
}
