using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtoCommerce.Domain.Store.Model;

namespace VirtoCommerce.Mobile.SyncModule.Web.Models
{
    public class MobileSetting
    {
        public string Id { set; get; }
        public string AccountName { set; get; }
        public string AccountId { set; get; }
        public string CreatedBy { set; get; }
        public DateTime CreatedDate { set; get; }
        public Store SelectStore { set; get; }
        public string MainColor { set; get; }
    }
}