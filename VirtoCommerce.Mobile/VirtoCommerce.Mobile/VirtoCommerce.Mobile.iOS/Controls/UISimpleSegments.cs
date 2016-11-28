using System;
using System.Collections.Generic;
using System.Text;
using CoreAnimation;
using CoreGraphics;
using UIKit;
using VirtoCommerce.Mobile.iOS.UI;

namespace VirtoCommerce.Mobile.iOS.Controls
{
    public class UISimpleSegments:UIView
    {
        public List<string> _titleSegments = new List<string>();
        public List<UIView> _segments = new List<UIView>();
        public int CurrentSegment { set; get; }
        public event EventHandler<int> ChangeSegment;
        public UISimpleSegments() {
            BackgroundColor = UIColor.FromRGBA(0, 0, 0, 0);
        }
        public UISimpleSegments(CGRect rect):base(rect)
        {
            BackgroundColor = UIColor.FromRGBA(0, 0, 0, 0);
        }

        public void AddSegment(string title)
        {
            var label = new UILabel(); //UIButton.FromType(UIButtonType.System);
            _titleSegments.Add(title);
            label.Text = title;
            label.Tag = _titleSegments.Count - 1;
            UITapGestureRecognizer tapGisture = new UITapGestureRecognizer(() => {
                CurrentSegment = (int)label.Tag;
                ChangeSegment?.Invoke(this, CurrentSegment);
                Draw(Frame);
            });
            label.UserInteractionEnabled = true;
            label.AddGestureRecognizer(tapGisture);
            var container = new UIView();
            container.Add(label);
            _segments.Add(container);
            Add(container);
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            if (_segments.Count == 0)
            {
                return;
            }
            var segmentSize = Frame.Width / _segments.Count;
            for (int i = 0; i < _segments.Count; i++)
            {
                var segment = _segments[i];
                var segmentFrame = segment.Frame;
                segmentFrame.Width = segmentSize;
                segmentFrame.Height = Frame.Height;
                segmentFrame.X = segmentSize * i;
                segment.Frame = segmentFrame;
                segmentFrame.X = Consts.Padding;
                segment.Subviews[0].Frame = segmentFrame;

                var bottomLine = new CALayer();
                bottomLine.Frame = new CGRect(0, segment.Frame.Height - 2, segment.Frame.Width, 2);
                if (i == CurrentSegment)
                {
                    bottomLine.BackgroundColor = Consts.ColorDark.CGColor;
                    ((UILabel)segment.Subviews[0]).TextColor = Consts.ColorDark;
                }
                else
                {
                    ((UILabel)segment.Subviews[0]).TextColor = Consts.ColorGray;
                    bottomLine.BackgroundColor = Consts.ColorGray.CGColor;
                }
                segment.Layer.AddSublayer(bottomLine);
            }
        }
    }
}
