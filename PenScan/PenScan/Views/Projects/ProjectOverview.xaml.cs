using PenScan.ViewModels;
using PenScan.ViewModels.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PenScan.Views.Projects
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectOverview : ContentPage
    {
        ProjectOverviewViewModel viewModel;
        public ProjectOverview()
        {
            InitializeComponent();
            BindingContext = new ProjectOverviewViewModel();
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var viewModel = (ProjectOverviewViewModel)BindingContext;
            if (viewModel.refresh.CanExecute(null))
                viewModel.refresh.Execute(null);
        }

    }
}