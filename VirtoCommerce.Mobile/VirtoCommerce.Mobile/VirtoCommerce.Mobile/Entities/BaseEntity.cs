using SQLite;

namespace VirtoCommerce.Mobile.Entities
{
    public abstract class BaseEntity
    {
        [PrimaryKey]
        public string Id { set; get; }
    }
}
