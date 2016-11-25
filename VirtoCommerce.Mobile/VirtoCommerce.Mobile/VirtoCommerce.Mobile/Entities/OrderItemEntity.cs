using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Entities
{
    public class OrderItemEntity : BaseEntity
    {
        public string OrderId { set; get; }
        public string ProductId { set; get; }
        public int Quantity { set; get; }
        public string Currency { set; get; }
        public decimal SubTotal { set; get; }
        public decimal Discount { get; set; }
    }
}
