using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Enums;

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
