namespace VirtoCommerce.Mobile.Model
{
    public class ProductProperty
    {
        public string ProductId { set; get; }
        public string PropertyName { get; set; }

        public string DisplayName { set; get; }

        public string PropertyId { get; set; }

        public string LanguageCode { get; set; }

        public string Alias { get; set; }

        public string ValueType { get; set; }

        public string Value { get; set; }
    }
}
