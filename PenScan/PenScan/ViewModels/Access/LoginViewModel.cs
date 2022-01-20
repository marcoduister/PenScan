using PenScan.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using PenScan.Views.Project;
using PenScan.Models;

namespace PenScan.ViewModels.Access
{
    public class LoginViewModel : BaseViewModel
    {
        private string email;
        private string password;
        public LoginViewModel()
        {

        }
        
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                NotifyPropertyChanged("Email");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }

        public Command LoginCommand
        {
            get
            {
                return new Command(Login);
            }
        }

        private void Login()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            }
            else
            {
                User inlogUser = db().validateUserAsync(Email, Password).Result;
                if (inlogUser != null)
                {
                    Application.Current.Properties.Clear();
                    Application.Current.Properties["Email"] = email;
                    Application.Current.Properties["UserId"] = inlogUser.Id;
                    Application.Current.Properties["UserRole"] = inlogUser.Role;

                    App.Current.MainPage.Navigation.PushAsync(new ProjectOverview());
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Email and Password", "OK");
                }
                    
            }
        }
    }
}
