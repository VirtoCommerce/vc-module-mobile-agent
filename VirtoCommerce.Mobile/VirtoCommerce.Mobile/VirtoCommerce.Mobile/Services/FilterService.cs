using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.Services
{
    public class FilterService : IFilterService
    { 

        ICollection<Filter> IFilterService.GetProductFilters()
        {
            return new[] {
                new Filter
                {
                   Header = "Coast",
                   Items = new[] {
                       new FilterItem {
                           Name = "1000",
                           Value = "1000"
                       },
                       new FilterItem {
                           Name = "2000",
                           Value = "2000"
                       }
                   } 
                },
                new Filter
                {
                   Header = "Brand",
                   Items = new[] {
                       new FilterItem {
                           Name = "Polaroid",
                           Value = "Polaroid"
                       },
                       new FilterItem {
                           Name = "Bugatti",
                           Value = "Bugatti"
                       }
                   }
                }
            };
        }
    }
}
