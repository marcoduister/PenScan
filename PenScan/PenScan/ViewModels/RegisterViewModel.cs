using PenScan.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using PenScan.Views.Project;
using PenScan.Views.Access;

namespace PenScan.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string email;
        private string password;
        private string passwordconfirm;

        public RegisterViewModel()
        {

        }
        
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public string Passwordconfirm
        {
            get { return passwordconfirm; }
            set
            {
                passwordconfirm = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Passwordconfirm"));
            }
        }
        

        public Command RegisterCommand
        {
            get
            {
                return new Command(Register);
            }
        }

        private void Register()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Passwordconfirm))
            {
                App.Current.MainPage.DisplayAlert("Empty Values", "Please check end enter values", "OK");
            }
            else
            {
                App.Current.MainPage.Navigation.PushAsync(new LoginPage());

            }
        }
    }
}
