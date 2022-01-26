using PenScan.ViewModels.ThreatModeling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PenScan.Views.ThreatModeling
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThreatModelingPage : ContentPage
    {
        public ThreatModelingPage(int projectId, int projectFaseId)
        {
            InitializeComponent();
            BindingContext = new ThreatModelingViewModel(projectId, projectFaseId);
        }
    }
}