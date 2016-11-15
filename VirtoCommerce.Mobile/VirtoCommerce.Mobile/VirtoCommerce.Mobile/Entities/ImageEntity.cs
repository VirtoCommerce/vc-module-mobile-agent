using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Entities
{
    public class ImageEntity : BaseEntity
    {
        public string PhysicalPath { set; get; }
        public string ProductId { set; get; }
    }
}
