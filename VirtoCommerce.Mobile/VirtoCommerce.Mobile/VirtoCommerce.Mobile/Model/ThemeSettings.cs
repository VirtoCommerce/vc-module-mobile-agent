using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Model
{
    public class ThemeSettings
    {
        public ThemeSettings()
        {
            MainColor = new byte[4];
        }
        string Id { set; get; }
        public byte[] MainColor { set; get; }
    }
}
