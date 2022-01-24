using PenScan.ViewModels;
using PenScan.ViewModels.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.Essentials;

namespace PenScan.Views.Access
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();

            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;

            if (!Accelerometer.IsMonitoring)
                Accelerometer.Start(SensorSpeed.Game);
        }

        void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            // Process shake event
            Email.Text = "";
            Password.Text = "";
            DisplayAlert("Shake It", "Earthquake Detected", "Close");
        }
    }
}