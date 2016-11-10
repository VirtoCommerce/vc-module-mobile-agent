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
        public static NSString CellId = new NSString("TableCell");
        public List<TotalRowData> Data { set; get; }
        public TotalSource(List<TotalRowData> data)
        {
            Data = data;
        }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellId);

            var cellData = Data[indexPath.Row];
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Value2, CellId);
            }
            //
            cell.TextLabel.TextAlignment = UITextAlignment.Left;
            cell.TextLabel.Text = cellData.Header;
            cell.TextLabel.Lines = 0;
            cell.TextLabel.LineBreakMode = UILineBreakMode.WordWrap;
            cell.TextLabel.Font = cellData.TextFont;
            cell.TextLabel.TextColor = cellData.TextColor;
            //cell.TextLabel.SizeToFit();
            //
            cell.DetailTextLabel.Text = cellData.Value;
            cell.DetailTextLabel.TextAlignment = UITextAlignment.Right;
            cell.DetailTextLabel.Lines = 0;
            cell.DetailTextLabel.LineBreakMode = UILineBreakMode.WordWrap;
            cell.DetailTextLabel.Font = cellData.TextFont;
            cell.DetailTextLabel.TextColor = cellData.TextColor;
            //cell.DetailTextLabel.SizeToFit();
            //
            cell.SelectionStyle = UITableViewCellSelectionStyle.None;
            cell.BackgroundColor = Consts.ColorMainBg;
            if (cellData.Header.Equals("total", StringComparison.InvariantCultureIgnoreCase))
            {
                cell.AddSubview(new UIView(new CGRect(0, 0, cell.Frame.Width, 1))
                {
                    BackgroundColor = cellData.TextColor
                });
            }
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return Data?.Count ?? 0;
        }
    }
}
