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
        Task<User> LoginAsync(string userName, string password);
        /// <summary>
        /// Check user is authentication async
        /// </summary>
        Task<bool> IsLoginAsync();
        /// <summary>
        /// Check user is authentication sync
        /// </summary>
        bool IsLogin();

    }
}
