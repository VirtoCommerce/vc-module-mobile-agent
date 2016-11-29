using SQLite;

namespace VirtoCommerce.Mobile.Interfaces
{
    public interface ISqlLiteConnection
    {
        SQLiteConnection GetConnection();
    }
}
