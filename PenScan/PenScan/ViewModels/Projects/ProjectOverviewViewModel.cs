using PenScan.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using PenScan.Views.Projects;
using System.Collections.ObjectModel;
using PenScan.Models;
using System.Threading.Tasks;

namespace PenScan.ViewModels.Projects
{
    public class ProjectOverviewViewModel : BaseViewModel
    {

        private ObservableCollection<Project> projects;
        private Project _ProjectSelected;

        public ObservableCollection<Project> Projects
        {
            get { return projects; }
            set
            {
                projects = value;
                NotifyPropertyChanged("Projects"); ;
            }
        }

        public Project ProjectSelected
        {
            get
            {
                return _ProjectSelected;
            }
            set
            {
                if (_ProjectSelected != value)
                {
                    _ProjectSelected = value;
                    NotifyPropertyChanged("ItemSelected");
                    App.Current.MainPage.Navigation.PushAsync(new ProjectDetailPage(_ProjectSelected));
                    // dit is de oplossing voor listviewtap
                }
            }
        }

        public ProjectOverviewViewModel()
        {
            Refresh();
        }

        public Command AddCommand => new Command(CreateProject);
        public Command refresh => new Command(Refresh);
        public Command EditCommand => new Command<int>((x) => EditProject(x));
        public Command DeleteCommand => new Command<int>((x) => DeleteProject(x));


        private void Refresh()
        {
            Projects = new ObservableCollection<Project>(db().GetProjectAllAsync());
        }

        private void CreateProject()
        {
            App.Current.MainPage.Navigation.PushAsync(new AddProjectPage());
        }

        private void EditProject(int Id)
        {
            App.Current.MainPage.Navigation.PushAsync(new EditProjectPage(Id));
        }

        private async void DeleteProject(int Id)
        {
            var answer = await App.Current.MainPage.DisplayAlert("Deleting a project?", "are you sure you want to do this", "Yes", "No");

            if (answer)
            {
                if (db().DeleteProjectbyIdAsync(Id).Result != 0)
                {
                    await App.Current.MainPage.DisplayAlert("verwijderd", "uw heeft project verwijderd", "OK");

                    Projects = new ObservableCollection<Project>(db().GetProjectAllAsync());
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("mislukt", "Er is iets fout gegaan probeer het later opnieuw!", "OK");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("niet verwijder", "u heeft het project niet verwijderd", "OK");
            }
        }
    }
}