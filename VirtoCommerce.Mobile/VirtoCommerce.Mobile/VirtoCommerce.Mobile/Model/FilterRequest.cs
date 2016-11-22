using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Model
{
    public class FilterRequest
    {
        public FilterRequest()
        {
            Filters = new List<Filter>();
        }
        public ICollection<Filter> Filters { set; get; }
    }
}
