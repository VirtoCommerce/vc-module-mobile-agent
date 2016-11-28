using CoreAnimation;
using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace VirtoCommerce.Mobile.iOS.UI.Cart
{
   public  class TotalSource : UITableViewSource
    {
        public List<TotalRowData> Data { set; get; }
        public TotalSource(List<TotalRowData> data)
        {
            Data = data;
        }

        public override string TitleForHeader(UITableView tableView, nint section)
        {
            return "SUMMARY";
        }

        public override UIView GetViewForHeader(UITableView tableView, nint section)
        {
            var headerView = new UIView(new CGRect(0, 0, tableView.Frame.Width, 20))
            {
                BackgroundColor = Consts.ColorTransparent
            };
            var label = new UILabel
            {
                Font = UIFont.FromName(Consts.FontNameRegular, 20),
                TextColor = Consts.ColorDark,
                TextAlignment = UITextAlignment.Center,
                Text = "SUMMARY"
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

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.RegisterClassForCellReuse(typeof(TotalCell), TotalCell.CellId);
            var cell = tableView.DequeueReusableCell(TotalCell.CellId) as TotalCell;

            var cellData = Data[indexPath.Row];
            cell.UpdateCell(cellData);
            //
            cell.SelectionStyle = UITableViewCellSelectionStyle.None;
            cell.BackgroundColor = Consts.ColorTransparent;
            return cell;
        }
        

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return Data?.Count ?? 0;
        }
    }
}
