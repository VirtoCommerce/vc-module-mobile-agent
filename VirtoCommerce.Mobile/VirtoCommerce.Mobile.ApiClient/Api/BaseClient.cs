using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VirtoCommerce.Mobile.ApiClient.Api
{
    public abstract class BaseClient
    {
        private HttpClient _client;
        public BaseClient(string baseUrl)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseUrl);
        }

        public async Task<TResponse> PostAsyncRequest<TResponse, TRequest>(string url, TRequest request) where TResponse : class where TRequest:class
        {

            var serializedData = JsonConvert.SerializeObject(request);
            using (var response = await _client.PostAsync(url, new StringContent(serializedData, Encoding.UTF8,"application/json")))
            {
                using (var content = response.Content)
                {
                    // ... Read the string.
                    var result = await content.ReadAsStringAsync();

                    try
                    {
                        return JsonConvert.DeserializeObject<TResponse>(result);
                    }
                    catch
                    {
                        return Activator.CreateInstance<TResponse>();
                    }
                }
            }
        }
    }
}
