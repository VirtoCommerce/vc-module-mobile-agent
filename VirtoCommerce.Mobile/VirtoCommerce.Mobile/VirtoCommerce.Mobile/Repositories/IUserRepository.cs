using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Entities;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Save user entity to LocalStorage 
        /// </summary>
        bool SaveUser(User user);
        /// <summary>
        /// Get current user
        /// </summary>
        User GetUser();
    }
}
