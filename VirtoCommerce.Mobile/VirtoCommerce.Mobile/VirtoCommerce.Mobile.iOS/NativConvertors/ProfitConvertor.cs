using System;
using MvvmCross.Platform.Converters;
using System.Globalization;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.iOS.NativConvertors
{
    public class ProfitConvertor : IMvxValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var vl = value as Price;
            if (vl == null || vl.List == null)
                return "";
            var profit = Math.Abs(vl.Sale - vl.List ?? 0);
            if (profit == 0)
                return "";
            return string.Format("Save {0}{1:#0.00}", vl.Currency.Symbol, profit);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}