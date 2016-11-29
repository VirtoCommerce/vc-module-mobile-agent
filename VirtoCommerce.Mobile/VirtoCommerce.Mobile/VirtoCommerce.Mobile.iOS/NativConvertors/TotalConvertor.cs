using MvvmCross.Platform.Converters;
using System;
using System.Globalization;

namespace VirtoCommerce.Mobile.iOS.NativConvertors
{
    public class TotalConvertor : IMvxValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"Total: {value}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}