using System.Collections.Generic;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.Services
{
    public interface IOrderService
    {
        /// <summary>
        /// Create order from cart
        /// </summary>
        /// <returns></returns>
        Order CreateOreder(OrderCreateCreteria cart);
        /// <summary>
        /// Get available payment methods
        /// </summary>
        /// <returns></returns>
        ICollection<PaymentMethod> PaymentMethods();
        /// <summary>
        /// Get available shipping methods
        /// </summary>
        /// <returns></returns>
        ICollection<ShippingMethod> ShippingMethods();

        /// <summary>
        /// Get all not sync orders
        /// </summary>
        /// <returns></returns>
        ICollection<Order> GetNotSyncOrders();

        /// <summary>
        /// Set sync status orders
        /// </summary>
        void SetSyncStatusOrders(ICollection<Order> orders);
    }
}
