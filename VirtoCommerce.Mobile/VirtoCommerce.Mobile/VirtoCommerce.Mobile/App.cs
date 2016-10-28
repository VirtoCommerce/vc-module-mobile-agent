using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtoCommerce.Mobile.Services;
using VirtoCommerce.Mobile.ViewModels;
using VirtoCommerce.Mobile.Views;
using Xamarin.Forms;

namespace VirtoCommerce.Mobile
{
    public class App : Application
    {
        public static UnityContainer UnityContainer;
        public App()
        {
            // The root page of your application
            InitUnity();
            if (!UnityContainer.Resolve<IUserManagerService>().IsLogin())
            {
                MainPage = UnityContainer.Resolve<LoginView>();
            }
            else
            {
                MainPage = UnityContainer.Resolve<MainView>(); ;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        /// <summary>
        /// Resolve DI
        /// </summary>
        private void InitUnity()
        {
            
            UnityContainer = new UnityContainer();
            UnityContainer.RegisterType<IUserManagerService, MockUserManagerService>();
            //login
            UnityContainer.RegisterType(typeof(LoginView));
            UnityContainer.RegisterType(typeof(LoginViewModel));
            //products
            UnityContainer.RegisterType(typeof(ProductsGridView));
            UnityContainer.RegisterType(typeof(ProductsGridViewModel));
            //main view
            UnityContainer.RegisterType(typeof(MainView));
            //root view
            UnityContainer.RegisterType(typeof(RootView));
            //menu view
            UnityContainer.RegisterType(typeof(MenuView));
            //navigation service
            UnityContainer.RegisterType<INavigationService, NavigationService>();

        }
    }
}
