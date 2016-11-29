using System;
using System.Collections.Generic;

using Foundation;
using UIKit;

namespace VirtoCommerce.Mobile.iOS.UI.ProductDetail
{
    public class PropertiesSource : UITableViewSource
    {
        public List<KeyValuePair<string, string>> CellsData { set; get; }
        public PropertiesSource(List<KeyValuePair<string, string>> cells)
        {
            CellsData = cells;
        }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.RegisterClassForCellReuse(typeof(PropertyCell), PropertyCell.CellId);
            var cell = tableView.DequeueReusableCell(PropertyCell.CellId) as PropertyCell;
            var cellData = CellsData[indexPath.Row];
            cell.UpdateCell(cellData);
            cell.SelectionStyle = UITableViewCellSelectionStyle.None;
            cell.BackgroundColor = Consts.ColorMainBg;
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return CellsData.Count;
        }
    }
}