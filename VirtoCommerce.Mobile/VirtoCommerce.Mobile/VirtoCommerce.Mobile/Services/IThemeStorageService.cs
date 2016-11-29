using VirtoCommerce.Mobile.ApiClient.Models;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.Services
{
    public interface IThemeStorageService
    {
        /// <summary>
        /// Save theme to LocalStorage
        /// </summary>
        bool SaveTheme(MobileTheme theme);
        /// <summary>
        /// Get current theme from LocalStorage
        /// </summary>
        ThemeSettings GetTheme();
    }
}
