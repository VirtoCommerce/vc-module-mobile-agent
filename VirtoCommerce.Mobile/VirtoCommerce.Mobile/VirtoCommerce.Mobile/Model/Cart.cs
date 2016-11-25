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

        public decimal Taxes { set; get; }

        public decimal Shipment { set; get; }

        public decimal Discount { set; get; }

        public Currency Currency { set; get; }

        public string FormattedTotal
        {
            get { return string.Format("{0}{1:#0.00}", Currency?.Symbol, Total); }
        }

        public string FormattedSubTotal
        {
            get { return string.Format("{0}{1:#0.00}", Currency?.Symbol, SubTotal); }
        }

        public string FormattedTaxes
        {
            get { return string.Format("{0}{1:#0.00}", Currency?.Symbol, Taxes); }
        }
        public string FormattedShipment
        {
            get { return string.Format("{0}{1:#0.00}", Currency?.Symbol, Shipment); }
        }
        public string FormattedDiscount
        {
            get { return string.Format("{0}{1:#0.00}", Currency?.Symbol, Discount); }
        }
    }
}
