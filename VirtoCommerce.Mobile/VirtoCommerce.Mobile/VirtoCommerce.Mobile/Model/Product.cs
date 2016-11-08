using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Model
{
    public class Product
    {
        public Product()
        {
            Properties = new ProductProperty[0];
        }
        public string Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public ICollection<string> Images { set; get; }
        public string TitleImage { set; get; }
        public Price Price { set; get; }
        public string Manufacture { set; get; }
        public ICollection<ProductProperty> Properties { set; get; }
    }
}
