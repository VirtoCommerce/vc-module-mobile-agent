using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Mobile.Entities;
using VirtoCommerce.Mobile.Interfaces;
using Xamarin.Forms;

namespace VirtoCommerce.Mobile.Repositories
{
    public class SqlLiteShippingRepository : IShippingRepository
    {
        private readonly Func<SQLiteConnection>  _connectionFactory;
        public SqlLiteShippingRepository()
        {
             _connectionFactory = new Func<SQLiteConnection>(()=> DependencyService.Get<ISqlLiteConnection>().GetConnection());
            using (var connection = _connectionFactory())
            {
                connection.CreateTable<ShippingMethodEntity>();
                connection.CreateTable<ShippingRateEntity>();
            }
        }

        public void DeleteShippig(string id)
        {
            using (var connection = _connectionFactory())
            {
                connection.Table<ShippingRateEntity>().Delete(x => x.ShippingMethodId == id);
                connection.Table<ShippingMethodEntity>().Delete(x => x.Id == id);
            }
        }

        public bool DeleteShippingRate(string id)
        {
            using (var connection = _connectionFactory())
            {
                return connection.Table<ShippingRateEntity>().Delete(x => x.Id == id) != -1;
            }
        }

        public ICollection<ShippingMethodEntity> GetAllShippingMethods()
        {
            using (var connection = _connectionFactory())
            {
                return connection.Table<ShippingMethodEntity>().ToArray();
            }
        }

        public ShippingMethodEntity GetShippingMethodById(string id)
        {
            using (var connection = _connectionFactory())
            {
                return connection.Table<ShippingMethodEntity>().FirstOrDefault(x => x.Id == id);
            }
        }

        public ShippingRateEntity GetShippingRate(string id)
        {
            using (var connection = _connectionFactory())
            {
                return connection.Table<ShippingRateEntity>().FirstOrDefault(x => x.Id == id);
            }
        }

        public ICollection<ShippingRateEntity> GetShippingRatesForMethod(string id)
        {
            using (var connection = _connectionFactory())
            {
                return connection.Table<ShippingRateEntity>().Where(x => x.ShippingMethodId == id).ToArray();
            }
        }

        public bool SaveShipping(ShippingMethodEntity method)
        {
            using (var connection = _connectionFactory())
            {
                return connection.InsertOrReplace(method)!=-1;
            }
        }

        public bool SaveShippingRate(ShippingRateEntity rate)
        {
            using (var connection = _connectionFactory())
            {
                return connection.InsertOrReplace(rate) != -1;
            }
        }
    }
}
