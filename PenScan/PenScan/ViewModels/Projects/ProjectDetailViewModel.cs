using PenScan.Models;
using PenScan.Services;
using PenScan.Views.Exploitations;
using PenScan.Views.ProjectPhases;
using PenScan.Views.Reporting;
using PenScan.Views.Scan;
using PenScan.Views.ThreatModeling;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PenScan.ViewModels
{
    public class ProjectDetailViewModel : BaseViewModel
    {
        
        private ObservableCollection<ProjectPhase> projectPhases;
        private ProjectPhase _ProjectPhaseSelected;
        private Project _Project;

        public Project Project
        {
            get { return _Project; }
            set
            {
                _Project = value;
                NotifyPropertyChanged("Project"); ;
            }
        }
        public ObservableCollection<ProjectPhase> ProjectPhases
        {
            get { return projectPhases; }
            set
            {
                projectPhases = value;
                NotifyPropertyChanged("ProjectPhases"); ;
            }
        }

        public ProjectPhase ProjectPhaseSelected
        {
            get
            {
                return _ProjectPhaseSelected;
            }
            set
            {
                if (_ProjectPhaseSelected != value)
                {
                    _ProjectPhaseSelected = value;
                    NotifyPropertyChanged("ProjectPhaseSelected");
                    SelectionCommand.Execute(_ProjectPhaseSelected.Id);

                    
                }
            }
        }


        public ProjectDetailViewModel(Project project)
        {
            Project = project;
            ProjectPhases = new ObservableCollection<ProjectPhase>() {
                new ProjectPhase()
                {
                    Id = 1,
                    Name = "Pre-engagement",
                    Status = 0
                },
                new ProjectPhase()
                {
                    Id = 2,
                    Name = "Reconnaissance",
                    Status = 0
                },
                new ProjectPhase()
                {
                    Id = 3,
                    Name = "Threat Modeling",
                    Status = 0
                },
                new ProjectPhase()
                {
                    Id = 4,
                    Name = "Exploitation",
                    Status = 0
                },
                new ProjectPhase()
                {
                    Id = 5,
                    Name = "Post-Exploitation",
                    Status = 0
                },
                new ProjectPhase()
                {
                    Id = 6,
                    Name = "Reporting",
                    Status = 0
                },
                new ProjectPhase()
                {
                    Id = 7,
                    Name = "Re-Testing",
                    Status = 0
                },
            };

        }


        public ICommand SelectionCommand => new Command<int>((x) => switchcomand(x));

        public void switchcomand(int Id)
        {
            switch (Id)
            {
                case 1:
                    App.Current.MainPage.Navigation.PushAsync(new Views.ProjectPhases.PreEngagementPage(Project.Id));
                    break;
                case 2:
                    App.Current.MainPage.Navigation.PushAsync(new Views.Scan.Scanner(Project.Id));
                    break;
                case 3:
                    App.Current.MainPage.Navigation.PushAsync(new ThreatModelingPage(Project.Id, Id));
                    break;
                case 4:
                    App.Current.MainPage.Navigation.PushAsync(new Exploitation(Project.Id, Id));
                    break;
                case 5:
                    App.Current.MainPage.Navigation.PushAsync(new PostExploitation(Project.Id, Id));
                    break;
                case 6:
                     App.Current.MainPage.Navigation.PushAsync(new ReportingPage());
                    // hier moet een reporting pagina komen hoef niet functioneel werkend tezijn maar wel het gezicht.
                    break;
                case 7:
                    App.Current.MainPage.DisplayAlert("onder constructie", "sorry maar deze pagina is nog onder constructie", "OK");
                    // hier moet een Re-testing pagina komen hoef niet functioneel werkend tezijn maar wel het gezicht.
                    break;
                default:
                    // code block
                    break;
            }
        }
    }
}
