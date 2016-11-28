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
using VirtoCommerce.Mobile.iOS.UI;
using VirtoCommerce.Mobile.iOS.UI.ProductDetail;
using VirtoCommerce.Mobile.iOS.NativConvertors;
using Xamarin.Themes;
using System.IO;

namespace VirtoCommerce.Mobile.iOS.Views
{

    public class DetailProductView : MvxViewController
    {

        public DetailProductViewModel DetailViewModel { get { return (DetailProductViewModel)ViewModel; } }

        public const int Padding = 10;
        private UIInterfaceOrientation _deviceOrientation;

        public DetailProductView() : base(null, null)
        {
            _deviceOrientation = UIApplication.SharedApplication.StatusBarOrientation;
            
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            CreateView();
            
        }
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            NavigationController.NavigationBarHidden = false;
            _segmentControl.CurrentSegment = 0;
        }
        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            if (_deviceOrientation != UIApplication.SharedApplication.StatusBarOrientation)
            {
                _deviceOrientation = UIApplication.SharedApplication.StatusBarOrientation;
                CreateView();
            }
            PrepareMainInfo();
            //
            PrepareDetailInfo();
            if (_scrollView != null)
            {
                var scrollFrame = _scrollView.Frame;
                scrollFrame.Width = View.Frame.Width;
                scrollFrame.Height = View.Frame.Height;
                scrollFrame.X = 0;
                scrollFrame.Y = 0;
                _scrollView.Frame = scrollFrame;
                _scrollView.ContentSize = new CGSize(scrollFrame.Width, _mainInfo.Frame.Height + _mainInfo.Frame.Y + _detailView.Frame.Height);
            }
        }

        #region View
        private UILabel _manufactureLabel { set; get; }
        private UIView _mainInfo { set; get; }
        private UIView _detailView { set; get; }
        private UILabel _titleLabel { get; set; }
        private UILabel _descriptionLabel { set; get; }
        private UILabel _salePriceLable { set; get; }
        private UILabel _listPriceLable { set; get; }
        private UILabel _profitPriceLabel { set; get; }
        private UIButton _cartButton { set; get; }
        private ImageSlider _imageSlider { set; get; }
        private UITableView _propertiesTable { set; get; }
        private Controls.UISimpleSegments _segmentControl { set; get; }
        private UIView _borderView { set; get; }
        private UIBarButtonItem _cartOpenButton { set; get; }
        private UIScrollView _scrollView { set; get; }

        private void CreateView()
        {
            _scrollView = null;
            _borderView = null;
            View = new UIView(new CGRect(0, 0, 600, 600))
            {
                BackgroundColor = Consts.ColorMainBg,
                ContentMode = UIViewContentMode.ScaleToFill,
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight,
                AutosizesSubviews = true
            };

            #region main info
            _mainInfo = new UIView();
            //manufacture
            _manufactureLabel = new UILabel()
            {
                TextColor = Consts.ColorGray,
                Font = UIFont.FromName(Consts.FontNameRegular, 20),
                TextAlignment = UITextAlignment.Left,
                Lines = 0,
                LineBreakMode = UILineBreakMode.WordWrap,
            };
            _mainInfo.Add(_manufactureLabel);
            //title
            _titleLabel = new UILabel(new CGRect(0, 5, 295, 40))
            {
                TextColor = Consts.ColorBlack,
                Font = UIFont.FromName(Consts.FontNameBold, 20),
                TextAlignment = UITextAlignment.Left,
                Lines = 0,
                LineBreakMode = UILineBreakMode.WordWrap,
            };
            _mainInfo.AddSubview(_titleLabel);
            //slider
            _imageSlider = new ImageSlider()
            {
                BackgroundColor = Consts.ColorMainBg
            };
            foreach (var img in DetailViewModel.Product.Images)
            {
                _imageSlider.AddImage(UIImage.FromFile(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), img)));
            }
            _mainInfo.Add(_imageSlider);
            //price
            _listPriceLable = new UILabel(new RectangleF(0, 5, 50, 20))
            {
                TextColor = Consts.ColorDarkLight,
                Font = UIFont.FromName(Consts.FontNameRegular, 16),
                TextAlignment = UITextAlignment.Center,
            };
            _mainInfo.Add(_listPriceLable);
            _profitPriceLabel = new UILabel(new RectangleF(0, 5, 50, 30))
            {
                TextColor = UIColor.White,
                Font = UIFont.FromName(Consts.FontNameRegular, 14),
                TextAlignment = UITextAlignment.Center,
                BackgroundColor = Consts.ColorRed
            };
            _mainInfo.Add(_profitPriceLabel);
            _salePriceLable = new UILabel(new RectangleF(0, 5, 50, 30))
            {
                TextColor = Consts.ColorDark,
                Font = UIFont.FromName(Consts.FontNameBold, 22),
                TextAlignment = UITextAlignment.Center,
            };
            _mainInfo.Add(_salePriceLable);
            #endregion

            #region Detail info
            _detailView = new UIView();

            //description
            _descriptionLabel = new UILabel(new RectangleF(0, 0, 295, 200))
            {
                Font = UIFont.FromName(Consts.FontNameRegular, 17),
                TextAlignment = UITextAlignment.Left,
                TextColor = Consts.ColorBlack,
                Lines = 0,
                LineBreakMode = UILineBreakMode.WordWrap,
            };
            _detailView.AddSubview(_descriptionLabel);
            //tabbed
            _segmentControl = new Controls.UISimpleSegments(new CGRect(0, 0, 250, 50));
            _segmentControl.AddSegment("Properties");
            _segmentControl.AddSegment("Description");
            _segmentControl.ChangeSegment += ChangeSegment;
            _detailView.AddSubviews(_segmentControl);
            //properties
            _propertiesTable = new UITableView();
            _propertiesTable.BackgroundColor = Consts.ColorMainBg;
            _propertiesTable.ScrollEnabled = true;
            _propertiesTable.Source = new PropertiesSource(DetailViewModel.Product.Properties.Select(x => new KeyValuePair<string, string>(x.DisplayName, x.Value)).ToList());
            _propertiesTable.RowHeight = PropertyCell.CellHeight;
            _propertiesTable.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            _propertiesTable.ReloadData();
            _detailView.AddSubview(_propertiesTable);
            //add to cart item
            _cartButton = Helpers.UICreator.CreateSimpleButton("Add to cart");
            _detailView.AddSubview(_cartButton);
            
            #endregion
            //cart button
            _cartOpenButton = new UIBarButtonItem("Cart", UIBarButtonItemStyle.Plain, (s, e) => { DetailViewModel.OpenCartCommad.Execute(); });
            NavigationItem.RightBarButtonItem = _cartOpenButton;
            if (_deviceOrientation == UIInterfaceOrientation.Portrait || _deviceOrientation == UIInterfaceOrientation.PortraitUpsideDown)
            {
                _scrollView = new UIScrollView();
                _scrollView.AddSubviews(_mainInfo, _detailView);
                View.Add(_scrollView);
            }
            else
            {

                View.AddSubviews(_mainInfo, _detailView);
                _borderView = new UIView
                {
                    BackgroundColor = Consts.ColorGray
                };
                Add(_borderView);
            }
            //bindings
            var set = this.CreateBindingSet<DetailProductView, DetailProductViewModel>();
            set.Bind(_titleLabel).To(x => x.Product.Name);
            set.Bind(_descriptionLabel).To(x => x.ProductDescription);
            set.Bind(_salePriceLable).To(x => x.Product.Price.FormattedSalePriceFull);
            set.Bind(NavigationItem).For(x => x.Title).To(x => x.Product.Name);
            set.Bind(_listPriceLable).For(x => x.AttributedText).To(x => x.Product.Price.FormattedListPriceFull).WithConversion(new StrikeTextConvertor());
            set.Bind(_manufactureLabel).For(x => x.Text).To(x => x.Product.Manufacture);
            set.Bind(_profitPriceLabel).For(x => x.Text).To(x => x.Product.Price).WithConversion(new ProfitConvertor());
            set.Bind(_descriptionLabel).For(x => x.Hidden).To(x => x.HideDescription);
            set.Bind(_propertiesTable).For(x => x.Hidden).To(x => x.HideProperties);
            set.Bind(_cartButton).To(x => x.AddToCartCommand);
            set.Bind(_cartOpenButton).For(x => x.Title).To(x => x.CountInCart);
            set.Apply();
        }

        private void ChangeSegment(object o, int e)
        {
            ((DetailProductViewModel)ViewModel).SetSegment(_segmentControl.CurrentSegment);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _segmentControl.ChangeSegment -= ChangeSegment;
            DetailViewModel.UnSubscribeEventor();
        }
        private bool IsPortrait()
        {
            return _deviceOrientation == UIInterfaceOrientation.Portrait || _deviceOrientation == UIInterfaceOrientation.PortraitUpsideDown;
        }
        private void PrepareMainInfo()
        {
            var mainViewFrame = _mainInfo.Frame;
            mainViewFrame.Width = (!IsPortrait() ? (View.Frame.Width / 2) : (View.Frame.Width - Padding)) - Padding;
            mainViewFrame.Height = View.Frame.Height;
            mainViewFrame.X = Padding;
            _mainInfo.Frame = mainViewFrame;
            //prepare manufacture
            _manufactureLabel.SizeToFit();
            var manufFrame = _manufactureLabel.Frame;
            manufFrame.Width = _mainInfo.Frame.Width;
            manufFrame.X = 0;
            manufFrame.Y = Padding;
            _manufactureLabel.Frame = manufFrame;
            //prepare slider
            var sliderFrame = _imageSlider.Frame;
            sliderFrame.Width = mainViewFrame.Width;
            sliderFrame.Y = manufFrame.Y + manufFrame.Height + Padding;
            sliderFrame.Height = (int)(_mainInfo.Frame.Height * (IsPortrait() ? 0.8 : 0.9));
            _imageSlider.Frame = sliderFrame;
            _imageSlider.Draw(_imageSlider.Frame);
            //prepare title
            _titleLabel.SizeToFit();
            var titleFrame = _titleLabel.Frame;
            titleFrame.Width = _mainInfo.Frame.Width / 2;
            titleFrame.X = Padding;
            titleFrame.Y = Padding + sliderFrame.Height + sliderFrame.Y;
            _titleLabel.Frame = titleFrame;
            //prepare Price
            _salePriceLable.SizeToFit();
            var salePriceFrame = _salePriceLable.Frame;
            salePriceFrame.Y = titleFrame.Y;
            salePriceFrame.X = mainViewFrame.Width - Padding - salePriceFrame.Width;
            _salePriceLable.Frame = salePriceFrame;

            //list price
            if (!string.IsNullOrEmpty(_profitPriceLabel.Text))
            {
                _listPriceLable.SizeToFit();
                var listPriceFrame = _listPriceLable.Frame;
                listPriceFrame.X = mainViewFrame.Width - _listPriceLable.Frame.Width - salePriceFrame.Width - Padding * 2;
                listPriceFrame.Y = titleFrame.Y + (salePriceFrame.Height - _listPriceLable.Frame.Height)-2;
                _listPriceLable.Frame = listPriceFrame;
            }
            else
            {
                _listPriceLable.Hidden = true;
            }

            //prepare profit
            if (!string.IsNullOrEmpty(_profitPriceLabel.Text))
            {
                _profitPriceLabel.SizeToFit();
                View.BringSubviewToFront(_profitPriceLabel);
                var profitPriceFrame = _profitPriceLabel.Frame;
                profitPriceFrame.Width += Padding * 2;
                profitPriceFrame.Height += Padding * 2;
                profitPriceFrame.Y = 30;
                profitPriceFrame.X = 30;
                _profitPriceLabel.Frame = profitPriceFrame;
            }
            else
            {
                _profitPriceLabel.Hidden = true;
            }
            
        }

        private nfloat GetMainInfoHeight()
        {
            return _titleLabel.Frame.Y + _titleLabel.Frame.Height;
        }

        private void PrepareDetailInfo()
        {
            var detailViewFrame = _detailView.Frame;
            detailViewFrame.Width = (!IsPortrait() ? (View.Frame.Width / 2) : (View.Frame.Width - Padding)) - Padding;
            detailViewFrame.Height = View.Frame.Height;
            detailViewFrame.X = (!IsPortrait() ? (View.Frame.Width / 2) : 0) + Padding;
            if (_scrollView != null)
                detailViewFrame.Y = GetMainInfoHeight();
            _detailView.Frame = detailViewFrame;

            //border
            if (_borderView != null)
            {
                var borderFrame = _borderView.Frame;
                borderFrame.X = detailViewFrame.X;
                borderFrame.Height = detailViewFrame.Height;
                borderFrame.Width = 1;
                _borderView.Frame = borderFrame;
            }
            //segment control
            var segmentFrame = _segmentControl.Frame;
            segmentFrame.Width = detailViewFrame.Width;
            segmentFrame.X = detailViewFrame.Width / 2 - segmentFrame.Width / 2;
            segmentFrame.Y = Padding;
            _segmentControl.Frame = segmentFrame;
            //description
            _descriptionLabel.SizeToFit();
            var descriptionFrame = _descriptionLabel.Frame;
            descriptionFrame.Width = detailViewFrame.Width - Padding;
            descriptionFrame.X = Padding;
            descriptionFrame.Y = _segmentControl.Frame.Y + _segmentControl.Frame.Height + Padding;
            _descriptionLabel.Frame = descriptionFrame;
            //properties
            var propertiesTableFrame = _propertiesTable.Frame;
            propertiesTableFrame.Width = detailViewFrame.Width - Padding;
            propertiesTableFrame.X = Padding;
            propertiesTableFrame.Y = segmentFrame.Y + segmentFrame.Height + Padding;
            propertiesTableFrame.Height = _propertiesTable.RowHeight * _propertiesTable.Source.RowsInSection(_propertiesTable, 0);
            _propertiesTable.Frame = propertiesTableFrame;
            //_propertiesTable.ReloadData();
            //add to cart
            var addCartFrame = _cartButton.Frame;
            addCartFrame.X = (detailViewFrame.Width - addCartFrame.Width) / 2;
            var tableHeight = _propertiesTable.RowHeight * _propertiesTable.Source.RowsInSection(_propertiesTable, 1);
            addCartFrame.Y = (tableHeight > _descriptionLabel.Frame.Height ? tableHeight : _descriptionLabel.Frame.Height) + Padding + _propertiesTable.Frame.Y;//propertiesTableFrame.Height + propertiesTableFrame.Y + Padding;
            addCartFrame.Width = 200;
            addCartFrame.Height = 60;
            _cartButton.Frame = addCartFrame;
            detailViewFrame.Height = addCartFrame.Y + addCartFrame.Height + Padding;
            _detailView.Frame = detailViewFrame;

        }

        #endregion
    }
}