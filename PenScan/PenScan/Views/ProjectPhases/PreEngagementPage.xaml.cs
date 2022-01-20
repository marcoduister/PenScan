using PenScan.ViewModels.ProjectPhases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PenScan.Views.ProjectPhases
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreEngagementPage : ContentPage
    {
        public PreEngagementPage()
        {
            InitializeComponent();
            BindingContext = new PreEngagementViewModel();
        }
    }
}