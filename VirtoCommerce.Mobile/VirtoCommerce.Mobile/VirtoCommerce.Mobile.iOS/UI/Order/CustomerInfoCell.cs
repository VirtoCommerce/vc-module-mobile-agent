using CoreAnimation;
using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.iOS.UI.Order
{
   public  class CustomerInfoCell: UITableViewCell
    {
        public const string CellId = "CustomerInfoCell";
        public const float CellHeight = 40;
        public string[] Headers {private set; get; }
        private ICollection<UITextField> _valueFields;
        private ICollection<KeyValuePair<string, Customer>> _data;
        private ICollection<CALayer> _bottomLayers { set; get; }
        public CustomerInfoCell(IntPtr handle) : base(handle)
        {
        }

        public void UpdateCell(ICollection<KeyValuePair<string, Customer>> data)
        {
            _data = data;
            InitView();
        }

        private void InitView()
        {
            if (_valueFields != null)
            {
                foreach (var field in _valueFields)
                {
                    field.EditingChanged -= ValueTextChange;
                }
                _valueFields.Clear();
            }
            else
            {
                _valueFields = new List<UITextField>();
            }
            if (_bottomLayers != null)
            {
                foreach (var bottomLayer in _bottomLayers)
                {
                    bottomLayer.RemoveFromSuperLayer();
                }
                _bottomLayers.Clear();
            }
            else
            {
                _bottomLayers = new List<CALayer>();
            }
            for (int i = 0; i < _data.Count; i++)
            {
                var valueField = new UITextField
                {
                    BorderStyle = UITextBorderStyle.None
                };
                valueField.EditingChanged += ValueTextChange;
                valueField.Tag = i;
                valueField.Placeholder = _data.ElementAt(i).Key;
                _valueFields.Add(valueField);
                _bottomLayers.Add(new CALayer());
                valueField.Layer.AddSublayer(_bottomLayers.ElementAt(i));
                Add(valueField);
            }
        }

        private void UpdateValue(int id)
        {
            var header = _data.ElementAt(id).Key;
            if (header == "Email")
            {
                _data.ElementAt(id).Value.Email = _valueFields.ElementAt(id).Text;
            }
            if (header == "First name")
            {
                _data.ElementAt(id).Value.FirstName = _valueFields.ElementAt(id).Text;
            }
            if (header == "Last name")
            {
                _data.ElementAt(id).Value.LastName = _valueFields.ElementAt(id).Text;
            }
            if (header == "Company name")
            {
                _data.ElementAt(id).Value.CompanyName = _valueFields.ElementAt(id).Text;
            }
            if (header == "Address")
            {
                _data.ElementAt(id).Value.Address = _valueFields.ElementAt(id).Text;
            }
            if (header == "Apt, suite etc.")
            {
                _data.ElementAt(id).Value.Apt = _valueFields.ElementAt(id).Text;
            }
            if (header == "City")
            {
                _data.ElementAt(id).Value.City = _valueFields.ElementAt(id).Text;
            }
            if (header == "Country")
            {
                _data.ElementAt(id).Value.Coutry = _valueFields.ElementAt(id).Text;
            }
            if (header == "Postal code")
            {
                _data.ElementAt(id).Value.PostalCode = _valueFields.ElementAt(id).Text;
            }
            if (header == "Phone")
            {
                _data.ElementAt(id).Value.Phone = _valueFields.ElementAt(id).Text;
            }
        }


        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            if (_valueFields == null)
                return;
            //
            for (int i = 0; i < _valueFields.Count; i++)
            {
                var valueField = _valueFields.ElementAt(i);
                var valueFrame = valueField.Frame;
                valueFrame.Width = ContentView.Frame.Width / _valueFields.Count - 20;
                valueFrame.Height = CellHeight;
                valueFrame.X = i * valueFrame.Width + 20 * i;
                valueFrame.Y = 0;
                valueField.Frame = valueFrame;
                var bottomLayer = _bottomLayers.ElementAt(i);
                bottomLayer.Frame = new CGRect(0, valueField.Frame.Height - 2, valueField.Frame.Width, 2);
                bottomLayer.BackgroundColor = Consts.ColorBlack.CGColor;
            }
        }

        private void ValueTextChange(object sender, EventArgs e)
        {
            UpdateValue((int)((UITextField)sender).Tag);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (_valueFields != null)
            {
                foreach (var field in _valueFields)
                {
                    field.EditingChanged -= ValueTextChange;
                }
            }
        }
    }
}