using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Model;
using Xamarin.Forms;

namespace VirtoCommerce.Mobile.CustomControls
{
    public class ProductsTableView : View
    {
        /// <summary>
        /// Property binding display collection
        /// </summary>
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create("Items",
            returnType: typeof(ICollection<Product>), declaringType: typeof(ProductsTableView),
            defaultValue: new Product[0]);

        public ICollection<Product> Items
        {
            set
            {
                SetValue(ItemsProperty, value);
            }
            get
            {
                return (ICollection<Product>)GetValue(ItemsProperty);
            }
        }
    }
}