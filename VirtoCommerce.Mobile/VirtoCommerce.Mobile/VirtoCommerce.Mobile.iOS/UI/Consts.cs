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
        public const float FontSizeRegular = 17; 
        #endregion

        #region Button
        public const int ButtonHeight = 50;
        
        public const int ButtonCornerRadius = 0;
        public const int ButtonFontSize = 17;
        public static UIColor ButtonTextColor = UIColor.White;
        public const int ButtonIconSize = 40;
        #endregion

        #region Colors
        public static UIColor ColorMainBg = UIColor.FromRGB(255, 255, 255);//UIColor.FromRGB(245,245,245);
        public static UIColor ColorMain = UIColor.FromRGBA(0, 0, 0, 200);//UIColor.FromRGBA(4, 86, 151);
        public static UIColor ColorRed = UIColor.FromRGB(255, 59, 48);
        public static UIColor ColorBlack = UIColor.FromRGBA(0, 0, 0, 200);
        public static UIColor ColorGray = UIColor.FromRGB(170, 170, 170);
        public static UIColor ColorGrayLight = UIColor.FromRGB(245, 245, 245);
        public static UIColor ColorDark = UIColor.FromRGB(33, 29, 30);
        public static UIColor ColorDarkLight = UIColor.FromRGB(75, 72, 73);
        #endregion
    }
}