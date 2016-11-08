using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Themes;

namespace VirtoCommerce.Mobile.iOS.UI.ProductDetail
{
    public class PropertiesSource : UITableViewSource
    {
        public static NSString CellId = new NSString("TableCell");
        public List<KeyValuePair<string, string>> CellsData { set; get; }
        public PropertiesSource(List<KeyValuePair<string, string>> cells)
        {
            CellsData = cells;
        }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellId);

            var cellData = CellsData[indexPath.Row];
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Value2, CellId);
            }
            //
            cell.TextLabel.TextAlignment = UITextAlignment.Left;
            cell.TextLabel.Text = cellData.Key+":";
            cell.TextLabel.Lines = 0;
            cell.TextLabel.LineBreakMode = UILineBreakMode.WordWrap;
            cell.TextLabel.SizeToFit();
            //
            cell.DetailTextLabel.Text = cellData.Value;
            cell.DetailTextLabel.Lines = 0;
            cell.DetailTextLabel.LineBreakMode = UILineBreakMode.WordWrap;
            cell.DetailTextLabel.SizeToFit();
            //
            cell.SelectionStyle = UITableViewCellSelectionStyle.None;
            cell.BackgroundColor = UIColor.FromPatternImage(GridlockTheme.SharedTheme.ViewBackground); 
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return CellsData.Count;
        }
    }
}