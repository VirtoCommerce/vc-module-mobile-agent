using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Entities
{
    public class ProductPropertyEntity:BaseEntity
    {
        public string ProductId { set; get; }
        public string PropertyName { get; set; }

        public string PropertyDisplayName { set; get; }

        public string PropertyId { get; set; }

        public string LanguageCode { get; set; }

        public string Alias { get; set; }

        public string ValueType { get; set; }

        public string Value { get; set; }
    }
}
