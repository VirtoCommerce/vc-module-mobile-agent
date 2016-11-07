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
        Cart AddToCart(string id);
        Cart RemoveFromCart(string id);
        Cart GetCart();
        Cart UpdateCartItem(CartItem cartItem);

        

    }
}
