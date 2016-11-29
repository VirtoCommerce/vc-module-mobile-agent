using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace VirtoCommerce.Mobile.iOS.UI.ProductDetail
{
    public class PropertyCell : UITableViewCell
    {
        private const int _padding = 10;
        public const int CellHeight = 30;
        public const string CellId = "ProperyCell";
        public PropertyCell(IntPtr handle) : base(handle)
        {
            InitView();
        }

        public void UpdateCell(KeyValuePair<string, string> value)
        {
            var words = value.Key.Split(' ');
            var header = new StringBuilder();
            foreach (var word in words)
            {
                header.Append(char.ToUpper(word[0]) + word.Substring(1).ToLower() + " ");
            }
            _valueLabel.Text = value.Value;
            _headerLabel.Text = header.ToString();
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
