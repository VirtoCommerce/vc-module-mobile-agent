
using System;
using System.Drawing;
using System.Collections.Generic;

#if __UNIFIED__
using Foundation;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif
using Xamarin.Themes;

namespace VirtoCommerce.Mobile.iOS.UI.Products
{
	public class FashionSource : UITableViewSource
	{
		const float RowHeight = 110f;

		List<KeyValuePair<string, string>> data;

		public FashionSource (List<KeyValuePair<string, string>> data)
		{
			this.data = data;
		}

		#if __UNIFIED__
		public override nint NumberOfSections (UITableView tableView)
		#else
		public override int NumberOfSections (UITableView tableView)
		#endif
		{
			return 1;
		}

		#if __UNIFIED__
		public override nint RowsInSection (UITableView tableview, nint section)
		#else
		public override int RowsInSection (UITableView tableview, int section)
		#endif
		{
			return data.Count;
		}
		
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (ProductCell.Key) as UITableViewCell;
			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Subtitle, ProductCell.Key);

			var item = data[indexPath.Row];

			cell.TextLabel.Text = item.Key;
			cell.DetailTextLabel.Text = item.Value;

			cell.TextLabel.Font = UIFont.FromName("Helvetica Neue", 14);
			cell.DetailTextLabel.Font = UIFont.FromName("Helvetica Neue", 12);
			cell.DetailTextLabel.Lines = 0;

			var backgroundView = GetBackgroundView(indexPath.Row);

			if (backgroundView != null)
				cell.BackgroundView = backgroundView;
			
			return cell;
		}

		#if __UNIFIED__
		public override nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		#else
		public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		#endif
		{
			return RowHeight;
		}

		UIView GetBackgroundView(int index) 
		{
			if (index == data.Count - 1)
				return null;

			var imageView = new UIImageView(GridlockTheme.SharedTheme.TableCellBackground);
			imageView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;

			return imageView;
		}
	}
}

