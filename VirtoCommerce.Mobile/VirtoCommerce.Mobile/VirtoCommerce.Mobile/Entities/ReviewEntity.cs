namespace VirtoCommerce.Mobile.Entities
{
    public class ReviewEntity : BaseEntity
    {
        public string Content { set; get; }
        public string ReviewType { set; get; }
        public string LanguageCode { set; get; }
        public string ProductId { set; get; }
    }
}
