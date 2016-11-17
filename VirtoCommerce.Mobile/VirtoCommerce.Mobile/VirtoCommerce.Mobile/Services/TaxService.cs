using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.Services
{
    public class TaxService : ITaxService
    {
        public Tax GetCurrentTax()
        {
            return new Tax
            {
                Name = "Static percent",
                Percent = 10
            };
        }
    }
}
