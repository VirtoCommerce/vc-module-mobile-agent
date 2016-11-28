using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace VirtoCommerce.Mobile.iOS.UI.Cart
{
    public class TotalCell : UITableViewCell
    {
        private const int _padding = 30;
        public const int CellHeight = 30;
        public const string CellId = "TotalCell";
        public TotalCell(IntPtr handle) : base(handle)
        {
            InitView();
        }

        public void UpdateCell(TotalRowData rowData)
        {
            _headerLabel.Text = rowData.Header;
            _headerLabel.TextColor = rowData.TextColor;
            _headerLabel.Font = rowData.TextFont;
            _valueLabel.Text = rowData.Value;
            _valueLabel.TextColor = rowData.TextColor;
            _valueLabel.Font = rowData.TextFont;
        }

        #region View

        private UILabel _headerLabel;
        private UILabel _valueLabel;

        private void InitView()
        {
            _headerLabel = new UILabel
            {
                TextColor = Consts.ColorDarkLight,
                Font = UIFont.FromName(Consts.FontNameRegular, 14),
                TextAlignment = UITextAlignment.Right
            };
            _valueLabel = new UILabel
            {
                TextColor = Consts.ColorDark,
                Font = UIFont.FromName(Consts.FontNameRegular, 14),
                TextAlignment = UITextAlignment.Left,
            };
            AddSubviews(_headerLabel, _valueLabel);
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            var headerFrame = _headerLabel.Frame;
            headerFrame.Width = Frame.Width / 2 - _padding / 2;
            headerFrame.Height = CellHeight;
            _headerLabel.Frame = headerFrame;
            var valueFrame = _valueLabel.Frame;
            valueFrame.Width = Frame.Width / 2 - _padding / 2;
            valueFrame.X = headerFrame.Width + _padding;
            valueFrame.Height = CellHeight;
            _valueLabel.Frame = valueFrame;
        }
        #endregion
    }
}