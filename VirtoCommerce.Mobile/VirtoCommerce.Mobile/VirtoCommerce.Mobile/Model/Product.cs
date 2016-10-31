using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Model
{
    public class Product
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public ICollection<byte[]> Images { set; get; }
        public byte[] TitleImage { set; get; }
        public Price Price { set; get; }
    }
}
