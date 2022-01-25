using PenScan.Views.ProjectPhases;
using PenScan.Views.Scan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PenScan.Views.Access
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Startpage : ContentPage
    {
        public Startpage()
        {
            InitializeComponent();
        }

        private void LoginreRedirectButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        private void RegisterRedirectButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new RegistrationPage());
        }

        private void scanner_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new PreEngagementPage(1));
        }
    }
}