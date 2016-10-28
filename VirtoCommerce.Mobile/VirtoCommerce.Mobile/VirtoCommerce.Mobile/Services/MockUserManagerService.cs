using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.Services
{
    public class MockUserManagerService : IUserManagerService
    {
        public bool IsLogin()
        {
            return false;
        }

        public User Login(string userName, string password)
        {
            return new User
            {
                Name = userName
            };
        }
    }
}
