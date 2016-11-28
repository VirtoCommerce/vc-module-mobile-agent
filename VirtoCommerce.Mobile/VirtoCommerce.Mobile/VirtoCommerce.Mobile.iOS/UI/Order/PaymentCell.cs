using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using VirtoCommerce.Mobile.ViewModels;
using VirtoCommerce.Mobile.iOS.Controls;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.iOS.UI.Order
{
    public class PaymentCell: UITableViewCell
    {

        public const string CellId = "PaymentMethod";
        public const float CellHeight = 40;
        private const int _padding = 10;
        private SelectViewModel<PaymentMethod> viewModel;
        public PaymentCell()
        {
            InitView();
        }
        public PaymentCell(IntPtr handle) : base(handle)
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
                Font = UIFont.FromName(Consts.FontNameRegular, 25)
            };
            Add(_name);
            _selectButton = new UISimpleRadioButtonControl();
            Add(_selectButton);
        }
        private void SelectChange()
        {
            _selectButton.Checked = viewModel.IsSelect;
        }
        public void UpdateCell(SelectViewModel<PaymentMethod> info)
        {
            viewModel = info;
            if(!string.IsNullOrEmpty( info.Method.Icon))
            _icon.Image = UIImage.FromFile(info.Method.Icon);
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