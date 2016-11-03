using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace VirtoCommerce.Mobile.iOS.UI.ProductDetail.RowsData
{
    public class RowDataSlider : RowInfo
    {
        public List<UIImage> Images { set; get; }
        public RowDataSlider(List<UIImage> images, string cellId) : base(cellId)
        {
            Images = images;
        }
    }
}