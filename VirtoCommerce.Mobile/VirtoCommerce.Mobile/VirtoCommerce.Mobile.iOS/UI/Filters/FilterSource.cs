using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using VirtoCommerce.Mobile.ViewModels;
using CoreGraphics;

namespace VirtoCommerce.Mobile.iOS.UI.Filters
{
    public class FilterSource : UITableViewSource
    {
        public Dictionary<string, List<FilterItemViewModel>> Data { set; get; }

        public FilterSource(Dictionary<string, List<FilterItemViewModel>> data)
        {
            Data = data;
        }

        public override string TitleForHeader(UITableView tableView, nint section)
        {
            return Data.Keys.ElementAt((int)section);
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(FilterCell.CellId) as FilterCell;
            if (cell == null)
            {
                cell = new FilterCell();
            }
            cell.UpdateCell(Data[Data.Keys.ElementAt(indexPath.Section)].ElementAt(indexPath.Row));
            cell.SelectionStyle = UITableViewCellSelectionStyle.None;
            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.CellAt(indexPath) as FilterCell;
            if (cell != null)
            {
                var data = Data[Data.Keys.ElementAt(indexPath.Section)].ElementAt(indexPath.Row);
                data.IsSelect = !data.IsSelect;
                cell.UpdateCell(data);
            }
        }

        public override UIView GetViewForHeader(UITableView tableView, nint section)
        {
            var headerView = new UIView(new CGRect(0, 0, tableView.Frame.Width, 20));
            var label = new UILabel
            {
                Font = UIFont.FromName(Consts.FontNameRegular, 20),
                TextColor = Consts.ColorDark,
                TextAlignment = UITextAlignment.Center,
                Text = Data.Keys.ElementAt((int)section)
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

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return Data[Data.Keys.ElementAt((int)section)].Count;
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return Data.Keys.Count;
        }

    }
}