using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.ApiClient.Models;

namespace VirtoCommerce.Mobile.ApiClient.Api
{
    public class LoginApi:BaseApi, ILoginApi
    {
        public LoginApi(BaseApiClient client):base(client)
        {

        }
        public async Task<SignInResult> LoginAsync(string name, string password)
        {
            return await Client.PostJsonRequestAsync<SignInResult, object>($"api/storefront/security/user/signin?userName={name}&password={password}", new object());
        }
        public SignInResult Login(string name, string password)
        {
            return Client.PostJsonRequest<SignInResult, object>($"api/storefront/security/user/signin?userName={name}&password={password}", new object());
        }
    }
}
