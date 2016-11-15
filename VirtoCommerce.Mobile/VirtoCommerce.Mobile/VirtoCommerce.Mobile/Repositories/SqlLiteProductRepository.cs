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
    public class SqlLiteProductRepository : IProductRepository
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

        public void SavePrices(string id, ICollection<PriceEntity> prices)
        {
            throw new NotImplementedException();
        }

        public bool SaveProduct(ProductEntity product)
        {
            return _connection.Insert(product) != -1;
        }

        public void StartTransaction()
        {
            _connection.BeginTransaction();
        }
        public void EndTransaction()
        {
            _connection.Commit();
        }

        public void RollBackTransaction()
        {
            _connection.Rollback();
        }

        public bool SaveImage(ImageEntity images)
        {
            throw new NotImplementedException();
        }

        public bool SaveReview(ReviewEntity reviews)
        {
            throw new NotImplementedException();
        }

        public bool SavePrice(PriceEntity prices)
        {
            throw new NotImplementedException();
        }
    }
}
