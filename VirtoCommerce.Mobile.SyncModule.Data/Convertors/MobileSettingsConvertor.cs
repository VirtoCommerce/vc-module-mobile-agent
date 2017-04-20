using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.SyncModule.Data.Convertors
{
    public static class MobileSettingsConvertor
    {
        public static Entities.MobileSetting ToEntityModel(this Models.MobileSetting settings)
        {
            return new Entities.MobileSetting
            {
                AccountId = settings.AccountId,
                ProductsCategoryId = settings.ProductsCategoryId,
                CreatedBy = settings.CreatedBy,
                CreatedDate = settings.CreatedDate,
                Id = settings.Id,
                ModifiedBy = settings.ModifiedBy,
                ModifiedDate = settings.ModifiedDate ?? DateTime.UtcNow,
                MainColor = settings.MainColor
            };
        }

        public static Models.MobileSetting ToModel( this Entities.MobileSetting settings)
        {
            return new Models.MobileSetting
            {
                AccountId = settings.AccountId,
                CreatedBy = settings.CreatedBy,
                CreatedDate = settings.CreatedDate,
                ModifiedBy = settings.ModifiedBy,
                ModifiedDate = settings.ModifiedDate,
                ProductsCategoryId = settings.ProductsCategoryId,
                Id = settings.Id,
                MainColor = settings.MainColor
            };
        }
    }
}
