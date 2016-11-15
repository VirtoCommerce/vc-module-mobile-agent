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
        /// Get product entity by id
        /// </summary>
        ProductEntity GetProductById(string id);
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
        bool SaveImage(ImageEntity images);
        /// <summary>
        /// Save review entity
        /// </summary>
        bool SaveReview(ReviewEntity reviews);
        /// <summary>
        /// Save price entity
        /// </summary>
        bool SavePrice(PriceEntity prices);
        
    }
}
