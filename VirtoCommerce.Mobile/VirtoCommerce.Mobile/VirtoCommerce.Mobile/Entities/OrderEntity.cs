using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Entities
{
    public class OrderEntity:BaseEntity
    {
        public string PaymentId { set; get; }
        public string ShipmentId { set; get; }
        public double Total { set; get; }
        public double Taxes { set; get; }
        public double Shipment { set; get; }
        public double SubTotal { set; get; }
        public double Discount { set; get; }
        public bool IsSync { set; get; }
    }
}
