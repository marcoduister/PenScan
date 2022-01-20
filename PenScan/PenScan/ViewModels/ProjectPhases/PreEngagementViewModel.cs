using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PenScan.ViewModels.ProjectPhases
{
    public class PreEngagementViewModel : BaseViewModel
    {
        public ICommand ConfirmCommand => new Command(Confirm);

        private async void Confirm()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
