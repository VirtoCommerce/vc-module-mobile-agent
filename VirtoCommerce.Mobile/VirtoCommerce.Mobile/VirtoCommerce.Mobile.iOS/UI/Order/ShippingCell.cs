using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using VirtoCommerce.Mobile.Model;
using VirtoCommerce.Mobile.ViewModels;
using VirtoCommerce.Mobile.iOS.Controls;

namespace VirtoCommerce.Mobile.iOS.UI.Order
{
    public class ShippingCell:UITableViewCell
    {

        public const string CellId = "ShippingCell";
        public const float CellHeight = 40;
        private const int _padding = 10;
        private SelectViewModel<ShippingMethodRate> viewModel;
        public ShippingCell()
        {
            InitView();
        }
        public ShippingCell(IntPtr handle) : base(handle)
        {
            InitView();
        }
        private void InitView()
        {
            _icon = new UIImageView();
            Add(_icon);
            _name = new UILabel()
            {
                TextColor = Consts.ColorBlack,
                Font = UIFont.FromName(Consts.FontNameRegular, 18)
            };
            Add(_name);
            _selectButton = new UISimpleRadioButtonControl();
            Add(_selectButton);
        }
        private void SelectChange()
        {
            _selectButton.Checked = viewModel.IsSelect;
        }
        public void UpdateCell(SelectViewModel<ShippingMethodRate> info)
        {
            viewModel = info;
            _name.Text = info.Method.Name;
            _selectButton.Checked = info.IsSelect;
            viewModel.NotificationSelectChange = SelectChange;
        }

        public override void LayoutSubviews()
        {
            //icon frame
            base.LayoutSubviews();
            var iconFrame = _icon.Frame;
            if (_icon.Image != null)
                iconFrame.Width = 50;
            iconFrame.Height = 50;
            _icon.Frame = iconFrame;
            //button
            var buttonFrame = _selectButton.Frame;
            buttonFrame.Width = 25;
            buttonFrame.Height = 25;
            buttonFrame.X = _icon.Frame.Width + _icon.Frame.X + _padding;
            buttonFrame.Y = CellHeight / 2 - buttonFrame.Height / 2;
            _selectButton.Frame = buttonFrame;
            //title
            _name.SizeToFit();
            var nameFrame = _name.Frame;
            nameFrame.X = buttonFrame.Width + buttonFrame.X + _padding;
            nameFrame.Y = ContentView.Frame.Height / 2 - nameFrame.Height / 2;
            if (nameFrame.Width + nameFrame.X > ContentView.Frame.Width)
            {
                nameFrame.Width = ContentView.Frame.Width - nameFrame.X - _padding;
            }
            _name.Frame = nameFrame;
        }

        #region View
        private UIImageView _icon;
        private UILabel _name;
        private UISimpleRadioButtonControl _selectButton;
        #endregion
    }
}