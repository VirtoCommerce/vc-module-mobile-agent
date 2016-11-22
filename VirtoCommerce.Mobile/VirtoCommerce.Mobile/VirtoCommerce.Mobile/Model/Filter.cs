using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Model
{
    public class Filter
    {
        public string Header { set; get; }

        public string PropertyId { set; get; }
        public ICollection<FilterItem> Items { set; get; }

        public Filter Copy()
        {
            return new Filter
            {
                Header = Header,
                PropertyId = PropertyId
            };
        }
    }
}
