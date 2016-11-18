using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
