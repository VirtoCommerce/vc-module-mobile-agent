using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.Services
{
    public interface ICartService
    {
        /// <summary>
        /// Add item to cart
        /// </summary>
        Cart AddToCart(string id);
        /// <summary>
        /// Remove item from cart
        /// </summary>
        Cart RemoveFromCart(string id);
        /// <summary>
        /// Get current cart
        /// </summary>
        Cart GetCart();
        /// <summary>
        /// Update cart item 
        /// </summary>
        Cart UpdateCartItem(CartItem cartItem);
        /// <summary>
        /// Count items in cart
        /// </summary>
        int CountInCart();
        /// <summary>
        /// Clear cart
        /// </summary>
        bool ClearCart();
    }
}
