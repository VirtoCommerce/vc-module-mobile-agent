using UIKit;

namespace VirtoCommerce.Mobile.iOS.Controls
{
    public class UISimpleCheckBoxControl : UIView
    {

        private UIImage _checkedImg;
        private UIImage _unchekedImg;
        private bool _checked;
        public UISimpleCheckBoxControl()
        {
            Initialize();
        }
        public bool Checked
        {
            set
            {
                _checked = value;
                BackgroundColor = value ? UIColor.FromPatternImage(_checkedImg) : UIColor.FromPatternImage(_unchekedImg);
            }
            get
            {
                return _checked;
            }
        }
        void Initialize()
        {
            _checkedImg = UIImage.FromFile("checked_cb.png").Scale(new CoreGraphics.CGSize(25, 25));
            _unchekedImg = UIImage.FromFile("unchecked_cb.png").Scale(new CoreGraphics.CGSize(25, 25));
            BackgroundColor = UIColor.FromPatternImage(_unchekedImg);
        }
    }
}