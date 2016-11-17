using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICartService _cartService;
        private readonly IGlobalEventor _globalEventor;
        public OrderService(ICartService cartService, IGlobalEventor eventor)
        {
            _cartService = cartService;
            _globalEventor = eventor;
        }
        public Order CreateOreder()
        {
            _cartService.ClearCart();
            _globalEventor.Publish(new Events.CartChangeEvent());
            return new Order();
        }

        public ICollection<PaymentMethod> PaymentMethods()
        {
            return new List<PaymentMethod>() { new PaymentMethod { Name = "Cash" }, new PaymentMethod { Name = "Visa" } };
        }
    }
}
