using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Catalog.Model;
using VirtoCommerce.Platform.Core.Security;

namespace VirtoCommerce.Mobile.SyncModule.Data.Models
{
    public class MobileSetting
    {
        public string Id { set; get; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string ProductsCategoryId { set; get; }
        public string AccountId { set; get; }
        public string UserName { set; get; }
        public string MainColor { set; get; }

    }
}
