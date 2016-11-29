using System;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.ApiClient.Api;
using VirtoCommerce.Mobile.ApiClient.Exceptions;
using VirtoCommerce.Mobile.Model;
using VirtoCommerce.Mobile.Repositories;

namespace VirtoCommerce.Mobile.Services
{
    public class UserManagerService : IUserManagerService
    {


        private ILoginApi _loginApi;
        private IUserRepository _userRepository;
        public UserManagerService(ILoginApi loginApi, IUserRepository userRepository)
        {
            _loginApi = loginApi;
            _userRepository = userRepository;
        }
        public async Task<bool> IsLoginAsync()
        {
            var user = _userRepository.GetUser();
            if (user == null)
                return false;
            return await LoginAsync(user.Name, user.Password) != null;
        }
        public bool IsLogin()
        {
            var user = _userRepository.GetUser();
            if (user == null)
                return false;
            try
            {
                return Login(user.Name, user.Password) != null;
            }
            catch (NoInternetConnectionException)
            {
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public User Login(string userName, string password)
        {
            var result = _loginApi.Login(userName, password);
            if (result?.Status == "success")
            {
                var user = new User
                {
                    Name = userName,
                    Password = password
                };
                _userRepository.SaveUser(user);
                return user;
            }
            else
            {
                return null;
            }

        }
        public async Task<User> LoginAsync(string userName, string password)
        {
            try
            {
                var result = await _loginApi.LoginAsync(userName, password);

                if (result?.Status == "success")
                {
                    var user = new User
                    {
                        Name = userName,
                        Password = password
                    };
                    _userRepository.SaveUser(user);
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch (NoInternetConnectionException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
