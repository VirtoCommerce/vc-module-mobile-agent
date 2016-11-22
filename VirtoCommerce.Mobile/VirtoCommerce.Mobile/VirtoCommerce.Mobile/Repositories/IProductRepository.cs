using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Entities;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.Repositories
{
    public interface IProductRepository
    {

        #region Product
        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="productId"></param>
        void DeleteProductById(string productId);
        /// <summary>
        /// Get product count
        /// </summary>
        /// <returns></returns>
        int GetProductCount();
        /// <summary>
        /// Get product entity by id
        /// </summary>
        ProductEntity GetProductById(string id);
        /// <summary>
        /// Get all products from DB
        /// </summary>
        /// <returns></returns>
        ICollection<ProductEntity> GetAllProducts();
        /// <summary>
        /// Save product entity
        /// </summary>
        bool SaveProduct(ProductEntity product);
        #endregion

        #region Images
        /// <summary>
        /// Get all images for product
        /// </summary>
        ICollection<ImageEntity> GetImagesByProduct(string productId);
        /// <summary>
        /// Save image entity
        /// </summary>
        bool SaveImage(ImageEntity image);
        /// <summary>
        /// Delete image by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteImageById(string id);
        #endregion

        #region Properties
        /// <summary>
        /// Save product property
        /// </summary>
        bool SaveProductProperty(ProductPropertyEntity propertyEntity);
        /// <summary>
        /// Get product properties
        /// </summary>
        ICollection<ProductPropertyEntity> GetProductProperties(string propductId);
        /// <summary>
        /// Delete property by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeletePropertyById(string id);
        #endregion

        #region Reviews
        /// <summary>
        /// Get all reviews for product
        /// </summary>
        ICollection<ReviewEntity> GetReviewsByProduct(string productId);
        /// <summary>
        /// Save review entity
        /// </summary>
        bool SaveReview(ReviewEntity review);
        /// <summary>
        /// Delete review by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteReviewById(string id);
        #endregion

        #region Price
        /// <summary>
        /// Get all prices for product
        /// </summary>
        ICollection<PriceEntity> GetPricesByProduct(string productId);
        /// <summary>
        /// Save price entity
        /// </summary>
        bool SavePrice(PriceEntity price);
        /// <summary>
        /// Delete price by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeletePriceById(string id);

        #endregion

        #region Currency
        /// <summary>
        /// Save current currency
        /// </summary>
        /// <returns></returns>
        bool SaveCurrency(CurrencyEntity currency);

        /// <summary>
        /// Get current currency
        /// </summary>
        /// <returns></returns>
        CurrencyEntity GetCurrentCurrency();
        #endregion

        #region Trasaction
        /// <summary>
        /// Begin transaction
        /// </summary>
        void StartTransaction();
        /// <summary>
        /// Commit transaction
        /// </summary>
        void EndTransaction();
        /// <summary>
        /// Rollback transaction
        /// </summary>
        void RollBackTransaction();
        #endregion
        
    }
}
