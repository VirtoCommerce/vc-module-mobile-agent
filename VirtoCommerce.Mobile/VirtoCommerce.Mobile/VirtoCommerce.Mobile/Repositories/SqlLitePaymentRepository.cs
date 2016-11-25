using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Entities;
using VirtoCommerce.Mobile.Interfaces;
using Xamarin.Forms;

namespace VirtoCommerce.Mobile.Repositories
{
    public class SqlLitePaymentRepository : IPaymentRepository
    {
        private readonly Func<SQLiteConnection> _connectionFactory;
        public SqlLitePaymentRepository()
        {
            _connectionFactory = new Func<SQLiteConnection>(() => DependencyService.Get<ISqlLiteConnection>().GetConnection());
            using (var connection = _connectionFactory())
            {
                connection.CreateTable<PaymentMethodEntity>();
            }
        }

        public bool DeletePaymentMethod(string id)
        {
            using (var connection = _connectionFactory())
            {
                return connection.Table<PaymentMethodEntity>().Delete(x => x.Id == id) != -1;
            }
        }

        public ICollection<PaymentMethodEntity> GetAllPaymentMethods()
        {
            using (var connection = _connectionFactory())
            {
                return connection.Table<PaymentMethodEntity>().ToArray();
            }
        }

        public PaymentMethodEntity GetPayment(string id)
        {
            using (var connection = _connectionFactory())
            {
                return connection.Table<PaymentMethodEntity>().FirstOrDefault(x => x.Id == id);
            }
        }

        public bool SavePaymentMethod(PaymentMethodEntity method)
        {
            using (var connection = _connectionFactory())
            {
                return connection.InsertOrReplace(method) != -1;
            }
        }
    }
}
