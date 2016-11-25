using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Services
{
    public interface IPaymentMethodService
    {
        /// <summary>
        /// Save payment method
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        void SaveMethods(ICollection<ApiClient.Models.PaymentMethod> methods);
        /// <summary>
        /// Delete payment method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteMethod(string id);
        /// <summary>
        /// Get payment method id
        /// </summary>
        /// <returns></returns>
        Model.PaymentMethod GetPayment(string id);
        /// <summary>
        /// Get all payment methods
        /// </summary>
        ICollection<Model.PaymentMethod> GetAllPaymentMethods();

    }
}
