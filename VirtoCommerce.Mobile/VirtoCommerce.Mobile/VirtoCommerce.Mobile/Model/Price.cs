namespace VirtoCommerce.Mobile.Model
{
    public class Price
    {
        public decimal Sale { set; get; }
        public decimal? List { set; get; }
        public Currency Currency { set; get; }

        public string FormattedSalePriceFull
        {
            get
            {
                if (Sale == 0)
                {
                    return string.Empty;
                }
                return string.Format("{0}{1:#0.00}", Currency.Symbol, Sale);
            }
        }
        public string FormattedListPriceFull
        {
            get
            {
                if ((List ?? 0) == 0)
                {
                    return string.Empty;
                }
                return string.Format("{0}{1:#0.00}", Currency.Symbol, List);
            }
        }

        public string FormattedSalePrice
        {
            get
            {
                if (Sale == 0)
                {
                    return string.Empty;
                }
                return string.Format("{0}{1:#0}", Currency.Symbol, (int)Sale);
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
                return string.Format("{0}{1:#0}", Currency.Symbol, (int)List);
            }
        }
    }
}
