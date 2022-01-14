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
    public partial class EditProjectPage : ContentPage
    {
        public EditProjectPage()
        {
            InitializeComponent();

            //Hardcoded needs to be changed
            List<string> companies = new List<string>() { "Company 1", "Company 2", "Company 3", "Company 4", "Company 5" };
            CompanyPicker.ItemsSource = companies;
        }

        private void FilePickerButton_Clicked(object sender, EventArgs e)
        {
            _ = DisplayAlert("WIP", "Hier komt de filepicker voor het contract", "OK");
        }

        private void EditProjectButton_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PopAsync();
            _ = DisplayAlert("Gelukt", "Project is aangepast", "OK");
        }
    }
}