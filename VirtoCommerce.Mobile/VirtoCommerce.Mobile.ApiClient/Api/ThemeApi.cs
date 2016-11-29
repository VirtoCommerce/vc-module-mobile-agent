using System.Threading.Tasks;
using VirtoCommerce.Mobile.ApiClient.Models;

namespace VirtoCommerce.Mobile.ApiClient.Api
{
    public class ThemeApi : BaseApi, IThemeApi
    {
        public ThemeApi(BaseApiClient client) : base(client)
        { }
        public async Task<MobileTheme> GetThemeAsync(string userLogin)
        {
            return await Client.GetRequestAsync<MobileTheme>($"api/mobile/sync/theme/{userLogin}");
        }
    }
}
