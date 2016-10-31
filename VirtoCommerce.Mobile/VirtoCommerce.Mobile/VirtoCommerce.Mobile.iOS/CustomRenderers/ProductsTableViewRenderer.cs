using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using UIKit;
using VirtoCommerce.Mobile.CustomControls;
using VirtoCommerce.Mobile.iOS.UI.Products;
using VirtoCommerce.Mobile.Model;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Themes;

[assembly:ExportRenderer(typeof(ProductsTableView),typeof(UIView))]
namespace VirtoCommerce.Mobile.iOS.CustomRenderers
{
    public class ProductsTableViewRenderer:ViewRenderer<ProductsTableView, UIView>
    {
        private GridView _gridView { set; get; }

        protected override void OnElementChanged(ElementChangedEventArgs<ProductsTableView> e)
        {
            base.OnElementChanged(e);
            var rectangle = new RectangleF();
            rectangle.X = (float)Control.Bounds.X;
            rectangle.Y = (float)Control.Bounds.Y;
            rectangle.Location = new PointF(rectangle.X, rectangle.Y);
            rectangle.Height = (float)Control.Bounds.Height;
            rectangle.Width = (float)Control.Bounds.Width;
            rectangle.Size = new SizeF(rectangle.Width, rectangle.Height);
            _gridView = new GridView(rectangle)
            {
                AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth
            };
            SetNativeControl(_gridView);
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var view = (ProductsTableView)sender;
            SetGridView(view.Items);
        }

        private void SetGridView(ICollection<Product> product)
        {
            //_gridView.
            var cell = new ProductCell();
            _gridView.AddTile(new ProductCell());
        }
    }
}
