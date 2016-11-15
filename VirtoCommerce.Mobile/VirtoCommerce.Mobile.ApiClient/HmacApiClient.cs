using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.ApiClient
{
    public class HmacApiClient : BaseApiClient
    {
        private string _appId;
        private string _secretKey;
        public HmacApiClient(string baseUrl, string appId, string secretKey, string subFolder) : base(baseUrl, subFolder)
        {
            _appId = appId;
            _secretKey = secretKey;
        }

        protected override void PrepareAuthorizeData()
        {
            var signature = new ApiRequestSignature { AppId = _appId };

            var parameters = new[]
            {
                new NameValuePair(null, _appId),
                new NameValuePair(null, signature.TimestampString)
            };

            signature.Hash = HmacUtility.GetHashString(_secretKey, parameters);
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("HMACSHA256", signature.ToString());
        }
    }
}
