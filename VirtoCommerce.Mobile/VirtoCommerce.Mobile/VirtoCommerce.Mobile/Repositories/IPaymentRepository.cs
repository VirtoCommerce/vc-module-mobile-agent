using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Repositories
{
    public interface IPaymentRepository
    {
        /// <summary>
        /// Save payment method
        /// </summary>
        bool SavePaymentMethod(Entities.PaymentMethodEntity method);
        /// <summary>
        /// Delete payment method
        /// </summary>
        bool DeletePaymentMethod(string id);
        /// <summary>
        /// Get payment by id
        /// </summary>
        Entities.PaymentMethodEntity GetPayment(string id);
        /// <summary>
        /// Get all payment methods
        /// </summary>
        ICollection<Entities.PaymentMethodEntity> GetAllPaymentMethods();
    }
}
