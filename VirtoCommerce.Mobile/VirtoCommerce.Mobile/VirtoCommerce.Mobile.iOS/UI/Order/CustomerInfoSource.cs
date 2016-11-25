using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.iOS.UI.Order
{
    public class CustomerInfoSource : UITableViewSource
    {
        private List<KeyValuePair<string, Customer>> _values;
        public CustomerInfoSource(UITableView tableView, List<KeyValuePair<string, Customer>> values)
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
            cell.UpdateCell(_values[index].Key, _values[index].Value);
            cell.SelectionStyle = UITableViewCellSelectionStyle.None;
            cell.BackgroundColor = Consts.ColorMainBg;
            return cell;
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