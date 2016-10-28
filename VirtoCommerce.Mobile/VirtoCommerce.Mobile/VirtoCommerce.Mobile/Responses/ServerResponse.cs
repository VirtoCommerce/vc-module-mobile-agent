using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Enums;

namespace VirtoCommerce.Mobile.Responses
{
    /// <summary>
    /// Server get one object
    /// </summary>
    public class ServerResponse<T> : BaseResponse where T : class
    {
        /// <summary>
        /// Data
        /// </summary>
        public T Data { set; get; }
        
    }
}
