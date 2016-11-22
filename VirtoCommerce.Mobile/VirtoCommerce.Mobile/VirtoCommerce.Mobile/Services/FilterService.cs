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
                   Header = "FRAME SIZE",
                   PropertyId = "9656a753-e368-463c-875a-60e2fd536338",
                   Items = new[] {
                       new FilterItem {
                           Name = "Medium",
                           Value = "Medium"
                       },
                       new FilterItem {
                           Name = "Large",
                           Value = "Large"
                       }
                   }
                },
                new Filter
                {
                   Header = "MATERIAL",
                   PropertyId = "163b644e-2ef8-4e80-a8db-df80c858e7b7",
                   Items = new[] {
                       new FilterItem {
                           Name = "Acetate",
                           Value = "Acetate"
                       },
                       new FilterItem {
                           Name = "Metal",
                           Value = "Metal"
                       },
                       new FilterItem {
                           Name = "Plastic",
                           Value = "Plastic"
                       }
                   } 
                },
                new Filter {
                    Header ="WEIGHT",
                    PropertyId = "eb9e5201-6f9a-4749-b4f5-45b867a056a4",
                    Items = new [] {
                        new FilterItem {
                            Name = "16g",
                            Value ="16g"
                        },
                        new FilterItem {
                            Name = "17g",
                            Value ="17g"
                        },
                        new FilterItem {
                            Name = "9g - Lightweight",
                            Value ="9g - Lightweight"
                        },
                        new FilterItem {
                            Name = "10g - Lightweight",
                            Value ="10g - Lightweight"
                        },
                        new FilterItem {
                            Name = "20g",
                            Value ="20g"
                        }
                    }
                }
            };
        }
    }
}
