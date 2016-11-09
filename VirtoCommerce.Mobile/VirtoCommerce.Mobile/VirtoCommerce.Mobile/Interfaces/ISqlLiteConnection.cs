using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Interfaces
{
    public interface ISqlLiteConnection
    {
        SQLiteConnection GetConnection();
    }
}
