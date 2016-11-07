using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using VirtoCommerce.Mobile.Model;
using System.Drawing;
using CoreGraphics;

namespace VirtoCommerce.Mobile.iOS.UI.Cart
{
    public class CartCell:UITableViewCell
    {
        #region Data
        private CartItem _cartItem;
        private Action<CartItem> _updateCartItem;
        private const int _padding = 10;
        public const float RowHeight = 100;
        #endregion

        #region View
        private UILabel _title;
        private UILabel _price;
        private UILabel _quantity;
        private UIStepper _stepper;
        private UIImageView _iconImage;
        private UILabel _subTotalLabel;

        #endregion

        public const string CellId = "CartCell";

        public CartCell(IntPtr handle):base(handle)
        {
            InitView();
        }

        public void UpdateCell(CartItem item, Action<CartItem> updateCartItem)
        {
            _cartItem = item;
            _updateCartItem = updateCartItem;
            _title.Text = item.Product.Name;
            _price.Text = item.Product.Price?.FormattedSalePriceFull;
            _quantity.Text = item.Quantity.ToString();
            _stepper.Value = item.Quantity;
            _subTotalLabel.Text = item.FormattedSubTotal;
            _iconImage.Image = UIImage.FromFile(item.Product.TitleImage);
        }


        private void InitView()
        {
            //title
            _title = new UILabel()
            {
                TextColor = UIColor.FromRGB(105, 105, 105),
                Font = UIFont.FromName(Consts.FontNameRegular, 14),
            };
            //price
            _price = new UILabel()
            {
                TextColor = UIColor.FromRGB(105, 105, 105),
                Font = UIFont.FromName(Consts.FontNameRegular, 14),
            };
            //quantity
            _quantity = new UILabel()
            {
                TextColor = UIColor.FromRGB(105, 105, 105),
                Font = UIFont.FromName(Consts.FontNameRegular, 14),
                TextAlignment = UITextAlignment.Center
            };
            //stepper
            _stepper = new UIStepper()
            {
                StepValue = 1,
            };
            _stepper.ValueChanged += QuantityChange;
            //icon
            _iconImage = new UIImageView(new RectangleF(_padding, _padding, RowHeight - _padding, RowHeight - _padding));
            //sub total
            _subTotalLabel = new UILabel()
            {
                TextColor = UIColor.FromRGB(255, 59, 48),
                Font = UIFont.FromName(Consts.FontNameRegular, 14),
                TextAlignment = UITextAlignment.Center
            };
            ContentView.AddSubviews(_title, _price, _quantity, _stepper, _iconImage, _subTotalLabel);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _stepper.ValueChanged -= QuantityChange;
        }

        private void QuantityChange(object sender, EventArgs e)
        {
            _quantity.Text = ((int)_stepper.Value).ToString();
            _cartItem.Quantity = (int)_stepper.Value;
            _updateCartItem?.Invoke(_cartItem);
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            //icon
            var iconFrame = _iconImage.Frame;
            iconFrame.Width = 150;
            iconFrame.Height = RowHeight - _padding * 2;
            _iconImage.Frame = iconFrame;
            //title
            var titleFrame = _title.Frame;
            titleFrame.Width = ContentView.Frame.Width - _iconImage.Frame.Width - _padding;
            titleFrame.Height = 40;
            titleFrame.X = _iconImage.Frame.Width + _iconImage.Frame.X + _padding;
            titleFrame.Y = _padding;
            _title.Frame = titleFrame;
            //price 
            var priceFrame = _price.Frame;
            priceFrame.Width = titleFrame.Width;
            priceFrame.X = titleFrame.X;
            priceFrame.Y = titleFrame.Y + titleFrame.Height + _padding;
            priceFrame.Height = 40;
            _price.Frame = priceFrame;
            //stepper
            _stepper.SizeToFit();
            var stepperFrame = _stepper.Frame;
            stepperFrame.X = ContentView.Frame.Width - stepperFrame.Width - _padding;
            stepperFrame.Y = (RowHeight / 2) + (_padding / 2);
            _stepper.Frame = stepperFrame;
            //quantity
            _quantity.SizeToFit();
            var quantityFrame = _quantity.Frame;
            quantityFrame.Width = stepperFrame.Width;
            quantityFrame.X = stepperFrame.X;
            quantityFrame.Y = (RowHeight / 2) - (_padding / 2) - quantityFrame.Height;
            _quantity.Frame = quantityFrame;
            //sub total
            _subTotalLabel.SizeToFit();
            var subTotalFrame = _subTotalLabel.Frame;
            subTotalFrame.Width = stepperFrame.Width;
            subTotalFrame.X = stepperFrame.X;
            subTotalFrame.Y = stepperFrame.Y + stepperFrame.Height + _padding;
            _subTotalLabel.Frame = subTotalFrame;
        }
    }
}