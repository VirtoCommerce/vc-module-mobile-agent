using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using MvvmCross.iOS.Views;
using VirtoCommerce.Mobile.Model;
using VirtoCommerce.Mobile.ViewModels;
using CoreGraphics;
using MvvmCross.Binding.BindingContext;
using System.Drawing;

namespace VirtoCommerce.Mobile.iOS.Views
{
    
    public class DetailProductView: MvxViewController
    {
        public const int Padding = 10;
        public DetailProductView(): base(null,null)
        {
            
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            CreateView();
            var set = this.CreateBindingSet<DetailProductView, DetailProductViewModel>();
            set.Bind(_titleLabel).To(x => x.Product.Name);
            set.Bind(_descriptionLabel).To(x => x.Product.Description);
            set.Bind(_salePriceLable).To(x => x.Product.Price.FormattedSalePrice);
            set.Bind(NavigationItem).For(x => x.Title).To(x => x.Product.Name);
            set.Bind(_listPriceLable).For(x => x.AttributedText).To(x => x.Product.Price.FormattedListPrice).WithConversion(new NativConvertors.StrikeTextConvertor());
            set.Apply();
        }
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            NavigationController.NavigationBarHidden = false;
        }
        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            var f = _productImage.Frame;
            f.Width = View.Bounds.Width - Padding * 2;
            f.Width = View.Bounds.Height / 2;
            
            UIImage img = UIImage.FromFile(((DetailProductViewModel)ViewModel).Product.Id + ".png");
            img = img.Scale(new CGSize(f.Width, f.Height));
            _productImage.Image = img;
            _productImage.Frame = f;
            ResizeText();
            ResizePrice();
            _cartButton.Center = new CGPoint(View.Bounds.Width / 2, _priceView.Frame.Y + _salePriceLable.Frame.Height + 30);
        }

        #region View

        private UIImageView _productImage { get; set; }
        private UILabel _titleLabel { get; set; }
        private UILabel _descriptionLabel { set; get; }
        private UIView _priceView { set; get; }
        private UILabel _salePriceLable { set; get; }
        private UILabel _listPriceLable { set; get; }
        private UIImageView _cartButton { set; get; }
        private UIView _textView { set; get; }
        private void CreateView()
        {

            View = new UIView(new CGRect(0, 0, 600, 600))
            {
                BackgroundColor = UIColor.White,
                ContentMode = UIViewContentMode.ScaleToFill,
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight,
                AutosizesSubviews = true
            };
            _productImage = new UIImageView(new RectangleF(0, 0, 231, 200));
            _textView = new UIView(new CGRect(0, 300, 300, 250));
            _titleLabel = new UILabel(new CGRect(0, 5, 295, 40))
            {
                TextColor = UIColor.Black,
                Font = UIFont.FromName("Helvetica Neue", 25),
                TextAlignment = UITextAlignment.Center,
                Lines = 0,
                LineBreakMode = UILineBreakMode.WordWrap,
            };
            _descriptionLabel = new UILabel(new RectangleF(0, 45, 295, 200))
            {
                Font = UIFont.FromName("Helvetica Neue", 17),
                TextAlignment = UITextAlignment.Center,
                TextColor = UIColor.Black,
                Lines = 0,
                LineBreakMode = UILineBreakMode.WordWrap,
            };
            _textView.AddSubviews(_descriptionLabel, _titleLabel);
            View.AddSubviews(_productImage, _textView);
            _listPriceLable = new UILabel(new RectangleF(0, 5, 50, 30))
            {
                TextColor = UIColor.Gray,
                Font = UIFont.FromName("Helvetica Neue", 30),
                TextAlignment = UITextAlignment.Center,
            };
            _salePriceLable = new UILabel(new RectangleF(0, 5, 50, 30))
            {
                TextColor = UIColor.Black,
                Font = UIFont.FromName("Helvetica Neue", 30),
                TextAlignment = UITextAlignment.Center,
            };
            
            _priceView = new UIView(new RectangleF(0, 10, 295, 30));
            _priceView.AddSubviews(_listPriceLable, _salePriceLable);
            Add(_priceView);
            _cartButton = new UIImageView(new RectangleF(0, 0, 50, 50))
            {
                Image = UIImage.FromFile("cart.png"),
            };
            Add(_cartButton);
        }

        private void ResizeText()
        {
            var f = _descriptionLabel.Frame;
            f.Width = View.Bounds.Width - Padding * 2;
            _descriptionLabel.Frame = f;
            f = _titleLabel.Frame;
            f.Width = View.Bounds.Width - Padding * 2;
            _titleLabel.Frame = f;
            _descriptionLabel.SizeToFit();
            var textViewFrame = _textView.Frame;
            textViewFrame.Width = View.Bounds.Width - Padding * 2;
            textViewFrame.Y = View.Bounds.Height / 2;
            textViewFrame.X = Padding * 2;
            textViewFrame.Height = _titleLabel.Frame.Height + _descriptionLabel.Frame.Height + 10;
            _textView.Frame = textViewFrame;
        }

        private void ResizePrice()
        {
            _salePriceLable.SizeToFit();
            _listPriceLable.SizeToFit();
            var f = _listPriceLable.Frame;
            if (_listPriceLable.Frame.Width != 0)
            {
                f.Width = (View.Bounds.Width - Padding) / 2;
                f.X = Padding;
            }
            _listPriceLable.Frame = f;
            //
            f = _salePriceLable.Frame;
            f.Width = (View.Bounds.Width - Padding) / (_listPriceLable.Frame.Width == 0 ? 1 : 2);
            f.X = Padding +  _listPriceLable.Frame.Width;
            _salePriceLable.Frame = f;

            var textViewFrame = _textView.Frame;
            var actionViewsFrame = _priceView.Frame;
            actionViewsFrame.Y = textViewFrame.Y + textViewFrame.Height;
            actionViewsFrame.Width = View.Bounds.Width;
            _priceView.Frame = actionViewsFrame;
        }
        #endregion
    }
}