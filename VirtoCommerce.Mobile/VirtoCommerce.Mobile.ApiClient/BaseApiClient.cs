using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.ApiClient.Exceptions;
using Xamarin.Forms;
using VirtoCommerce.Mobile.ApiClient.Models;
using System.Net.Http.Headers;

namespace VirtoCommerce.Mobile.ApiClient
{
    public abstract class BaseApiClient
    {
        protected HttpClient Client { set; get; }
        private string _subFolder = "";
        public BaseApiClient(string baseUrl, string subFolder = "")
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(baseUrl);
            _subFolder = subFolder;
        }


        protected virtual void PrepareAuthorizeData()
        {
        }

        protected bool ExistInternet
        { 
            get { return CrossConnectivity.Current.IsConnected; }
        }

        public async Task<TResponse> PostJsonRequestWithParamsAsync<TResponse>(string url, List<KeyValuePair<string, object>> param)
        {
            if (!ExistInternet)
            {
                throw new NoInternetConnectionException();
            }
            var serializedParams = new List<KeyValuePair<string, string>>();
            foreach (var p in param)
            {
                serializedParams.Add(new KeyValuePair<string, string>(p.Key, JsonConvert.SerializeObject(p.Value)));
            }
            var serializedData = new FormUrlEncodedContent(serializedParams);
            //authorize
            PrepareAuthorizeData();
            var message = new HttpRequestMessage(HttpMethod.Post, $"{_subFolder}/{url}")
            {
                Content = serializedData
            };
            using (var response = await Client.SendAsync(message))
            {
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("Server error");
                }
                using (var content = response.Content)
                {
                    // ... Read the string.
                    var result = await content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<TResponse>(result);
                }
            }
        }

        public async Task<TResponse> GetRequestAsync<TResponse>(string url) where TResponse : class
        {
            if (!ExistInternet)
            {
                throw new NoInternetConnectionException();
            }
            //authorize
            PrepareAuthorizeData();
            HttpRequestMessage request = new HttpRequestMessage();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (var response = await Client.GetAsync($"{_subFolder}/{url}"))
            {
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("Server error");
                }

                using (var content = response.Content)
                {

                    var result = await content.ReadAsStringAsync();
                    
                    return JsonConvert.DeserializeObject<TResponse>(result);

                }
            }
        }

        public async Task<TResponse> PostJsonRequestAsync<TResponse, TRequest>(string url, TRequest request) where TRequest : class
        {

            if (!ExistInternet)
            {
                throw new NoInternetConnectionException();
            }
            var serializedData = JsonConvert.SerializeObject(request);
            //authorize
            PrepareAuthorizeData();
            using (var response = await Client.PostAsync($"{_subFolder}/{url}", new StringContent(serializedData, Encoding.UTF8, "application/json")))
            {
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("Server error");
                }
                using (var content = response.Content)
                {

                    var result = await content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TResponse>(result);

                }
            }
        }
        public TResponse PostJsonRequest<TResponse, TRequest>(string url, TRequest request) where TRequest : class
        {

            if (!ExistInternet)
            {
                throw new NoInternetConnectionException();
            }
            var serializedData = JsonConvert.SerializeObject(request);
            //authorize
            PrepareAuthorizeData();
            using (var response = Client.PostAsync($"{_subFolder}/{url}", new StringContent(serializedData, Encoding.UTF8, "application/json")).Result)
            {
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("Server error");
                }
                using (var content = response.Content)
                {
                    // ... Read the string.
                    var result = content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<TResponse>(result);
                }
            }
        }
    }
}
