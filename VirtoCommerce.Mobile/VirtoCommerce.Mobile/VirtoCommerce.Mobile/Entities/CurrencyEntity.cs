using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Mobile.Entities
{
    public class CurrencyEntity:BaseEntity
    {
        /// <summary>
        /// the currency code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        ///  name of the currency
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The exchange rate against the primary exchange rate of the currency.
        /// </summary>
        public decimal ExchangeRate { get; set; }
        /// <summary>
        /// Currency symbol
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Custom formatting pattern
        /// </summary>
        public string CustomFormatting { get; set; }
    }
}
