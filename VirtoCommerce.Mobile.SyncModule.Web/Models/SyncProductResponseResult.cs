using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtoCommerce.CatalogModule.Web.Model;

namespace VirtoCommerce.Mobile.SyncModule.Web.Models
{
    public class SyncProductResponseResult
    {
        public ICollection<Product> Products { set; get; }
        public ICollection<ProductPrice> Prices { set; get; }
    }
}