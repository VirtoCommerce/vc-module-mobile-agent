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
