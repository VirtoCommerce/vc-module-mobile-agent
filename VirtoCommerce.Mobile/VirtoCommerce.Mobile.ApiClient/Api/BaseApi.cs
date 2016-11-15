using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
