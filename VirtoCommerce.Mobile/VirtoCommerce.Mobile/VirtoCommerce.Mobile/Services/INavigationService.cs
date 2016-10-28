using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VirtoCommerce.Mobile.Services
{
    public interface INavigationService
    {
        void NavigateTo(Page page);
        void Pop();
        void NavigateToMainPage();
    }
}
