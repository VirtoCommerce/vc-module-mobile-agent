
using System;
using System.Drawing;
using VirtoCommerce.Mobile.Model;
using Foundation;
using UIKit;
using System.Linq;

using Xamarin.Themes;
using System.IO;
using CoreGraphics;

namespace VirtoCommerce.Mobile.iOS.UI.Products
{
	public class ProductCell : UIView
	{
		private UIView _statusView { get; set; }
		private UIImageView _productImage { get; set; }
		private UILabel _titleLabel { get; set; }
        private UILabel _descriptionLabel { set; get; }
        private UIView _actionsView { set; get; }
        private UILabel _salePriceLable { set; get; }
        private UILabel _listPriceLable { set; get; }
        private UIButton _cartButton { set; get; }
        private UIView _lineView { set; get; }

        private Action<Product> _cartTouch { set; get; }
		Product _data;

		public static readonly NSString Key = new NSString ("ProductCell");
		
		public ProductCell(Action<Product> cartTouch) //: base (UITableViewCellStyle.Default, Key)
		{
            _cartTouch = cartTouch;
            this.Frame = new CoreGraphics.CGRect(0, 0, 241, 1000);
			InitSubviews();
			ApplyStyles();
		}

        void InitSubviews()
        {
            _productImage = new UIImageView(new RectangleF(5, 5, 231, 200));

            AddSubviews(_productImage);
            //
            _statusView = new UIView(new RectangleF(0, 0, 241, 71));
            //
            _titleLabel = new UILabel(new RectangleF(15, 0, 210, 22))
            {
                TextColor = Consts.ColorDark,
                Font = UIFont.FromName(Consts.FontNameBold, 16),
                TextAlignment = UITextAlignment.Center,
                Lines = 0,
                LineBreakMode = UILineBreakMode.WordWrap
            };
            //
            _lineView = new UIView(new CGRect(90, 0, 60, 2))
            {
                BackgroundColor = Consts.ColorMain
            };
            _descriptionLabel = new UILabel(new RectangleF(15, 45, 210, 22))
            {
                Font = UIFont.FromName(Consts.FontNameRegular, 12),
                TextColor = Consts.ColorDarkLight,
                Lines = 0,
                LineBreakMode = UILineBreakMode.WordWrap
            };

            _statusView.AddSubviews(_titleLabel, _descriptionLabel, _lineView);
            Add(_statusView);
            //
            _listPriceLable = new UILabel(new RectangleF(8, 10, 50, 30))
            {
                TextColor = Consts.ColorGray,
                Font = UIFont.FromName(Consts.FontNameRegular, 16),
                TextAlignment = UITextAlignment.Center
            };
            //
            _salePriceLable = new UILabel(new RectangleF(58, 10, 50, 30))
            {
                TextColor = Consts.ColorBlack,
                Font = UIFont.FromName(Consts.FontNameRegular, 16),
                TextAlignment = UITextAlignment.Center
            };
            //
            _cartButton = new UIButton(new RectangleF(200, 8, 25, 25));
            _cartButton.TouchDown += TouchCart;
            _cartButton.SetImage(UIImage.FromFile("cart-black"), UIControlState.Normal);
            
            _actionsView = new UIView(new RectangleF(0, 20, 241, 40));
            _actionsView.AddSubviews(_listPriceLable, _salePriceLable, _cartButton);
            //
            nfloat r,g,b,a;
            Consts.ColorMain.GetRGBA(out r, out g, out b, out a);
            Layer.BorderColor = UIColor.FromRGBA(r, g, b, new nfloat(0.1)).CGColor;
            Layer.BorderWidth = 1;
            //
            Add(_actionsView);
        }

        private void TouchCart(object s, EventArgs e)
        {
            _cartTouch?.Invoke(_data);
        } 

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _cartButton.AllTouchEvents -= TouchCart;
        }

        void ApplyStyles()
		{
            BackgroundColor = UIColor.White;
		}

