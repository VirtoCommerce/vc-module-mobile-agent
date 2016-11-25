using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Entities;

namespace VirtoCommerce.Mobile.Repositories
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Save order
        /// </summary>
        bool SaveOrder(OrderEntity order);
        /// <summary>
        /// Save order item
        /// </summary>
        bool SaveOrderItem(OrderItemEntity orderItem);
        /// <summary>
        /// Save order customer
        /// </summary>
        bool SaveOrderCustomer(OrderCustomerEntity customer);
        /// <summary>
        /// Get all orders
        /// </summary>
        ICollection<OrderEntity> GetOrders();
        /// <summary>
        /// Get order by id
        /// </summary>
        OrderEntity GetOrder(string id);
        /// <summary>
        /// Get order items
        /// </summary>
        ICollection<OrderItemEntity> GetOrderItems(string id);
        /// <summary>
        /// Get customer for order 
        /// </summary>
        OrderCustomerEntity GetOrderCustomer(string id);
        /// <summary>
        /// Start transaction
        /// </summary>
        void StartTransaction();
        /// <summary>
        /// End transaction
        /// </summary>
        void EndTransaction();
        /// <summary>
        /// Rollback transaction
        /// </summary>
        void RollbackTransaction();

        /// <summary>
        /// Get all not sync orders
        /// </summary>
        ICollection<OrderEntity> GetNotSyncOrders();
    }
}
