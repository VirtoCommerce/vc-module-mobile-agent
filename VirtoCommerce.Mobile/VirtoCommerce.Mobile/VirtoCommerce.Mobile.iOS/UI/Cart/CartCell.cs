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
    public class CartCell : UITableViewCell
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
        private UIView _border;

        #endregion

        public const string CellId = "CartCell";

        public CartCell(IntPtr handle) : base(handle)
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
            _iconImage.Image = UIImage.FromFile(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), item.Product.TitleImage));
            if (!isEdit)
            {
                _stepper.Hidden = true;
                _quantity.Hidden = true;
                _price.Text += " x " + item.Quantity;
            }
        }


        private void InitView()
        {
            //main content
            ContentView.BackgroundColor = UIColor.White;
            //title
            _title = new UILabel()
            {
                TextColor = Consts.ColorDark,
                Font = UIFont.FromName(Consts.FontNameBold, 18),
                LineBreakMode = UILineBreakMode.WordWrap,
                Lines = 0
            };
            //price
            _price = new UILabel()
            {
                TextColor = Consts.ColorDark,
                Font = UIFont.FromName(Consts.FontNameRegular, 16),
            };
            //quantity
            _quantity = new UILabel()
            {
                TextColor = Consts.ColorDark,
                Font = UIFont.FromName(Consts.FontNameBold, 16),
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
                TextColor = Consts.ColorDark,
                Font = UIFont.FromName(Consts.FontNameBold, 16),
                TextAlignment = UITextAlignment.Center
            };
            _border = new UIView()
            {
                BackgroundColor = Consts.ColorMain.ColorWithAlpha(new nfloat(0.1))
            };
            ContentView.AddSubviews(_title, _price, _quantity, _stepper, _iconImage, _subTotalLabel, _border);
            ContentView.Layer.BorderColor = Consts.ColorMain.ColorWithAlpha(new nfloat(0.1)).CGColor;
            ContentView.Layer.BorderWidth = 1;
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
            ContentView.Layer.BorderColor = Consts.ColorMain.ColorWithAlpha(new nfloat(0.1)).CGColor;
            ContentView.Layer.BorderWidth = 2;
            //icon
            var iconFrame = _iconImage.Frame;
            iconFrame.Width = 100;
            var iconScale = 100 / _iconImage.Image?.Size.Width ?? 1;
            iconFrame.Height = _iconImage.Image.Size.Height * iconScale;// ActualRowHeight - _padding * 2;
            if (iconFrame.Height > ActualRowHeight - _padding * 2)
            {
                iconFrame.Height = ActualRowHeight - _padding * 2;
                iconScale = iconFrame.Height / _iconImage.Image?.Size.Height ?? 1;
                iconFrame.Width = (_iconImage.Image?.Size.Width ?? 0) * iconScale;
                if (iconFrame.Width < 100)
                {
                    iconFrame.X = (100 - iconFrame.Width) / 2;
                }
            }
            else
            {
                iconFrame.Y = (ActualRowHeight - iconFrame.Height) / 2;
            }
            _iconImage.Frame = iconFrame;

            if (_isEdit)
            {
                PrepareEdit();
            }
            else {
                PrepareNotEdit();
            }

        }
        private void PrepareEdit()
        {
            //sub total
            _subTotalLabel.SizeToFit();
            var subTotalFrame = _subTotalLabel.Frame;
            subTotalFrame.X = ContentView.Frame.Width - _padding - subTotalFrame.Width;
            subTotalFrame.Y = ContentView.Frame.Height / 2 - subTotalFrame.Height / 2;
            _subTotalLabel.Frame = subTotalFrame;

            //stepper
            _stepper.SizeToFit();
            _quantity.SizeToFit();
            var stepperFrame = _stepper.Frame;
            stepperFrame.X = subTotalFrame.X - _padding - stepperFrame.Width;
            stepperFrame.Y = ContentView.Frame.Height / 2 + _padding / 2;
            _stepper.Frame = stepperFrame;
            //quantity
            var quantityFrame = _quantity.Frame;
            quantityFrame.Width = stepperFrame.Width;
            quantityFrame.X = stepperFrame.X + (stepperFrame.Width / 2 - quantityFrame.Width / 2);
            quantityFrame.Y = stepperFrame.Y - _padding - quantityFrame.Height;
            _quantity.Frame = quantityFrame;
            //price 
            _price.SizeToFit();
            var priceFrame = _price.Frame;
            priceFrame.X = stepperFrame.X - _padding - priceFrame.Width;
            priceFrame.Y = ContentView.Frame.Height / 2 - priceFrame.Height / 2;
            _price.Frame = priceFrame;
            //border 
            var borderFrame = _border.Frame;
            borderFrame.Width = 2;
            borderFrame.Height = ContentView.Frame.Height - _padding * 2;
            borderFrame.X = priceFrame.X - _padding - 2;
            borderFrame.Y = _padding;
            _border.Frame = borderFrame;
            //title
            var titleFrame = _title.Frame;
            titleFrame.Width = borderFrame.X - _iconImage.Frame.Width - _padding;
            titleFrame.Height = ContentView.Frame.Height;
            titleFrame.X = _iconImage.Frame.Width + _iconImage.Frame.X + _padding;
            titleFrame.Y = 0;
            _title.Frame = titleFrame;
        }

        private void PrepareNotEdit()
        {
            //sub total
            _subTotalLabel.SizeToFit();
            var subTotalFrame = _subTotalLabel.Frame;
            subTotalFrame.X = ContentView.Frame.Width - _padding - subTotalFrame.Width;
            subTotalFrame.Y = ContentView.Frame.Height / 2 - subTotalFrame.Height / 2;
            _subTotalLabel.Frame = subTotalFrame;
            //price 
            _price.SizeToFit();
            var priceFrame = _price.Frame;
            priceFrame.X = subTotalFrame.X - _padding * 2 - priceFrame.Width;
            priceFrame.Y = ContentView.Frame.Height / 2 - priceFrame.Height / 2;
            _price.Frame = priceFrame;
            //border 
            var borderFrame = _border.Frame;
            borderFrame.Width = 2;
            borderFrame.Height = ContentView.Frame.Height - _padding * 2;
            borderFrame.X = priceFrame.X + priceFrame.Width + _padding;
            borderFrame.Y = _padding;
            _border.Frame = borderFrame;
            //title
            var titleFrame = _title.Frame;
            titleFrame.Width = priceFrame.X - _iconImage.Frame.Width - _padding * 2;
            titleFrame.Height = ContentView.Frame.Height;
            titleFrame.X = _iconImage.Frame.Width + _iconImage.Frame.X + _padding;
            titleFrame.Y = 0;
            _title.Frame = titleFrame;
        }
    }
}