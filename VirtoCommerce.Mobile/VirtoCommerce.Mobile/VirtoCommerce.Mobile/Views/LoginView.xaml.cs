using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Mobile.ViewModels;
using Xamarin.Forms;

namespace VirtoCommerce.Mobile.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView(LoginViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
