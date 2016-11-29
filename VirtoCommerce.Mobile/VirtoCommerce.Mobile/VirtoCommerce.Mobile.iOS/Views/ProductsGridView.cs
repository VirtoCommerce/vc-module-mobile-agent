using MvvmCross.iOS.Views;
using System;
using System.Collections.Generic;
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
using VirtoCommerce.Mobile.iOS.UI;
using VirtoCommerce.Mobile.iOS.Helpers;
using VirtoCommerce.Mobile.iOS.UI.Filters;

namespace VirtoCommerce.Mobile.iOS.Views
{
    public class ProductsGridView : MvxViewController, IGridViewDelegate
    {

        private IDisposable _subscribeProductListChange;
        private bool _showFilters = false;
        private int _padding = 10;
        public ProductsGridViewModel ProductsGridViewModel { get { return ViewModel as ProductsGridViewModel; } }
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
            set.Bind(_busyLabel).For(x => x.Text).To(x => x.Status);
            _subscribeProductListChange = ((INotifyPropertyChanged)ViewModel).WeakSubscribe<ICollection<Product>>("Products", (s, e) =>
            {
                UpdateListProducts();
            });
            set.Apply();
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            if (ProductsGridViewModel.Products?.Count > 0)
            {
                UpdateListProducts();
            }
        }

        private void UpdateListProducts()
        {
            if (_listProducts != null)
                _listProducts.RemoveFromSuperview();
            _listProducts = new GridView((RectangleF)View.Bounds)
            {
                AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth,
                Delegate = this,
                BackgroundColor = Consts.ColorMainBg
            };
            Add(_listProducts);
            foreach (var product in ((ProductsGridViewModel)ViewModel).Products)
            {
                var cell = new ProductCell(CartAdd);
                cell.Bind(product);
                _listProducts.AddTile(cell);
            }
            if (_showFilters)
            {
                View.BringSubviewToFront(_overlayView);
                View.BringSubviewToFront(_filterView);
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
            _clearAll.TouchDown -= ClearAllFilters;
            _applyFilters.TouchDown -= ApplyFilters;
        }
        public void TileSelected(GridView gridView, int index)
        {
            ProductsGridViewModel.ShowProductDetail(index);
        }
        private void CartAdd(Product product)
        {
            ProductsGridViewModel.AddToCart(product);
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
                    frame.Height = View.Frame.Height - tabSupperView.TabBar.Frame.Height - 30;
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
            //clear all
            var clearAllFrame = _clearAll.Frame;
            clearAllFrame.Width = 120;
            clearAllFrame.Height = 25;
            _clearAll.Frame = clearAllFrame;
            _clearAll.Center = new CGPoint(filtesViewFrame.Width / 2 - _padding / 2 - clearAllFrame.Width / 2, filtesViewFrame.Height - clearAllFrame.Height / 2 - _padding);
            //apply button
            var applyButtonFrame = _applyFilters.Frame;
            applyButtonFrame.Width = 120;
            applyButtonFrame.Height = 25;
            _applyFilters.Frame = applyButtonFrame;
            _applyFilters.Center = new CGPoint(filtesViewFrame.Width / 2 + _padding / 2 + applyButtonFrame.Width / 2, filtesViewFrame.Height - applyButtonFrame.Height / 2 - _padding);
            //filter items 
            var filterListFrame = filtesViewFrame;
            filterListFrame.X = 0;
            filtesViewFrame.Height = filtesViewFrame.Height - clearAllFrame.Height - _padding * 2;
            _filtersList.Frame = filterListFrame;
            //overlay
            var overlayFrame = View.Frame;
            overlayFrame.Y = 0;
            _overlayView.Frame = overlayFrame;
        }

        private Dictionary<string, List<FilterItemViewModel>> GetFilters()
        {
            var result = new Dictionary<string, List<FilterItemViewModel>>();
            var filters = ProductsGridViewModel.Filters;
            foreach (var filter in filters)
            {
                result.Add(filter.Header, filter.Items.Select(x => new FilterItemViewModel { FilterItem = x, Filter = filter }).ToList());
            }
            return result;
        }



        #region View
        private GridView _listProducts;
        private UIActivityIndicatorView _busy;
        private UIView _busyContainer;
        private UILabel _busyLabel;
        private UIView _filterView;
        private UIView _overlayView;
        private UITableView _filtersList;
        private UIButton _clearAll;
        private UIButton _applyFilters;
        private UIBarButtonItem _filterOpenButton;

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
            _filterOpenButton = new UIBarButtonItem("Filters", UIBarButtonItemStyle.Bordered, ShowHideFilter);
            NavigationItem.RightBarButtonItem = _filterOpenButton;
            //overlay
            _overlayView = new UIView()
            {
                BackgroundColor = UIColor.FromRGBA(0, 0, 0, 150)
            };
            _overlayView.AddGestureRecognizer(new UITapGestureRecognizer(() =>
            {
                ShowHideFilter(_overlayView, new EventArgs());
            }));
            //table filters
            _filtersList = new UITableView(new RectangleF(0, 0, 25, 25), UITableViewStyle.Grouped);
            _filtersList.Source = new FilterSource(GetFilters());
            _filtersList.RowHeight = FilterCell.CellHeight;
            _filtersList.BackgroundColor = Consts.ColorMainBg;
            _filtersList.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            _filtersList.ScrollEnabled = true;
            _filterView.Add(_filtersList);
            //clear all filters
            _clearAll = UICreator.CreateSimpleButton("Clear all");
            _clearAll.TouchDown += ClearAllFilters;
            _filterView.Add(_clearAll);
            //apply filters
            _applyFilters = UICreator.CreateSimpleButton("Done");
            _applyFilters.BackgroundColor = Consts.ColorDivider;
            _applyFilters.SetTitleColor(UIColor.White, UIControlState.Normal);
            _applyFilters.Layer.BorderWidth = 0;
            _applyFilters.TouchDown += ApplyFilters;
            _filterView.Add(_applyFilters);
        }

        #region Events
        private void ClearAllFilters(object sender, EventArgs e)
        {
            var source = _filtersList.Source as FilterSource;
            if (source == null)
                return;
            foreach (var key in source.Data.Keys)
            {
                foreach (var item in source.Data[key])
                {
                    item.IsSelect = false;
                }
            }
            _filtersList.ReloadData();
        }

        private void ShowHideFilter(object s, EventArgs e)
        {
            if (!_showFilters)
            {
                NavigationItem.RightBarButtonItem = null;
            }
            else
            {
                NavigationItem.RightBarButtonItem = _filterOpenButton;
            }
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

        private void ApplyFilters(object s, EventArgs e)
        {
            ShowHideFilter(s, e);
            var filterRequest = new FilterRequest();
            var filters = _filtersList.Source as FilterSource;
            foreach (var filter in filters.Data)
            {
                var selectFilters = filter.Value.Where(x => x.IsSelect);
                if (selectFilters.Count() != 0)
                {
                    var f = selectFilters.First().Filter.Copy();
                    f.Items = selectFilters.Select(x => x.FilterItem).ToList();
                    filterRequest.Filters.Add(f);
                }
            }
            ProductsGridViewModel.ApplyFilters(filterRequest);
        }
        #endregion

        #endregion
    }

}
