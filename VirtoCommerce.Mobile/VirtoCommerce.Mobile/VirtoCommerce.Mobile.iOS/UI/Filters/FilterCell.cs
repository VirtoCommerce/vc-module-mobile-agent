using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using VirtoCommerce.Mobile.ViewModels;
using VirtoCommerce.Mobile.iOS.Controls;

namespace VirtoCommerce.Mobile.iOS.UI.Filters
{
    public class FilterCell:UITableViewCell
    {
        public const string CellId = "Filter";
        public const float CellHeight = 40;
        private const int _padding = 10;
        private FilterItemViewModel viewModel;
        public FilterCell()
        {
            InitView();
        }
        public FilterCell(IntPtr handle) : base(handle)
        {
            InitView();
        }
        private void InitView()
        {
            _selectButton = new UISimpleCheckBoxControl();
            Add(_selectButton);
            _name = new UILabel()
            {
                TextColor = Consts.ColorBlack,
                Font = UIFont.FromName(Consts.FontNameRegular, 14)
            };
            Add(_name);
            
        }
        private void SelectChange()
        {
            _selectButton.Checked = viewModel.IsSelect;
        }
        public void UpdateCell(FilterItemViewModel info)
        {
            viewModel = info;
            _name.Text = info.FilterItem.Name;
            _selectButton.Checked = info.IsSelect;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            //button
            var buttonFrame = _selectButton.Frame;
            buttonFrame.Width = 25;
            buttonFrame.Height = 25;
            buttonFrame.X = _padding;
            buttonFrame.Y = CellHeight / 2 - buttonFrame.Height / 2;
            _selectButton.Frame = buttonFrame;
            //title
            _name.SizeToFit();
            var nameFrame = _name.Frame;
            nameFrame.X = buttonFrame.Width + _padding+ buttonFrame.X;
            nameFrame.Y = CellHeight / 2 - nameFrame.Height / 2;
            nameFrame.Width = ContentView.Frame.Width - buttonFrame.Width - _padding * 2;
            _name.Frame = nameFrame;
        }

        #region View
        private UILabel _name;
        private UISimpleCheckBoxControl _selectButton;
        #endregion
    }


}