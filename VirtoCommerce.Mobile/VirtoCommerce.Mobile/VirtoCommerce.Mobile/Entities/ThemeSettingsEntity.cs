using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Entities
{
    public class ThemeSettingsEntity:BaseEntity
    {
        public byte MainColorR { set; get; }
        public byte MainColorG { set; get; }
        public byte MainColorB { set; get; }
        public byte MainColorA { set; get; }
    }
}
