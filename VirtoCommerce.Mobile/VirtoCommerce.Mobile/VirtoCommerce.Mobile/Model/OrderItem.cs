namespace VirtoCommerce.Mobile.Model
{
    public class OrderItem
    {
        public string Id { set; get; }
        public string OrderId { set; get; }
        public string ProductId { set; get; }
        public int Quantity { set; get; }
        public string Currency { set; get; }
        public decimal SubTotal { set; get; }
        public decimal Discount { get; set; }
    }
}
