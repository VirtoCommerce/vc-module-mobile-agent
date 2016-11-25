using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using VirtoCommerce.Mobile.Model;

namespace VirtoCommerce.Mobile.iOS.UI.Order
{
   public  class CustomerInfoCell: UITableViewCell
    {
        public const string CellId = "CustomerInfoCell";
        public const float CellHeight = 40;
        public string Header {private set; get; }
        public Customer Value { private set; get; }
        private UILabel _headerLabel { set; get; }
        private UITextField _valueField { set; get; }
        public CustomerInfoCell()
        {
            InitView();
        }
        public CustomerInfoCell(IntPtr handle) : base(handle)
        {
            InitView();
        }

        public void UpdateCell(string header, Customer value)
        {
            Header = header;
            Value = value;
            SetValue();
            _headerLabel.Text = header;
            _valueField.Placeholder = header;
        }

        private void InitView()
        {
            _headerLabel = new UILabel
            {
                Font = UIFont.FromName(Consts.FontNameRegular, Consts.FontSizeRegular),
                TextColor = Consts.ColorBlack
            };
            _headerLabel.Text = Header;
            Add(_headerLabel);
            _valueField = new UITextField()
            {
                BorderStyle = UITextBorderStyle.Bezel
            };
            _valueField.EditingChanged += ValueTextChange;
            Add(_valueField);
        }

        private void SetValue()
        {
            if (Header == "Email")
            {
                Value.Email = _valueField.Text;
            }
            if (Header == "First name")
            {
                Value.FirstName = _valueField.Text;
            }
            if (Header == "Last name")
            {
                Value.LastName = _valueField.Text;
            }
            if (Header == "Company name")
            {
                Value.CompanyName = _valueField.Text;
            }
            if (Header == "Address")
            {
                Value.Address = _valueField.Text;
            }
            if (Header == "Apt, suite etc.")
            {
                Value.Apt = _valueField.Text;
            }
            if (Header == "City")
            {
                Value.City = _valueField.Text;
            }
            if (Header == "Country")
            {
                Value.Coutry = _valueField.Text;
            }
            if (Header == "Postal code")
            {
                Value.PostalCode = _valueField.Text;
            }
            if (Header == "Phone")
            {
                Value.Phone = _valueField.Text;
            }
        }


        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            var headerFrame = _headerLabel.Frame;
            headerFrame.Height = CellHeight / 2;
            headerFrame.Width = ContentView.Frame.Width;
            headerFrame.X = 0;
            headerFrame.Y = 0;
            _headerLabel.Frame = headerFrame;
            //
            var valueFrame = _valueField.Frame;
            valueFrame.Width = ContentView.Frame.Width;
            valueFrame.Height = CellHeight / 2;
            valueFrame.X = 0;
            valueFrame.Y = headerFrame.Y + headerFrame.Height;
            _valueField.Frame = valueFrame;
        }

        private void ValueTextChange(object sender, EventArgs e)
        {
            SetValue();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _valueField.EditingChanged -= ValueTextChange;
        }
    }
}