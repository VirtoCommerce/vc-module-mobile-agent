using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

namespace VirtoCommerce.Mobile.iOS.UI
{
    public struct Consts
    {
        public const int Padding = 10;
        #region Fonts
        public const string FontNameRegular = "Helvetica Neue";
        public const string FontNameBold = "Helvetica Bold";
        #endregion
        #region Button
        public const int ButtonHeight = 50;
        public static UIColor ButtonBgColor = UIColor.FromRGB(4, 86, 151);
        public const int ButtonCornerRadius = 10;
        public const int ButtonFontSize = 17;
        public static UIColor ButtonTextColor = UIColor.White;
        public const int ButtonIconSize = 40;
        #endregion
        #region Colors
        public static UIColor ColorRed = UIColor.FromRGB(255, 59, 48);
        public static UIColor ColorBlack = UIColor.FromRGB(105, 105, 105);
        public static UIColor ColorGray = UIColor.FromRGB(170, 170, 170);
        #endregion
    }
}