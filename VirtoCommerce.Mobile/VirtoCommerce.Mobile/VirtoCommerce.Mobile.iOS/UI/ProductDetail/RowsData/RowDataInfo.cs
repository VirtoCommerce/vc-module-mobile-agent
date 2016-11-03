using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace VirtoCommerce.Mobile.iOS.UI.ProductDetail.RowsData
{
    public class RowDataInfo : RowInfo
    {
        public string LeftContent { set; get; }
        public string RightContent { set; get; }
        public UIColor LeftColor { set; get;}
        public UIColor RightColor { set; get; }
        public RowDataInfo(string leftContent, string rightContent, UIColor leftColor, UIColor rightColor, int fontSize, string cellId) : base(cellId)
        {
            LeftColor = leftColor;
            RightColor = rightColor;
            LeftContent = LeftContent;
            RightContent = RightContent;
            FontSize = fontSize;
        }
    }
}