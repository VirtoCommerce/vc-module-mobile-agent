using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Catalog.Model;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Data.Model;

namespace VirtoCommerce.Mobile.SyncModule.Data.Entities
{
    public class MobileSetting: AuditableEntity
    {
        public string ProductsCategoryId { set; get; }
        public string AccountId { set; get; }
        public string MainColor { set; get; }
    }
}
