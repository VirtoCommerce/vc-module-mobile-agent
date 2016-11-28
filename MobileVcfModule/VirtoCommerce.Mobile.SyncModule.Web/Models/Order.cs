using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtoCommerce.Mobile.SyncModule.Web.Models
{
    public class Order
    {
        public Order()
        {
            Items = new List<OrderItem>();
        }
        public string Id { set; get; }
        public string PaymentId { set; get; }
        public string ShipmentId { set; get; }
        public double Total { set; get; }
        public double Taxes { set; get; }
        public double Shipment { set; get; }
        public double SubTotal { set; get; }
        public double Discount { set; get; }
        public ICollection<OrderItem> Items { set; get; }
        public Customer Customer { set; get; }
        public bool IsSync { set; get; }
    }
}