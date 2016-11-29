using System.Collections.Generic;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.Services
{
    public interface IFilterService
    {
        ICollection<Filter> GetProductFilters();
    }
}
