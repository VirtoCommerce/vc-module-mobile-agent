namespace VirtoCommerce.Mobile.Model
{
    public class ShippingMethodRate
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public decimal Rate { set; get; }

        public ShippingMethod ShippingMethod { set; get; }
    }
}
