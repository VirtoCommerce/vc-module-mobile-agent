using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Model
{
    public class Price
    {
        public decimal Sale { set; get; }
        public decimal? List { set; get; }
        public string CurrencyCode { set; get; }
        public string CurrencySymbol { set; get; }

        public string FormattedSalePrice
        {
            get
            {
                if (Sale == 0)
                {
                    return string.Empty;
                }
                return string.Format("{0}{1:#0}", CurrencySymbol, Sale);
            }
        }
        public string FormattedListPrice
        {
            get
            { 
                if ((List ?? 0) == 0 || List == Sale)
                {
                    return string.Empty;
                }
                return string.Format("{0}{1:#0}", CurrencySymbol, List);
            }
        }
    }
}
