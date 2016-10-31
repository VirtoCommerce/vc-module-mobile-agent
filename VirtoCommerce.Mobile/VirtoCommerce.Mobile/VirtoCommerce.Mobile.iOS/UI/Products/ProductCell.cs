
using System;
using System.Drawing;
using VirtoCommerce.Mobile.Model;

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
	public class ProductCell : UITableViewCell
	{
		private int _dataCount;
		public const float RowHeight = 110f;

		private UIView _statusView { get; set; }
		private UIImageView _modelImageView { get; set; }
		private UIImageView _backgroundImageView { get; set; }		
		private UITableView _tableView { get; set; }
		private UILabel _likesLabel { get; set; }
		private UILabel _commentsLabel { get; set; }
		private UILabel _titleLabel { get; set; }

		private UIButton _likeButton { get; set; }
		private UIButton _shareButton { get; set; }

		private UIImageView _likesView { get; set; }
		private UIImageView _commentsView { get; set; }

		Product data;

		public static readonly NSString Key = new NSString ("FasionCell");
		
		public ProductCell() : base (UITableViewCellStyle.Default, Key)
		{
			InitSubviews();
			ApplyStyles();
		}

		void InitSubviews()
		{
			_modelImageView = new UIImageView(new RectangleF(5, 5, 231, 200));
			BackgroundView = new UIImageView(new RectangleF(0, 0, 241, 549));
			
			AddSubviews(BackgroundView, _modelImageView);
			
			_statusView = new UIView(new RectangleF(0, 213, 241, 71));
			
			_titleLabel = new UILabel(new RectangleF(8, 5, 224, 22));

			_likesLabel = new UILabel(new RectangleF(182, 42, 21, 21)) {
				TextColor = UIColor.DarkGray,
				Font = UIFont.FromName("HelveticaNeue-Medium", 16)				
			};

			_commentsLabel = new UILabel(new RectangleF(223, 42, 16, 21)) {
				TextColor = UIColor.DarkGray,
				Font = UIFont.FromName("HelveticaNeue-Medium", 16)	
			};
			
			var dotLabel = new UILabel(new RectangleF(38, 38, 17, 21)) {
				Text = ".",
				Font = UIFont.FromName("HelveticaNeue-CondensedBold", 17),
				TextAlignment = UITextAlignment.Center,
				TextColor = UIColor.DarkGray,
				BaselineAdjustment = UIBaselineAdjustment.AlignCenters
			};
			
			_likeButton = new UIButton() {
				Frame = new RectangleF(3, 40, 44, 25),
				Font = UIFont.FromName("HelveticaNeue-Medium", 15)
			};
			
			_likeButton.SetTitle("Like", UIControlState.Normal);
			_likeButton.SetTitleColor(UIColor.FromRGB(107, 162, 233), UIControlState.Normal);			
			
			_shareButton = new UIButton(){
				Frame = new RectangleF(52, 40, 47, 25),
				Font = UIFont.FromName("HelveticaNeue-Medium", 15)
				
			};
			
			_shareButton.SetTitle("Share", UIControlState.Normal);
			_shareButton.SetTitleColor(UIColor.FromRGB(107, 162, 233), UIControlState.Normal);
			
			_likesView = new UIImageView(new RectangleF(155, 40, 25, 25)) {
				Image = GridlockTheme.SharedTheme.LikesIcon,
				ContentMode = UIViewContentMode.Center
			};
			
			_commentsView = new UIImageView(new RectangleF(197, 40, 25, 25)) {
				Image = GridlockTheme.SharedTheme.CommentsIcon,
				ContentMode = UIViewContentMode.Center
			};

			_backgroundImageView = new UIImageView(UIImage.FromFile("card-details.png"));

			_statusView.AddSubviews(_titleLabel, _likesLabel, _commentsLabel, _likeButton, dotLabel, _shareButton, _likesView, _commentsView);

			_tableView = new UITableView(new RectangleF(2, 283, 237, 266), UITableViewStyle.Plain) {
				SeparatorStyle = UITableViewCellSeparatorStyle.SingleLineEtched,
				ScrollEnabled = false
			};

			Add (_statusView);
			Add (_tableView);
		}

		void ApplyStyles()
		{
			BackgroundColor = UIColor.White;
		}

		public void Bind(Product data)
		{
			_dataCount = data.Mentions.Count;

			this.data = data;

			_titleLabel.Text = "Spring 2012 Collection";
			_commentsLabel.Text = data.Comments.ToString();
			_likesLabel.Text = data.Likes.ToString();

			_tableView.Source = new FashionSource(data.Mentions);
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

			var imageFrame = _modelImageView.Frame;
			imageFrame.Size = data.TitleImage.Size;
			_modelImageView.Frame = imageFrame;
			_modelImageView.Image = data.TitleImage;			

			var statusFrame = _statusView.Frame;
			statusFrame.Y = 2 * imageFrame.Y + imageFrame.Height;
			_statusView.Frame = Rectangle.Round((RectangleF)statusFrame);

			_tableView.ReloadData();

			var tableFrame = _tableView.Frame;
			tableFrame.Y = statusFrame.Y + statusFrame.Height;
			tableFrame.Height = _dataCount * RowHeight;
			_tableView.Frame = Rectangle.Round((RectangleF)tableFrame);

			var cellFrame = Frame;
			cellFrame.Height = tableFrame.Y + tableFrame.Height + (tableFrame.Height > 0 ? 5 : 2);
			cellFrame.Width = 241;
			Frame = Rectangle.Round((RectangleF)cellFrame);

			Superview.Superview.LayoutSubviews();
		}
	}
}

