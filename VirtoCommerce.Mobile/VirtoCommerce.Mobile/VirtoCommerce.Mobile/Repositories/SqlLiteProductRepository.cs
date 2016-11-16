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
        private readonly SQLiteConnection _connection;
        public SqlLiteProductRepository()
        {
            _connection = Xamarin.Forms.DependencyService.Get<ISqlLiteConnection>().GetConnection();
            _connection.CreateTable<ProductEntity>();
            _connection.CreateTable<ImageEntity>();
            _connection.CreateTable<ReviewEntity>();
            _connection.CreateTable<PriceEntity>();
            _connection.CreateTable<ProductPropertyEntity>();
        }

        #region Product
        public ICollection<ProductEntity> GetAllProducts()
        {
            return _connection.Table<ProductEntity>().ToList();
        }
        public ProductEntity GetProductById(string id)
        {
            return _connection.Table<ProductEntity>().FirstOrDefault(x => x.Id == id);
        }
        public bool SaveProduct(ProductEntity product)
        {
            return (_connection.Table<ProductEntity>().FirstOrDefault(x => x.Id == product.Id) == null ? _connection.Insert(product) : _connection.Update(product)) != -1;
        }

        public int GetProductCount()
        {
            return _connection.Table<ProductEntity>().Count();
        }
        #endregion

        #region Images
        public ICollection<ImageEntity> GetImagesByProduct(string productId)
        {
            return _connection.Table<ImageEntity>().Where(x => x.ProductId == productId).ToList();
        }
        public bool SaveImage(ImageEntity image)
        {
            return (_connection.Table<ImageEntity>().FirstOrDefault(x => x.Id == image.Id) == null ? _connection.Insert(image) : _connection.Update(image)) != -1;
        }
        #endregion

        #region Reviews
        public ICollection<ReviewEntity> GetReviewsByProduct(string productId)
        {
            return _connection.Table<ReviewEntity>().Where(x => x.ProductId == productId).ToList();
        }
        public bool SaveReview(ReviewEntity review)
        {
            return (_connection.Table<ReviewEntity>().FirstOrDefault(x => x.Id == review.Id) == null ? _connection.Insert(review) : _connection.Update(review)) != -1;
        }
        #endregion

        #region Prices
        public ICollection<PriceEntity> GetAllPricesByProduct(string productId)
        {
            return _connection.Table<PriceEntity>().Where(x=>x.ProductId == productId).ToList();
        }
        public bool SavePrice(PriceEntity price)
        {
            return (_connection.Table<PriceEntity>().FirstOrDefault(x => x.Id == price.Id) == null ? _connection.Insert(price) : _connection.Update(price)) != -1;

        }
        #endregion

        #region Properties
        public bool SaveProductProperty(ProductPropertyEntity propertyEntity) {
            return (_connection.Table<ProductPropertyEntity>().FirstOrDefault(x => x.Id == propertyEntity.Id) == null ? _connection.Insert(propertyEntity) : _connection.Update(propertyEntity)) != -1;
        }

        public ICollection<ProductPropertyEntity> GetProductProperties(string propductId)
        {
            return _connection.Table<ProductPropertyEntity>().Where(x => x.ProductId == propductId).ToList();
        }
        #endregion

        #region Transactions
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

        
        #endregion
    }
}
