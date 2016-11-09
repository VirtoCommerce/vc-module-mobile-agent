using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using VirtoCommerce.Mobile.iOS.UI;
using CoreGraphics;

namespace VirtoCommerce.Mobile.iOS.Helpers
{
    public static class UICreator
    {

        public static UIButton CreateSimpleButton(string title)
        {
            var button = new UIButton(UIButtonType.RoundedRect);
            button.SetTitle(title, UIControlState.Normal);
            button.SetTitleColor(UIColor.White, UIControlState.Normal);
            button.TitleLabel.Font = UIFont.FromName(Consts.FontNameBold, Consts.ButtonFontSize);
            button.BackgroundColor = Consts.ColorMain;
            button.Layer.CornerRadius = Consts.ButtonCornerRadius;
            return button;
        }
        public static UIButton CreateSimpleButtonWithoutBg(string title)
        {
            var button = new UIButton(UIButtonType.System);
            button.SetTitle(title, UIControlState.Normal);
            button.SetTitleColor(Consts.ColorMain, UIControlState.Normal);
            button.TitleLabel.Font = UIFont.FromName(Consts.FontNameBold, Consts.ButtonFontSize);
            return button;
        }
        public static UIButton CreateImageButtonWithText(string title, string image)
        {
            var button = new UIButton(UIButtonType.RoundedRect);
            button.BackgroundColor = Consts.ColorMain;
            button.Layer.CornerRadius = Consts.ButtonCornerRadius;
            button.SetTitleColor(Consts.ButtonTextColor, UIControlState.Normal);
            button.SetTitle(title, UIControlState.Normal);
            button.TitleLabel.Font = UIFont.FromName(Consts.FontNameBold, Consts.ButtonFontSize);
            button.SetImage(UIImage.FromFile(image).Scale(new CGSize(Consts.ButtonIconSize, Consts.ButtonIconSize)), UIControlState.Normal);
            button.TitleEdgeInsets = new UIEdgeInsets(0, 25, 0, 0);
            button.ImageEdgeInsets = new UIEdgeInsets(-5, 0, 0, 0);
            button.TintColor = Consts.ButtonTextColor;
            return button;
        }
        public static UIButton CreateIconButton(string icon)
        {
            var button = new UIButton(UIButtonType.System);
            button.SetImage(UIImage.FromFile(icon), UIControlState.Normal);
            return button;
        }
    }
}