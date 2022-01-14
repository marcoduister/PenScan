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

        public Command AddCommand
        {
            get {   return new Command(CreateProject);  }
        }

        public Command DeleteCommand
        {
            get { return new Command(DeleteProject); }
        }

        public Command EditCommand
        {
            get { return new Command(EditProject); }
        }

        private void CreateProject()
        {

        }

        private void EditProject()
        {

        }

        private void DeleteProject()
        {

        }

    }
}
