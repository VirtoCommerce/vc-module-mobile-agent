using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtoCommerce.Mobile.SyncModule.Web.Models
{
    public class SyncOrdersRequest
    {
        public ICollection<Order> Orders { set; get; }
        public string UserLogin { set; get; }
    }
}