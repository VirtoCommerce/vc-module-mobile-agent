namespace VirtoCommerce.Mobile.ApiClient.Api
{
    public class BaseApi
    {
        protected BaseApiClient Client { set; get; }

        public BaseApi(BaseApiClient client)
        {
            Client = client;
        }
    }
}
