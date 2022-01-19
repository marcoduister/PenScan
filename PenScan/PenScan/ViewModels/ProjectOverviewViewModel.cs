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
    public class ProjectOverviewViewModel : BaseViewModel
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

        private Project _selectedProject;
        public Project SelectedProject
        {
            get { return _selectedProject; }
            set
            {
                if (_selectedProject != value)
                {
                    _selectedProject = value;
                    ProjectTabbed();
                }
            }
        }

        private void HandleSelectedItem()
        {
            Page page = new ProjectDetailPage();
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
        public Command ProjectTabbedCommand => new Command(ProjectTabbed);

        private void ProjectTabbed()
        {
            //if (project == null)
            //    return;

            App.Current.MainPage.Navigation.PushAsync(new ProjectDetailPage());
        }


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
            var answer = await App.Current.MainPage.DisplayAlert("Deleting a Project?", "Are you sure you want to delete this project", "Yes", "No");

            if (answer)
            {
                await App.Current.MainPage.DisplayAlert("Verwijderd", "U heeft project verwijderd", "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Niet verwijder", "U heeft het project niet verwijderd", "OK");
            }
        }


    }
}