        public void Bind(Product data)
        {

            _data = data;
            _titleLabel.Text = data.Name.ToUpper();
            _descriptionLabel.Text = (data.Reviews?.FirstOrDefault(x => x.ReviewType == "QuickReview")?.Content) ?? data.Reviews?.FirstOrDefault()?.Content;
            var listPrice = data.Price?.FormattedListPrice;
            if (!string.IsNullOrEmpty(listPrice))
            {
                var attrString = new NSMutableAttributedString(listPrice);
                attrString.AddAttribute(
                    UIStringAttributeKey.StrikethroughStyle,
                    NSNumber.FromInt32((int)NSUnderlineStyle.Single),
                    new NSRange(0, attrString.Length));
                _listPriceLable.AttributedText = attrString;
                _actionsView.BackgroundColor = Consts.ColorMain.ColorWithAlpha(new nfloat(0.5));
            }
            _salePriceLable.Text =  data.Price?.FormattedSalePrice;
            var image = UIImage.FromFile(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), data.TitleImage));
            var scale = 230 / image.Size.Width;
            image = image.Scale(new CGSize(image.Size.Width * scale, image.Size.Height * scale));
            _productImage.Image = image;
            var imageFrame = _productImage.Frame;
            imageFrame.Size = image.Size;
            _productImage.Frame = imageFrame;
            _productImage.Image = image;
        }

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
            _titleLabel.SizeToFit();
            _descriptionLabel.SizeToFit();
            var titleFrame = _titleLabel.Frame;
            titleFrame.Y = 20;
            titleFrame.X = 0;
            titleFrame.Width = _statusView.Frame.Width;
            _titleLabel.Frame = titleFrame;
            var lineFrame = _lineView.Frame;
            lineFrame.Y = titleFrame.Height + titleFrame.Y + 20;
            _lineView.Frame = lineFrame;
            var descFrame = _descriptionLabel.Frame;
            descFrame.Y = lineFrame.Y + lineFrame.Height + 20;
            _descriptionLabel.Frame = descFrame;
            var statusViewFrame = _statusView.Frame;
            statusViewFrame.Height = descFrame.Height + descFrame.Y;
            statusViewFrame.Y = _productImage.Frame.Y + _productImage.Frame.Height;
            _statusView.Frame = statusViewFrame;
            //
            _listPriceLable.SizeToFit();
            _salePriceLable.SizeToFit();
            var actionFrame = _actionsView.Frame;
            actionFrame.Y = _statusView.Frame.Y + _statusView.Frame.Height + 20;
            _actionsView.Frame = actionFrame;
            var saleFrame = _salePriceLable.Frame;
            saleFrame.X = _listPriceLable.Frame.Width + _listPriceLable.Frame.X + 3;
            _salePriceLable.Frame = saleFrame;
            /*//
            _descriptionLabel.SizeToFit();
            _statusView.SizeToFit();
			var statusFrame = _statusView.Frame;
			
			_statusView.Frame = Rectangle.Round((RectangleF)statusFrame);
            //
            _listPriceLable.SizeToFit();
            _salePriceLable.SizeToFit();
            var actionFrame = _actionsView.Frame;
            actionFrame.Y = statusFrame.Y + statusFrame.Height + 8;
            _actionsView.Frame = actionFrame;
            var saleFrame = _salePriceLable.Frame;
            saleFrame.X = _listPriceLable.Frame.Width + _listPriceLable.Frame.X + 3;
            _salePriceLable.Frame = saleFrame;
            //line
            var lineFrame = _lineView.Frame;
            lineFrame.Y = _titleLabel.Frame.Height + 20 + _titleLabel.Frame.Y;
            _lineView.Frame = lineFrame;
            //*/
			var cellFrame = Frame;
			cellFrame.Width = 241;
            cellFrame.Height = _productImage.Frame.Y + _productImage.Frame.Height + _statusView.Frame.Height + 20 + actionFrame.Height;
			Frame = Rectangle.Round((RectangleF)cellFrame);

            //Superview.Superview.LayoutSubviews();
        }
	}
}

