using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using UIKit;
using VirtoCommerce.Mobile.ViewModels;
using Xamarin.Themes;
using VirtoCommerce.Mobile.Model;
using CoreGraphics;

namespace VirtoCommerce.Mobile.iOS.UI.Order
{
    public class PaymentSource : UITableViewSource
    {
        private ICollection<SelectViewModel<PaymentMethod>> _methods;
        public PaymentSource(UITableView tableView, ICollection<SelectViewModel<PaymentMethod>> methods)
        {
            tableView.RegisterClassForCellReuse(typeof(PaymentCell), PaymentCell.CellId);
            _methods = methods;
        }
        public override string TitleForHeader(UITableView tableView, nint section)
        {
            return "Payment methods";
        }
        public override UIView GetViewForHeader(UITableView tableView, nint section)
        {
            var headerView = new UIView(new CGRect(0, 0, tableView.Frame.Width, 20));
            var label = new UILabel
            {
                Font = UIFont.FromName(Consts.FontNameRegular, 20),
                TextColor = Consts.ColorDark,
                TextAlignment = UITextAlignment.Center,
                Text = "Payment methods".ToUpper()
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
            var cell = tableView.DequeueReusableCell(PaymentCell.CellId) as PaymentCell;
            cell.UpdateCell(_methods.ElementAt(indexPath.Row));
            cell.SelectionStyle = UITableViewCellSelectionStyle.None;
            cell.BackgroundColor = Consts.ColorMainBg;
            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            for (int i = 0; i < _methods.Count; i++)
            {
                if (i != indexPath.Row)
                {
                    _methods.ElementAt(i).IsSelect = false;
                }
                else
                {
                    _methods.ElementAt(i).IsSelect = true;
                }
            }
        }
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _methods?.Count ?? 0;
        }
    }
}