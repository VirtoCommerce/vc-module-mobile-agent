using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Entities
{
    public abstract class BaseEntity
    {
        [PrimaryKey]
        public string Id { set; get; }
    }
}
