using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Mobile.Entities;
using VirtoCommerce.Mobile.Interfaces;

namespace VirtoCommerce.Mobile.Repositories
{
    public class SqlLiteOrderRepository:IOrderRepository
    {
        SQLite.SQLiteConnection _connection;
        public SqlLiteOrderRepository()
        {
            _connection = Xamarin.Forms.DependencyService.Get<ISqlLiteConnection>().GetConnection();
            _connection.CreateTable<OrderEntity>();
            _connection.CreateTable<OrderItemEntity>();
            _connection.CreateTable<OrderCustomerEntity>();
        }


        public ICollection<OrderEntity> GetNotSyncOrders()
        {
            return _connection.Table<OrderEntity>().Where(x => !x.IsSync).ToArray();
        }


        public OrderEntity GetOrder(string id)
        {
            return _connection.Table<OrderEntity>().FirstOrDefault(x => x.Id == id);
        }

        public OrderCustomerEntity GetOrderCustomer(string id)
        {
            return _connection.Table<OrderCustomerEntity>().FirstOrDefault(x => x.OrderId == id);
        }

        public ICollection<OrderItemEntity> GetOrderItems(string id)
        {
            return _connection.Table<OrderItemEntity>().Where(x => x.OrderId == id).ToArray();
        }

        public ICollection<OrderEntity> GetOrders()
        {
            return _connection.Table<OrderEntity>().ToArray();
        }

        public bool SaveOrder(OrderEntity order)
        {
            return _connection.InsertOrReplace(order)!=-1;
        }

        public bool SaveOrderCustomer(OrderCustomerEntity customer)
        {
            return _connection.InsertOrReplace(customer) != -1;
        }

        public bool SaveOrderItem(OrderItemEntity orderItem)
        {
            return _connection.InsertOrReplace(orderItem) != -1;
        }

        public void StartTransaction()
        {
            _connection.BeginTransaction();
        }
        public void EndTransaction()
        {
            _connection.Commit();
        }

        public void RollbackTransaction()
        {
            _connection.Rollback();
        }
    }
}
