using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtoCommerce.Mobile.SyncModule.Web.Convertors
{
    public static class MobileSettingsConvertor
    {
        public static Data.Models.MobileSetting ToCoreModel(this Models.MobileSetting settings)
        {
            return new Data.Models.MobileSetting
            {
                Id = settings.Id,
                AccountId = settings.AccountId,
                ProductsCategoryId = settings.SelectStore?.Id,
                CreatedDate = settings.CreatedDate,
                CreatedBy = settings.CreatedBy,
                MainColor = settings.MainColor
            };
        }

        public static Models.MobileSetting ToModel(this Data.Models.MobileSetting settings)
        {
            return new Models.MobileSetting
            {
                Id = settings.Id,
                AccountId = settings.AccountId,
                CreatedDate = settings.CreatedDate,
                CreatedBy = settings.CreatedBy,
                MainColor = settings.MainColor
                
            };
        }

    }
}