using VirtoCommerce.Mobile.Entities;

namespace VirtoCommerce.Mobile.Repositories
{
    public interface IThemeSettingsRepository
    {
        /// <summary>
        /// Save theme settings
        /// </summary>
        bool SaveSettings(ThemeSettingsEntity settings);
        /// <summary>
        /// Get theme settings
        /// </summary>
        ThemeSettingsEntity GetSettings();
    }
}
