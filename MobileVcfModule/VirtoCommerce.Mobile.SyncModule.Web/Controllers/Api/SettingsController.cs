using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using VirtoCommerce.CatalogModule.Web.Converters;
using VirtoCommerce.Domain.Catalog.Model;
using VirtoCommerce.Domain.Catalog.Services;
using VirtoCommerce.Mobile.SyncModule.Data.Services;
using VirtoCommerce.Platform.Core.Security;
using VirtoCommerce.Mobile.SyncModule.Web.Convertors;
using VirtoCommerce.Domain.Store.Services;

namespace VirtoCommerce.Mobile.SyncModule.Web.Controllers.Api
{
    [RoutePrefix("api/mobile/settings")]
    public class SettingsController : ApiController
    {
        private readonly IStoreService _storeService;
        private readonly ISyncSettingsService _syncSettingsService;
        public SettingsController(IStoreService storeService, ISyncSettingsService syncSettingsService)
        {
            _storeService = storeService;
            _syncSettingsService = syncSettingsService;
        }

        [HttpGet]
        [Route("{userName}")]
        public IHttpActionResult GetSettigsByUser(string userName)
        {
            var settings = _syncSettingsService.GetSettingsByAccountName(userName);
            if (settings == null)
                return Ok();
            var webSettings = settings.ToModel();
            webSettings.AccountName = userName;
            webSettings.AccountId = settings.AccountId;
            if (!string.IsNullOrEmpty(settings.ProductsCategoryId))
            {
                webSettings.SelectStore = _storeService.GetById(settings.ProductsCategoryId);
            }
            return Ok(webSettings);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult SaveSettigs(Models.MobileSetting settings)
        {
            _syncSettingsService.SaveSettings(settings.ToCoreModel());
            return Ok();
        }

    }
}