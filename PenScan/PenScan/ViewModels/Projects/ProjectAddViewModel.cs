using PenScan.Data;
using PenScan.Models;
using PenScan.Views.Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PenScan.ViewModels.Projects
{
    public class ProjectAddViewModel : BaseViewModel
    {
        private string _ProjectName;
        private string _Description;
        private string _CompanyName;

        public string ProjectName
        {
            get { return _ProjectName; }
            set
            {
                _ProjectName = value;
                NotifyPropertyChanged("ProjectName");
            }
        }
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                NotifyPropertyChanged("Description");
            }
        }
        public string CompanyName
        {
            get { return _CompanyName; }
            set
            {
                _CompanyName = value;
                NotifyPropertyChanged("CompanyName");
            }
        }

        public ICommand CreateCommand => new Command(Create);
        private async void Create()
        {
            if (string.IsNullOrEmpty(CompanyName) || string.IsNullOrEmpty(ProjectName) || string.IsNullOrEmpty(Description))
            {
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            }
            else
            {
                try
                {
                    Project project = new Project()
                    {
                        CompanyName = CompanyName,
                        ProjectName = ProjectName,
                        Description = Description,
                        Status = Status.Low
                    };

                    await db().InsertProjectAsync(project);
                    _ = App.Current.MainPage.Navigation.PopAsync();
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Error Fail", "Het volgende is fout gegaan { " + ex + " } probeer het later opnieuw", "OK");
                }
                
            }
        }
    }
}
