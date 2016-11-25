using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using VirtoCommerce.Mobile.Model;
using System.Drawing;
using CoreGraphics;
using System.IO;

namespace VirtoCommerce.Mobile.iOS.UI.Cart
{
    public class CartCell:UITableViewCell
    {
        #region Data
        private CartItem _cartItem;
        private Action<CartItem> _updateCartItem;
        private const int _padding = 10;
        public const float RowHeight = 110;
        public float ActualRowHeight = 100;
        private bool _isEdit;
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

        public void UpdateCell(CartItem item, Action<CartItem> updateCartItem, bool isEdit = true)
        {
            _isEdit = isEdit;
            _cartItem = item;
            _updateCartItem = updateCartItem;
            _title.Text = item.Product.Name;
            _price.Text = item.Product.Price?.FormattedSalePriceFull;
            _quantity.Text = item.Quantity.ToString();
            _stepper.Value = item.Quantity;
            _subTotalLabel.Text = item.FormattedSubTotal;
            _iconImage.Image = UIImage.FromFile(Path.Combine( Environment.GetFolderPath(Environment.SpecialFolder.Personal),item.Product.TitleImage));
            if (!isEdit)
            {
                _stepper.Hidden = true;
                _subTotalLabel.Text = "Subtotal: " + _subTotalLabel.Text;
                _quantity.Text = "Quantity: " + _quantity.Text;
            }
        }


        private void InitView()
        {
            //main content
            ContentView.BackgroundColor = UIColor.White;
            //title
            _title = new UILabel()
            {
                TextColor = Consts.ColorBlack,
                Font = UIFont.FromName(Consts.FontNameRegular, 14),
                LineBreakMode = UILineBreakMode.WordWrap,
                Lines = 0
            };
            //price
            _price = new UILabel()
            {
                TextColor = Consts.ColorBlack,
                Font = UIFont.FromName(Consts.FontNameRegular, 14),
            };
            //quantity
            _quantity = new UILabel()
            {
                TextColor = Consts.ColorBlack,
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
            _iconImage = new UIImageView(new RectangleF(_padding, _padding, ActualRowHeight - _padding, ActualRowHeight - _padding));
            //sub total
            _subTotalLabel = new UILabel()
            {
                TextColor = Consts.ColorRed,
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
            _quantity.Text = _isEdit ? ((int)_stepper.Value).ToString() : "Quantity: " + ((int)_stepper.Value).ToString();
            _cartItem.Quantity = (int)_stepper.Value;
            _updateCartItem?.Invoke(_cartItem);
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            //main view
            var contentViewFrame = ContentView.Frame;
            contentViewFrame.Width = ContentView.Frame.Width - _padding;
            contentViewFrame.Height = ContentView.Frame.Height - _padding;
            contentViewFrame.X = _padding / 2;
            contentViewFrame.Y = _padding / 2;
            ContentView.Frame = contentViewFrame;
            //icon
            var iconFrame = _iconImage.Frame;
            iconFrame.Width = 150;
            var iconScale = 150 / _iconImage.Image?.Size.Width ?? 1;
            iconFrame.Height = _iconImage.Image.Size.Height * iconScale;// ActualRowHeight - _padding * 2;
            if (iconFrame.Height > ActualRowHeight - _padding * 2)
            {
                iconFrame.Height = ActualRowHeight - _padding * 2;
                iconScale = iconFrame.Height / _iconImage.Image?.Size.Height ?? 1;
                iconFrame.Width = (_iconImage.Image?.Size.Width ?? 0) * iconScale;
                if (iconFrame.Width < 150)
                {
                    iconFrame.X = (150 - iconFrame.Width) / 2;
                }
            }
            else
            {
                iconFrame.Y = (ActualRowHeight - iconFrame.Height) / 2;
            }
            _iconImage.Frame = iconFrame;
            
            //stepper
            _stepper.SizeToFit();
            var stepperFrame = _stepper.Frame;
            stepperFrame.X = ContentView.Frame.Width - stepperFrame.Width - _padding;
            stepperFrame.Y = (RowHeight / 2) + (_padding / 2) - stepperFrame.Height;
            if (!_isEdit)
            {
                stepperFrame.Width = (int)(ContentView.Frame.Width * 0.33);
                stepperFrame.X = ContentView.Frame.Width - stepperFrame.Width;
                stepperFrame.Height = 0;
            }
            _stepper.Frame = stepperFrame;
            //quantity
            _quantity.SizeToFit();
            var quantityFrame = _quantity.Frame;
            quantityFrame.Width = stepperFrame.Width;
            quantityFrame.X = stepperFrame.X;
            quantityFrame.Y = stepperFrame.Y - _padding / 2 - quantityFrame.Height;
            _quantity.Frame = quantityFrame;
            //sub total
            _subTotalLabel.SizeToFit();
            var subTotalFrame = _subTotalLabel.Frame;
            subTotalFrame.Width = stepperFrame.Width;
            subTotalFrame.X = stepperFrame.X;
            subTotalFrame.Y = stepperFrame.Y + stepperFrame.Height + _padding;
            _subTotalLabel.Frame = subTotalFrame;
            //title
            var titleFrame = _title.Frame;
            titleFrame.Width = ContentView.Frame.Width - _iconImage.Frame.Width - _padding * 3 - stepperFrame.Width;
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
        }
    }
}