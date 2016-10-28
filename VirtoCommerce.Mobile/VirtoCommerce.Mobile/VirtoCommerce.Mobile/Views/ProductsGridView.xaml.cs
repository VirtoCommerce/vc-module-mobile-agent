using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace VirtoCommerce.Mobile.Views
{
    public partial class ProductsGridView : ContentPage
    {
        public ProductsGridView(ViewModels.ProductsGridViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
