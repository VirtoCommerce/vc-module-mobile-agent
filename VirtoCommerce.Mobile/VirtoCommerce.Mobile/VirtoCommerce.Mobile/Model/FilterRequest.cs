using System.Collections.Generic;

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
