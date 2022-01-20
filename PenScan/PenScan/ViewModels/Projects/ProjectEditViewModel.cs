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
    public class ProjectEditViewModel : BaseViewModel
    {

        private int _Id;
        private string _ProjectName;
        private string _Description;
        private string _CompanyName;
        private Status _Status;

        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                NotifyPropertyChanged("Id");
            }
        }
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
        public Status Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
                NotifyPropertyChanged("Status");
            }
        }

        public ProjectEditViewModel(int id)
        {
            Project LocalProject = db().GetProjectbyIdAsync(id);
            Id = LocalProject.Id;
            ProjectName = LocalProject.ProjectName;
            Description = LocalProject.Description;
            CompanyName = LocalProject.CompanyName;
            Status = LocalProject.Status;
        }

        public ICommand EditCommand => new Command(Edit);
        private async void Edit()
        {
            if (string.IsNullOrEmpty(CompanyName) || string.IsNullOrEmpty(ProjectName) || string.IsNullOrEmpty(Description))
            {
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter all values", "OK");
            }
            else
            {
                try
                {
                    Project project = new Project()
                    {
                        Id = Id,
                        CompanyName = CompanyName,
                        ProjectName = ProjectName,
                        Description = Description,
                        Status = Status
                    };

                    await db().UpdateProjectAsync(project);
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
