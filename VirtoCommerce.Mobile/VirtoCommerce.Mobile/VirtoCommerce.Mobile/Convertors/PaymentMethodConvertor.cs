namespace VirtoCommerce.Mobile.Convertors
{
    public static class PaymentMethodConvertor
    {
        public static Entities.PaymentMethodEntity ApiModelToEntity(this ApiClient.Models.PaymentMethod payment)
        {
            return new Entities.PaymentMethodEntity
            {
                Code = payment.Code,
                Name = payment.Name,
                Id = payment.Id,
                PaymentMethodGroupType = payment.PaymentMethodGroupType,
                PaymentMethodType = payment.PaymentMethodType
            };
        }
        public static Model.PaymentMethod EntityToModel(this Entities.PaymentMethodEntity payment)
        {
            return new Model.PaymentMethod
            {
                Name = payment.Name,
                Id = payment.Id,
                Code = payment.Code
            };
        }
    }
}
