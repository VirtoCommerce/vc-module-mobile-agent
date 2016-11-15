using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Entities
{
    public class ReviewEntity:BaseEntity
    {
        public string Content { set; get; }
        public string ReviewType { set; get; }
        public string LanguageCode { set; get; }
    }
}
