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
        /// <summary>
        /// Navigation service for navigation page
        /// </summary>
        INavigation Navigation { set; get; }

        /// <summary>
        /// Navigation to page
        /// </summary>
        /// <param name="page"></param>
        void NavigateTo(Page page);
        /// <summary>
        /// Navigation back
        /// </summary>
        void Pop();
        /// <summary>
        /// Navigation to main page
        /// </summary>
        void NavigateToMainPage();
    }
}
