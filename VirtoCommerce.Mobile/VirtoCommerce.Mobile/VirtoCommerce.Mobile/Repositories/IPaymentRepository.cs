using System.Collections.Generic;
using VirtoCommerce.Mobile.Entities;

namespace VirtoCommerce.Mobile.Repositories
{
    public interface IPaymentRepository
    {
        /// <summary>
        /// Save payment method
        /// </summary>
        bool SavePaymentMethod(PaymentMethodEntity method);
        /// <summary>
        /// Delete payment method
        /// </summary>
        bool DeletePaymentMethod(string id);
        /// <summary>
        /// Get payment by id
        /// </summary>
        PaymentMethodEntity GetPayment(string id);
        /// <summary>
        /// Get all payment methods
        /// </summary>
        ICollection<PaymentMethodEntity> GetAllPaymentMethods();
    }
}
