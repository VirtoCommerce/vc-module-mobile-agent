using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using VirtoCommerce.Mobile.Model;
using CoreGraphics;

namespace VirtoCommerce.Mobile.iOS.UI.Order
{
    public class CustomerInfoSource : UITableViewSource
    {
        private List<ICollection<KeyValuePair<string, Customer>>> _values;
        public CustomerInfoSource(UITableView tableView, List<ICollection<KeyValuePair<string, Customer>>> values)
        {
            tableView.RegisterClassForCellReuse(typeof(CustomerInfoCell), CustomerInfoCell.CellId);
            _values = values;
        }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var index = 0;
            if (indexPath.Section != 0)
            {
                index = indexPath.Row + 1;
            }
            var cell = tableView.DequeueReusableCell(CustomerInfoCell.CellId) as CustomerInfoCell;
            cell.UpdateCell(_values[index]);
            cell.SelectionStyle = UITableViewCellSelectionStyle.None;
            cell.BackgroundColor = Consts.ColorMainBg;
            return cell;
        }

        public override UIView GetViewForHeader(UITableView tableView, nint section)
        {
            var headerView = new UIView(new CGRect(0, 0, tableView.Frame.Width, 20));
            var label = new UILabel
            {
                Font = UIFont.FromName(Consts.FontNameRegular, 20),
                TextColor = Consts.ColorDark,
                TextAlignment = UITextAlignment.Center,
                Text = TitleForHeader(tableView, section).ToUpper()
            };
            label.SizeToFit();
            var border = new UIView(new CGRect((tableView.Frame.Width - label.Frame.Width) / 2, label.Frame.Height + Consts.Padding, label.Frame.Width, 2))
            {
                BackgroundColor = Consts.ColorDivider
            };
            var labelFrame = label.Frame;
            labelFrame.Width = tableView.Frame.Width;
            label.Frame = labelFrame;
            headerView.AddSubviews(label, border);
            return headerView;
        }

        public override string TitleForHeader(UITableView tableView, nint section)
        {
            switch (section)
            {
                case 0:
                    return "Customer information";

                case 1:
                    return "Shipping address";
            }
            return "";
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 2;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            switch (section)
            {
                case 0:
                    return 1;
                case 1:
                    return _values.Count - 1;
            }
            return 0;
        }
    }
}