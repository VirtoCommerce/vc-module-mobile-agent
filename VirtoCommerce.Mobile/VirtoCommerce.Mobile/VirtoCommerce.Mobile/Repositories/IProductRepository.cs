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

        /// <summary>
        /// Save product property
        /// </summary>
        bool SaveProductProperty(ProductPropertyEntity propertyEntity);
        /// <summary>
        /// Get product properties
        /// </summary>
        ICollection<ProductPropertyEntity> GetProductProperties(string propductId);
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
        /// Get all images for product
        /// </summary>
        ICollection<ImageEntity> GetImagesByProduct(string productId);
        /// <summary>
        /// Get all reviews for product
        /// </summary>
        ICollection<ReviewEntity> GetReviewsByProduct(string productId);
        /// <summary>
        /// Get all prices for product
        /// </summary>
        ICollection<PriceEntity> GetAllPricesByProduct(string productId);
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
        /// <summary>
        /// Save product entity
        /// </summary>
        bool SaveProduct(ProductEntity product);
        /// <summary>
        /// Save image entity
        /// </summary>
        bool SaveImage(ImageEntity image);
        /// <summary>
        /// Save review entity
        /// </summary>
        bool SaveReview(ReviewEntity review);
        /// <summary>
        /// Save price entity
        /// </summary>
        bool SavePrice(PriceEntity price);
        
    }
}
