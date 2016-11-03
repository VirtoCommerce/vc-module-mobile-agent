using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace VirtoCommerce.Mobile.iOS.UI.ProductDetail.RowsData
{
    public class RowInfo
    {
        public string CellId { set; get; }
        public nfloat Height { set; get; }
        public RowInfo(string cellId)
        {
            CellId = cellId;
        }
        public string Text { set; get; }
        public UIColor TextColor { set; get; }
        public int FontSize { set; get; }
    }
}