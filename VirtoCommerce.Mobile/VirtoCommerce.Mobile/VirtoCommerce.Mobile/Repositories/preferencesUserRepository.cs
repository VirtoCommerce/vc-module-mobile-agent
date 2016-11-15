using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Helpers;
using VirtoCommerce.Mobile.Entities;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.Repositories
{
    public class PreferencesUserRepository : IUserRepository
    {
        public User GetUser()
        {
            return Settings.CurrentUser;
        }

        public bool SaveUser(User user)
        {
            try
            {
                Settings.CurrentUser = user;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
