using System.Collections.Generic;
using VirtoCommerce.Mobile.Entities;

namespace VirtoCommerce.Mobile.Repositories
{
    public interface ICartRepository
    {
        /// <summary>
        /// Add or update cart item
        /// </summary>
        bool AddOrUpdateCartItem(CartItemEntity cartItem);
        /// <summary>
        /// Remove cart item
        /// </summary>
        bool RemoveCartItem(string id);

        /// <summary>
        /// Get all cart items
        /// </summary>
        /// <returns></returns>
        ICollection<CartItemEntity> GetAllCartItems();

        /// <summary>
        /// Get cart item by product id
        /// </summary>
        CartItemEntity GetCartItem(string id);

        /// <summary>
        /// Clear cart
        /// </summary>
        bool ClearCart();
        /// <summary>
        /// Count items in cart
        /// </summary>
        int CountInCart();
    }
}
