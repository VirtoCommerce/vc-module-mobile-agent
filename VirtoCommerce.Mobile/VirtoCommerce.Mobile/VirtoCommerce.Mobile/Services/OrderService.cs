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
        public Order CreateOreder()
        {
            return new Order();
        }

        public ICollection<PaymentMethod> PaymentMethods()
        {
            return new List<PaymentMethod>() { new PaymentMethod { Name = "Cash" }, new PaymentMethod { Name = "Visa" } };
        }
    }
}
