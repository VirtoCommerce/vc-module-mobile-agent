using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using CoreGraphics;
using Xamarin.Themes;

namespace VirtoCommerce.Mobile.iOS.UI
{
    public class ImageSlider : UIControl
    {
        private List<UIImageView> _imageViews = new List<UIImageView>();
        private List<UIImage> _images = new List<UIImage>();
        private UIScrollView _scrollView;
        private UIPageControl _pageControl;

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            var scrollFrame = _scrollView.Frame;
            scrollFrame.X = 0;
            scrollFrame.Y = rect.Y;
            scrollFrame.Width = rect.Width;
            scrollFrame.Height = rect.Height - 40;
            _scrollView.Frame = scrollFrame;
            //set position images
            for (int i = 0; i < _imageViews.Count; i++)
            {
                var imgF = _imageViews[i].Frame;
                imgF.X = i * rect.Width;
                imgF.Height = scrollFrame.Height;
                _imageViews[i].Frame = imgF;
            }
            _scrollView.ContentSize = new CGSize(_scrollView.Frame.Width * _images.Count, scrollFrame.Height);
            var pF = _pageControl.Frame;
            pF.Width = Frame.Width;
            pF.Height = 40;
            pF.X = 0;
            pF.Y = scrollFrame.Height;
            _pageControl.Frame = pF;
            PrepareImages();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _scrollView.Scrolled -= Scroll;
            _pageControl.TouchDown -= SetManualPage;

        }

        public void AddImage(UIImage image)
        {
            if (_scrollView == null)
            {
                _scrollView = new UIScrollView()
                {
                    BackgroundColor = UIColor.FromPatternImage(GridlockTheme.SharedTheme.ViewBackground)
                };
                _scrollView.Scrolled += Scroll;
                _scrollView.ShowsHorizontalScrollIndicator = false;
                _pageControl = new UIPageControl()
                {
                    BackgroundColor = UIColor.FromPatternImage(GridlockTheme.SharedTheme.ViewBackground),
                    CurrentPageIndicatorTintColor = UIColor.Blue,
                    PageIndicatorTintColor = Consts.ColorBlack,
                };
                _pageControl.ValueChanged += SetManualPage;
                AddSubviews(_scrollView, _pageControl);
            }
            //var start = _images.Sum(x => x.Size.Width);
            var uiImage = new UIImageView();
            _scrollView.Add(uiImage);
            _imageViews.Add(uiImage);
            _images.Add(image);
            _pageControl.Pages = _imageViews.Count;
            _pageControl.CurrentPage = 0;
            Draw(new CGRect(Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height));
        }
        private void SetManualPage(object s, EventArgs e)
        {
            _scrollView.ContentOffset = new CGPoint(_pageControl.CurrentPage * _scrollView.Frame.Width, 0);
        }
        private void Scroll(object s, EventArgs e)
        {
            var offset = (_scrollView.ContentOffset.X / (_scrollView.Frame.Width / 2));
            if (offset < 0)
                offset = 0;
            _pageControl.CurrentPage = (int)offset;
        }
        private void PrepareImages()
        {
            for (int i = 0; i < _images.Count; i++)
            {
                var img = _images[i];
                if (_scrollView.Frame.Width!= 0 && img.Size.Width > _scrollView.Frame.Width)
                {
                    var scale = _scrollView.Frame.Width / img.Size.Width;
                    img = img.Scale(new CGSize(img.Size.Width * scale, img.Size.Height * scale));
                }
                if (_scrollView.Frame.Height != 0 &&  img.Size.Height > _scrollView.Frame.Height)
                {
                    var scale = _scrollView.Frame.Height / img.Size.Height;
                    img = img.Scale(new CGSize(img.Size.Width * scale, img.Size.Height * scale));
                }
                _imageViews[i].Image = img;
                if (_scrollView.Frame.Width != 0 && _scrollView.Frame.Height != 0)
                {
                    _imageViews[i].Center = new CGPoint(_scrollView.Frame.Width / 2 + _scrollView.Frame.Width * i, _scrollView.Frame.Height / 2);
                    _imageViews[i].SizeToFit();
                }
            }
        }
    }
}