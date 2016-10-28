using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VirtoCommerce.Mobile.Views
{
    public class RootView : NavigationPage
    {
        public RootView(ProductsGridView productsGridView):base(productsGridView)
        {
            Title = "Main";
        }

    }
}
