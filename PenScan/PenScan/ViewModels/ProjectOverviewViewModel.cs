using PenScan.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using PenScan.Views.Project;
using System.Collections.ObjectModel;
using PenScan.Models;
using System.Threading.Tasks;

namespace PenScan.ViewModels
{
    public class ProjectOverviewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Project> projects;

        public ObservableCollection<Project> Projects
        {
            get { return projects; }
            set
            {
                projects = value;
            }
        }
        public ProjectOverviewViewModel()
        {
            Projects = new ObservableCollection<Project>() {
                new Project()
                {
                    Id = 1,
                    ProjectName = "Digitalnet",
                },
                new Project()
                {
                    Id = 2,
                    ProjectName = "InterConnect"
                }
            };

        }

        public Command AddCommand => new Command(CreateProject);
        public Command EditCommand => new Command(EditProject);
        public Command DeleteCommand => new Command(DeleteProject);

        private void CreateProject()
        {
            App.Current.MainPage.Navigation.PushAsync(new AddProjectPage());
        }

        private void EditProject()
        {
            App.Current.MainPage.Navigation.PushAsync(new EditProjectPage());
        }
        private async void DeleteProject()
        {
            var answer = await App.Current.MainPage.DisplayAlert("Deleting a Question?", "are you sure you want to do this", "Yes", "No");

            if (answer)
            {
                await App.Current.MainPage.DisplayAlert("verwijderd", "uw heeft project verwijderd", "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("niet verwijder", "u heeft het project niet verwijderd", "OK");
            }
        }


    }
}