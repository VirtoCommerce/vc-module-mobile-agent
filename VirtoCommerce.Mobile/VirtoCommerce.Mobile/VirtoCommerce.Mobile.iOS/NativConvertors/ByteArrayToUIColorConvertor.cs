using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace VirtoCommerce.Mobile.iOS.NativConvertors
{
    public static class ByteArrayToUIColorConvertor
    {
        public static UIColor ToUIColor(this byte[] array)
        {
            if (array.Length < 3)
            {
                return null;
            }
            if (array.Length == 3)
            {
                return UIColor.FromRGB(array[0], array[1], array[2]);
            }
            return UIColor.FromRGBA(array[0], array[1], array[2], array[3]);
        }
    }

}