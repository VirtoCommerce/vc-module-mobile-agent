using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using VirtoCommerce.Mobile.iOS.UI.ProductDetail.RowsData;

namespace VirtoCommerce.Mobile.iOS.UI.ProductDetail
{
    public class InfoCell : UITableViewCell
    {
        private const string _fontName = "Helvetica Neue";
        private UILabel _leftLabel;
        private UILabel _rightLabel;
        public static NSString CellId = new NSString("InfoCell");
        private void InitControls()
        {
            _leftLabel = new UILabel();
            _rightLabel = new UILabel();
            AddSubviews(_leftLabel, _rightLabel);
            ContentView.BackgroundColor = UIColor.Red;
        }
        public InfoCell(IntPtr ptr) : base(ptr)
        {
            InitControls();
        }
        public InfoCell()
            : base(UITableViewCellStyle.Default, CellId)
        {
            InitControls();
        }
        public void UpdateCell(RowDataInfo info)
        {
            _rightLabel.Text = info. RightContent;
            _rightLabel.TextColor = info. RightColor;
            _rightLabel.Font = UIFont.FromName(_fontName,info. FontSize);
            _leftLabel.Text = info.LeftContent;
            _leftLabel.TextColor = info.LeftColor;
            _leftLabel.Font = UIFont.FromName(_fontName, info.FontSize);
            LayoutSubviews();
        }
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            _leftLabel.SizeToFit();
            _rightLabel.SizeToFit();
            var leftFrame = _leftLabel.Frame;
            var rightFrame = _rightLabel.Frame;
            var contentFrame = ContentView.Frame;
            rightFrame.X = contentFrame.Width - rightFrame.Width;
            _rightLabel.Frame = rightFrame;
        }
    }
}