using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Model
{
    public class Cart
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }
        public List<CartItem> CartItems { set; get; }

        public decimal SubTotal { set; get; }

        public decimal Total { set; get; }

        public Currency Currency { set; get; }

        public string FormattedTotal
        {
            get
            {
                return string.Format("{0} {1:#0.00}", Currency?.CurrencySymbol, Total);
            }
        }

        public string FormattedSubTotal
        {
            get
            {
                return string.Format("{0} {1:#0.00}",Currency?.CurrencySymbol, SubTotal);
            }
        }
    }
}
