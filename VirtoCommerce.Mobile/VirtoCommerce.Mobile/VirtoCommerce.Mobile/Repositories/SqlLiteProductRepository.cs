using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Entities;
using VirtoCommerce.Mobile.Interfaces;

namespace VirtoCommerce.Mobile.Repositories
{
    public class SqlLiteProductRepository : ISqlLiteProductRepository
    {
        private SQLiteConnection _connection;
        public SqlLiteProductRepository()
        {
            _connection = Xamarin.Forms.DependencyService.Get<ISqlLiteConnection>().GetConnection();
            _connection.CreateTable<ProductEntity>();
            _connection.CreateTable<ImageEntity>();
            _connection.CreateTable<ProductEntity>();
        }
        public ProductEntity GetProductById(string id)
        {
            return _connection.Table<ProductEntity>().FirstOrDefault(x => x.Id == id);
        }

        public ProductEntity SaveProduct(ProductEntity product)
        {
            throw new NotImplementedException();
        }
    }
}
