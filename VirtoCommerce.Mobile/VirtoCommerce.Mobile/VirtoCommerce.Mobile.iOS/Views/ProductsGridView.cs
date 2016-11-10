using MvvmCross.iOS.Views;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using System.Linq;
using Xamarin.Themes;
using System.ComponentModel;
using MvvmCross.Platform.WeakSubscription;
using VirtoCommerce.Mobile.Model;
using VirtoCommerce.Mobile.ViewModels;
using VirtoCommerce.Mobile.iOS.UI.Products;
using CoreGraphics;
using System.Drawing;
using MvvmCross.Binding.BindingContext;
using Foundation;
using VirtoCommerce.Mobile.iOS.UI;
using VirtoCommerce.Mobile.iOS.Helpers;

namespace VirtoCommerce.Mobile.iOS.Views
{
    public class ProductsGridView : MvxViewController, IGridViewDelegate
    {

        private IDisposable _subscribeProductListChange;
        private bool _showFilters = false;

        public ProductsGridView() : base(null, null)
        {
            Title = "Products";

        }
        public override void ViewDidLoad()
        {
            
            base.ViewDidLoad();
            CreateView();
            var set = this.CreateBindingSet<ProductsGridView, ProductsGridViewModel>();
            set.Bind(_busyContainer).For(x => x.Hidden).To(x => x.HideBusy);
            set.Bind(_busyLabel).For(x=>x.Text).To(x => x.Status);
            set.Apply();
            _subscribeProductListChange = ((INotifyPropertyChanged)ViewModel).WeakSubscribe<ICollection<Product>>("Products", (s, e) =>
            {
                UpdateListProducts();
            });
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            UpdateListProducts();
        }

        private void UpdateListProducts()
        {
            if (_listProducts != null)
                _listProducts.RemoveFromSuperview();
            _listProducts = new GridView((RectangleF)View.Bounds)
            {
                AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth,
                Delegate = this,
                BackgroundColor = Consts.ColorGrayLight
            };
            Add(_listProducts);
            foreach (var product in ((ProductsGridViewModel)ViewModel).Products)
            {
                var cell = new ProductCell(CartAdd);
                cell.Bind(product);
                _listProducts.AddTile(cell);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (_subscribeProductListChange != null)
            {
                _subscribeProductListChange.Dispose();
                _subscribeProductListChange = null;
            }
        }
        public void TileSelected(GridView gridView, int index)
        {
            ((ProductsGridViewModel)ViewModel).ShowProductDetail(index);
        }
        private void CartAdd(Product product)
        {
            ((ProductsGridViewModel)ViewModel).AddToCart(product);
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            var tabSupperView = ((UINavigationController)ParentViewController).ParentViewController as UITabBarController;
            if (_listProducts != null)
            {
                if (tabSupperView != null)
                {
                    var frame = _listProducts.Frame;
                    frame.Height = View.Frame.Height - tabSupperView.TabBar.Frame.Height;
                    _listProducts.Frame = frame;
                }
            }
            //filter size
            var filtesViewFrame = _filterView.Frame;
            filtesViewFrame.Width = 300;
            filtesViewFrame.Height = tabSupperView != null ? View.Frame.Height - tabSupperView.TabBar.Frame.Height : View.Frame.Height;
            filtesViewFrame.Y = 0;
            filtesViewFrame.X = View.Frame.Width - filtesViewFrame.Width;
            _filterView.Frame = filtesViewFrame;
            //overlay
            var overlayFrame = View.Frame;
            overlayFrame.Y = 0;
            _overlayView.Frame = overlayFrame;
        }

        #region View
        private GridView _listProducts;
        private UIActivityIndicatorView _busy;
        private UIView _busyContainer;
        private UILabel _busyLabel;
        private UIView _filterView;
        private UIView _overlayView;
        private void CreateView()
        {
            View = new UIView(new CGRect(0, 0, 600, 600))
            {
                ContentMode = UIViewContentMode.ScaleToFill,
                BackgroundColor = Consts.ColorMainBg,
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight,
            };
            
            _busyContainer = new UIView(new CGRect(0, 0, 600, 600))
            {
                BackgroundColor = UIColor.FromRGBA(0, 0, 0, 127),
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight,
                AutosizesSubviews = true
            };
            _busy = new UIActivityIndicatorView(new CGRect(0, 0, 30, 30))
            {
                HidesWhenStopped = false,
                Center = new CGPoint(300, 300),
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight,
            };
            _busy.StartAnimating();
            _busyLabel = new UILabel(new CGRect(0, 0, 600, 30))
            {
                TextAlignment = UITextAlignment.Center,
                Center = new CGPoint(300, 330),
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight,
                TextColor = UIColor.White
            };
            _busyContainer.AddSubviews(_busy, _busyLabel);
            Add(_busyContainer);
            //filter
            _filterView = new UIView()
            {
                BackgroundColor = UIColor.White,
            };
            NavigationItem.RightBarButtonItem = new UIBarButtonItem("Filters", UIBarButtonItemStyle.Plain, ShowHideFilter);
            //overlay
            _overlayView = new UIView()
            {
                BackgroundColor = UIColor.FromRGBA(0, 0, 0, 150)
            };
        }
        private void ShowHideFilter(object s, EventArgs e)
        {
            if (_showFilters)
            {
                
                _filterView.SlideHorizontalyRight(false, onFinished: () => { _filterView.RemoveFromSuperview(); _overlayView.RemoveFromSuperview(); });
            }
            else
            {
                Add(_overlayView);
                Add(_filterView);
                _filterView.SlideHorizontalyRight(true);
            }
            _showFilters = !_showFilters;
        }
        #endregion
    }

}
