using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.ApiClient.Models;
using VirtoCommerce.Mobile.Model;
using VirtoCommerce.Mobile.Convertors;

namespace VirtoCommerce.Mobile.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly Repositories.IPaymentRepository _paymentRepository;
        public PaymentMethodService(Repositories.IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public bool DeleteMethod(string id)
        {
            return _paymentRepository.DeletePaymentMethod(id);
        }

        public ICollection<Model.PaymentMethod> GetAllPaymentMethods()
        {
            return _paymentRepository.GetAllPaymentMethods().Select(x=>x.EntityToModel()).ToArray();
        }

        public Model.PaymentMethod GetPayment(string id)
        {
            return _paymentRepository.GetPayment(id).EntityToModel();
        }

        public void SaveMethods(ICollection<ApiClient.Models.PaymentMethod> methods)
        {
            foreach (var method in methods)
            {
                _paymentRepository.SavePaymentMethod(method.ApiModelToEntity());
            }
        }
    }
}
