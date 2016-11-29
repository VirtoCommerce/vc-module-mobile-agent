namespace VirtoCommerce.Mobile.Entities
{
    public class PriceEntity : BaseEntity
    {
        public string PricelistId { get; set; }

        public string PriceListName { get; set; }

        public string Currency { get; set; }

        public string ProductId { get; set; }

        public double? Sale { get; set; }

        public double? List { get; set; }

        public int? MinQuantity { get; set; }

        public System.DateTime? CreatedDate { get; set; }

        public System.DateTime? ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }
    }
}
