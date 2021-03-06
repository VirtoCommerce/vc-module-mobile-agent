using System;
using System.Linq;

using Foundation;
using UIKit;

namespace VirtoCommerce.Mobile.iOS.UI.Cart
{
    public class CartSource : UITableViewSource
    {
        private bool _isEdit;
        public Model.Cart Cart { set; get; }
        private readonly Action<Model.CartItem> _updateCartItem;
        public CartSource(UITableView tableView, Model.Cart cart, Action<Model.CartItem> updateCartItem, bool isEdit = true)
        {
            _isEdit = isEdit;
            tableView.RegisterClassForCellReuse(typeof(CartCell), CartCell.CellId);
            _updateCartItem = updateCartItem;
            Cart = cart;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CartCell.CellId, indexPath) as CartCell;
            cell.UpdateCell(Cart.CartItems.ElementAt(indexPath.Row), _updateCartItem, _isEdit);
            cell.SelectionStyle = UITableViewCellSelectionStyle.None;
            if (!_isEdit)
            {
                cell.BackgroundColor = Consts.ColorTransparent;
            }
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return Cart?.CartItems.Count ?? 0;
        }
    }
}