using System.Collections.Generic;

namespace VirtoCommerce.Mobile.Responses
{
    /// <summary>
    /// Server get list objects
    /// </summary>
    public class ServerResponseCollection<T> : BaseResponse where T:class
    {
        public ServerResponseCollection()
        {
            Data = new T[0];
        }
        /// <summary>
        /// Data collection
        /// </summary>
        public ICollection<T> Data { set; get; }
    }
}
