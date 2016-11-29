using VirtoCommerce.Mobile.ApiClient.Models;
using Xamarin.Forms;

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
            var mainColor = HexStringToByteArray(model.MainColor);
            var result = new Entities.ThemeSettingsEntity
            {
                Id = model.Id,
                MainColorA = mainColor[3],
                MainColorR = mainColor[0],
                MainColorG = mainColor[1],
                MainColorB = mainColor[2],
            };
            return result;
        }

        private static byte[] HexStringToByteArray(string hex)
        {
            var color = Color.FromHex(hex);
            return new byte[] { (byte)(255 * color.R), (byte)(255 * color.G), (byte)(255 * color.B), (byte)(255 * color.A) };
        }
    }
}
