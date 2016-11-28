using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtoCommerce.Mobile.SyncModule.Web.Models
{
    public class OrderItem
    {
        public string Id { set; get; }
        public string OrderId { set; get; }
        public string ProductId { set; get; }
        public int Quantity { set; get; }
        public string Currency { set; get; }
        public decimal SubTotal { set; get; }
        public decimal Discount { get; set; }
    }
}