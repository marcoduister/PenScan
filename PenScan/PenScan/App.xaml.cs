using PenScan.Services;
using PenScan.Views;
using PenScan.Views.Access;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PenScan
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new Startpage());
            //MainPage = new AppShell();
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
