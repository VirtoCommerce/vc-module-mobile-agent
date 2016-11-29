using System;
using System.Globalization;
using MvvmCross.Platform.Converters;
using Foundation;
using UIKit;

namespace VirtoCommerce.Mobile.iOS.NativConvertors
{
    public class StrikeTextConvertor : IMvxValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            var attrString = new NSMutableAttributedString(value.ToString());
            attrString.AddAttribute(
                UIStringAttributeKey.StrikethroughStyle,
                NSNumber.FromInt32((int)NSUnderlineStyle.Single),
                new NSRange(0, attrString.Length));
            return attrString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}