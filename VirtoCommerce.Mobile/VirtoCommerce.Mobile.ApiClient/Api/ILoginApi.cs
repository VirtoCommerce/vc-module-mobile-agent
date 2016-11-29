using System.Threading.Tasks;
using VirtoCommerce.Mobile.ApiClient.Models;

namespace VirtoCommerce.Mobile.ApiClient.Api
{
    public interface ILoginApi
    {
        /// <summary>
        /// Request login async
        /// </summary>
        /// <returns></returns>
        Task<SignInResult> LoginAsync(string name, string password);
        /// <summary>
        /// Request login sync
        /// </summary>
        /// <returns></returns>
        SignInResult Login(string name, string password);
    }
}
