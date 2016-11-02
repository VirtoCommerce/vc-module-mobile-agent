using MvvmCross.iOS.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace VirtoCommerce.Mobile.iOS.Views
{
    class CartView : MvxViewController
    {
        public CartView() : base(null, null)
        {
            Title = "Cart";
        }
    }
}
