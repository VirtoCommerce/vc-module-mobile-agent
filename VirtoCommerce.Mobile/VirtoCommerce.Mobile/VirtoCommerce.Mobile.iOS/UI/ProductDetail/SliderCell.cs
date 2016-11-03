using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace VirtoCommerce.Mobile.iOS.UI.ProductDetail
{
    public class SliderCell:UITableViewCell
    {
        private ImageSlider _slider;
        public static NSString CellId = new NSString("SliderCell");
        public SliderCell(IntPtr ptr) : base(ptr)
        {
            ContentView.BackgroundColor = UIColor.White;
        }
        public SliderCell():base(UITableViewCellStyle.Default, CellId)
        {
            ContentView.BackgroundColor = UIColor.White;
        }

        public void UpdateCell(List<UIImage> images)
        {
            if (_slider != null)
                _slider.RemoveFromSuperview();
            _slider = new ImageSlider();
            foreach (var img in images)
            {
                _slider.AddImage(img);
            }
            Add(_slider);
            LayoutSubviews();
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            var f = _slider.Frame;
            f.Width = ContentView.Bounds.Width;
            f.Height = ContentView.Bounds.Height;
            _slider.Frame = f;
            _slider.Draw(f);
        }

    }
}