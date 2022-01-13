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
            List<string> projectList = new List<string>();
            projectList.Add("digitalnet");
            projectList.Add("intercom");
            ProjectList.ItemsSource = projectList;
        }
    }
}