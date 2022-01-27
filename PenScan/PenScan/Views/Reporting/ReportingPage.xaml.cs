using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PenScan.Views.Reporting
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportingPage : ContentPage
    {
        public ReportingPage()
        {
            InitializeComponent();

            List<string> BasedOnFileList = new List<string>();
            List<string> ToolsFileList = new List<string>();
            List<string> AchievedFileList = new List<string>();

            BasedOnFileList.Add("File 1");
            BasedOnFileList.Add("File 2");
            ToolsFileList.Add("File 1");
            ToolsFileList.Add("File 1");
            AchievedFileList.Add("File 1");
            AchievedFileList.Add("File 2");

            BasedOnFileListView.ItemsSource = BasedOnFileList;
            ToolsFileListView.ItemsSource = ToolsFileList;
            AchievedFileListView.ItemsSource = AchievedFileList;
        }

        private void SendButton_Clicked(object sender, EventArgs e)
        {
            _ = DisplayAlert("Alert", "Deze stap is nog niet verder uitgewerkt", "OK");
        }

        private void ReturnToStepsButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}