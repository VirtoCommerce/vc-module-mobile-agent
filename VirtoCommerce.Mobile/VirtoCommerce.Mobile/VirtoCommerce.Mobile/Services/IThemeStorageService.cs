using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.Services
{
    public interface IThemeStorageService
    {
        /// <summary>
        /// Save theme to LocalStorage
        /// </summary>
        bool SaveTheme(ApiClient.Models.MobileTheme theme);
        /// <summary>
        /// Get current theme from LocalStorage
        /// </summary>
        ThemeSettings GetTheme();
    }
}
