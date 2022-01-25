using PenScan.ViewModels.Scan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PenScan.Views.Scan
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Scanner : ContentPage
    {
        public Scanner(int _projectId)
        {
            BindingContext = new ScannerViewModel(_projectId);
            InitializeComponent();
        }
    }
}