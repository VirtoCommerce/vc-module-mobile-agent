using VirtoCommerce.Mobile.ApiClient.Models;
using VirtoCommerce.Mobile.Convertors;
using VirtoCommerce.Mobile.Model;
using VirtoCommerce.Mobile.Repositories;

namespace VirtoCommerce.Mobile.Services
{
    public class ThemeStorageService : IThemeStorageService
    {

        private readonly IThemeSettingsRepository _themeRepository;
        public ThemeStorageService(IThemeSettingsRepository themeRepository)
        {
            _themeRepository = themeRepository;
        }

        public ThemeSettings GetTheme()
        {
            return _themeRepository.GetSettings().ThemeEntityToModel();
        }

        public bool SaveTheme(MobileTheme theme)
        {

            if (theme == null)
                return true;
            return _themeRepository.SaveSettings(theme.ApiThemeToEntityModel());
        }
    }
}
