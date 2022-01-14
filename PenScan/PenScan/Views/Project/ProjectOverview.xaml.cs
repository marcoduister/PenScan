using PenScan.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PenScan.Views.Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectOverview : ContentPage
    {
        public ProjectOverview()
        {
            InitializeComponent();
            BindingContext = new ProjectOverviewViewModel();
        }

        private void AddProjectButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new AddProjectPage());
        }

        private void TemporaryEditButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new EditProjectPage());
        }
    }
}