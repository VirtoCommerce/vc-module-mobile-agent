namespace VirtoCommerce.Mobile.Model
{
    public class OrderCreateCreteria
    {
        public Cart Cart { set; get; }
        public Customer Customer { set; get; }
        public string ShippingId { set; get; }
        public string PaymentId { set; get; }
    }
}
