using PenScan.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using PenScan.Views.Project;
using PenScan.Views.Access;
using System.Net.Mail;
using PenScan.Services;
using PenScan.Models;

namespace PenScan.ViewModels.Access
{
    public class RegisterViewModel : BaseViewModel
    {
        private string _Email;
        private string _Password;
        private string _Passwordconfirm;
        private string _FirstName;
        private string _LastName;

        public RegisterViewModel()
        {

        }
        
        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
                NotifyPropertyChanged("Email");
            }
        }
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                _FirstName = value;
                NotifyPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get { return _LastName; }
            set
            {
                _LastName = value;
                NotifyPropertyChanged("FirstName");
            }
        }
        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                NotifyPropertyChanged("Password");
            }
        }
        public string Passwordconfirm
        {
            get { return _Passwordconfirm; }
            set
            {
                _Passwordconfirm = value;
                NotifyPropertyChanged("Passwordconfirm");
            }
        }


        public Command RegisterCommand => new Command(Register);

        private void Register()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(FirstName)|| string.IsNullOrEmpty(LastName)|| string.IsNullOrEmpty(Passwordconfirm))
            {
                App.Current.MainPage.DisplayAlert("Empty Values", "Please check end enter values", "OK");
            }
            else
            {
                if (Password == Passwordconfirm)
                {
                    if (IsEmail(Email))
                    {
                        if (db().EmailExistAsync(Email).Result)
                        {
                            string salt = SecurityHelper.GenerateSalt(70);
                            string pwdHashed = SecurityHelper.HashPassword(Passwordconfirm, salt, 10101, 70);

                            db().InsertUserAsync(new User()
                            {
                                Email = Email,
                                FirstName = FirstName,
                                LastName = LastName,
                                Password = pwdHashed,
                                Salt = salt,
                                Role = Role.User
                            });
                            App.Current.MainPage.Navigation.PushAsync(new LoginPage());
                        }
                        else
                        {
                            App.Current.MainPage.DisplayAlert("Email fail", "please use other Email adress", "OK");
                        }
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("Email fail", "please use a real email adress", "OK");
                    }
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Passowrd fail", "Your password confrim doesnt match password", "OK");
                }
            }
        }
        private bool IsEmail(string Email)
        {

            try
            {
                if (Email == "" || Email == null)
                {
                    return false;
                }
                MailAddress email = new MailAddress(Email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
