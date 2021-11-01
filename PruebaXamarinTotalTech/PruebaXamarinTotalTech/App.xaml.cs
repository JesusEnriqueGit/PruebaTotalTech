using PruebaXamarinTotalTech.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaXamarinTotalTech
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MovieListView());
           
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
