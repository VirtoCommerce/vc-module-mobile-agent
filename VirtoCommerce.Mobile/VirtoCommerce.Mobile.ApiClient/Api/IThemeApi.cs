using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.ApiClient.Models;

namespace VirtoCommerce.Mobile.ApiClient.Api
{
    public interface IThemeApi
    {
        /// <summary>
        /// Get theme for user
        /// </summary>
        Task<MobileTheme> GetThemeAsync(string userLogin);
    }
}
