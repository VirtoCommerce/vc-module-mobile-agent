using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.ApiClient.Models;

namespace VirtoCommerce.Mobile.Convertors
{
    public static class ThemeSettingsConvertor
    {
        public static Model.ThemeSettings ThemeEntityToModel(this Entities.ThemeSettingsEntity entity)
        {
            if (entity == null)
            {
                return null;
            }
            var result = new Model.ThemeSettings();
            result.MainColor[0] = entity.MainColorR;
            result.MainColor[1] = entity.MainColorG;
            result.MainColor[2] = entity.MainColorB;
            result.MainColor[3] = entity.MainColorA;
            return result;
        }
        public static Entities.ThemeSettingsEntity ApiThemeToEntityModel(this MobileTheme model)
        {
            var result = new Entities.ThemeSettingsEntity
            {
                Id = model.Id,
                MainColorA = model.MainColor[3],
                MainColorR = model.MainColor[0],
                MainColorG = model.MainColor[1],
                MainColorB = model.MainColor[2],
            };
            return result;
        }
    }
}
