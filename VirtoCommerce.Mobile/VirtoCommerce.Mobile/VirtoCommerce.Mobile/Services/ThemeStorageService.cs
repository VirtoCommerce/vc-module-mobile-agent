using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.ApiClient.Models;
using VirtoCommerce.Mobile.Convertors;
using VirtoCommerce.Mobile.Model;
using VirtoCommerce.Mobile.Repositories;
using Xamarin.Forms;

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
            if (!string.IsNullOrEmpty(theme.LogoPath))
            {
                var imageService = DependencyService.Get<ILocalStorageImageService>();
                imageService.SaveImageLogo(new Model.Image {
                    Name = "logo",
                    Path = theme.LogoPath
                });
            }
            return _themeRepository.SaveSettings(theme.ApiThemeToEntityModel());
        }
    }
}
