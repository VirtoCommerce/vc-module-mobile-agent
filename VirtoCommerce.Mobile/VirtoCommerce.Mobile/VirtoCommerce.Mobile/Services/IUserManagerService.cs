using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.Services
{
    public interface IUserManagerService
    {
        /// <summary>
        /// User authentication on the server
        /// </summary>
        User Login(string userName, string password);
        /// <summary>
        /// Check user is authentication
        /// </summary>
        bool IsLogin();
    }
}
