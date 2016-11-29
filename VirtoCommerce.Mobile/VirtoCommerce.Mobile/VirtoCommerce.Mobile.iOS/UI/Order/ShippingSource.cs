using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using VirtoCommerce.Mobile.ViewModels;
using VirtoCommerce.Mobile.Model;
using CoreGraphics;

namespace VirtoCommerce.Mobile.iOS.UI.Order
{
    public class ShippingSource : UITableViewSource
    {
        private Dictionary<string, ICollection<SelectViewModel<ShippingMethodRate>>> _sections = new Dictionary<string, ICollection<SelectViewModel<ShippingMethodRate>>>();
        private Action<ShippingMethodRate> _updateShipping;
        public ShippingSource(UITableView tableView, ICollection<SelectViewModel<ShippingMethodRate>> methods, Action<ShippingMethodRate> updateShipping)
        {
            _updateShipping = updateShipping;
            tableView.RegisterClassForCellReuse(typeof(ShippingCell), ShippingCell.CellId);
            var groups = methods.GroupBy(x => x.Method.ShippingMethod);
            foreach (var gr in groups)
            {
                _sections.Add(gr.Key.Name, gr.Select(x => x).ToArray());
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
                Text = _sections.Keys.ElementAt((int)section).ToUpper()
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
            return _sections.Keys.ElementAt((int)section);
        }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(ShippingCell.CellId) as ShippingCell;
            var dataCell = _sections[_sections.Keys.ElementAt(indexPath.Section)].ElementAt(indexPath.Row);
            cell.UpdateCell(dataCell);
            cell.SelectionStyle = UITableViewCellSelectionStyle.None;
            cell.BackgroundColor = Consts.ColorMainBg;
            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var keys = _sections.Keys;
            for (int i = 0; i < keys.Count; i++)
            {
                for (int j = 0; j < _sections[keys.ElementAt(i)].Count; j++)
                {
                    if (indexPath.Section == i && indexPath.Row == j)
                    {
                        var rate = _sections[keys.ElementAt(i)].ElementAt(j);
                        rate.IsSelect = true;
                        _updateShipping?.Invoke(rate.Method);
                    }
                    else
                    {
                        _sections[keys.ElementAt(i)].ElementAt(j).IsSelect = false;
                    }
                }
            }
        }
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _sections[_sections.Keys.ElementAt((int)section)].Count;
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return _sections.Count;
        }

    }
}