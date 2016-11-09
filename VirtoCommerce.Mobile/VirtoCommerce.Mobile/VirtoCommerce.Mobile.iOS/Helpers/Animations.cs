using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;

namespace VirtoCommerce.Mobile.iOS.Helpers
{
    public static class Animations
    {
        public static void SlideHorizontalyRight(this UIView view, bool isIn, double duration = 0.3, Action onFinished = null)
        {
            var viewStopFrame = view.Frame;
            var viewStartFrame = view.Frame;
            if (isIn)
            {
                viewStartFrame.X += view.Frame.Width;
                view.Frame = viewStartFrame;
            }
            else
            {
                viewStopFrame = new CGRect(view.Frame.X + view.Frame.Width, view.Frame.Y, view.Frame.Width, view.Frame.Height);
            }
            
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () => {
                    view.Frame = viewStopFrame;
                },
                onFinished
            );
        }
    }
}