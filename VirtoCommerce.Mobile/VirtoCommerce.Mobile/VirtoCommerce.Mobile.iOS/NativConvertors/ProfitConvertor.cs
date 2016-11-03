using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
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
                return "0";
            return $"-{vl.CurrencySymbol}{Math.Abs(vl.Sale - vl.List ??0)}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}