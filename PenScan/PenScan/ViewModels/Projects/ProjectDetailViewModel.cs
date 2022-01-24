using PenScan.Models;
using PenScan.Services;
using PenScan.Views.ProjectPhases;
using PenScan.Views.Scan;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
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
                    NotifyPropertyChanged("ItemSelected");
                    switch (_ProjectPhaseSelected.Id)
                    {
                        case 1:
                            App.Current.MainPage.Navigation.PushAsync(new PreEngagementPage());
                            break;
                        case 2:
                            App.Current.MainPage.Navigation.PushAsync(new Views.Scan.Scanner());
                            break;
                        case 3:
                            // code block
                            break;
                        case 4:
                            // code block
                            break;
                        case 5:
                            // code block
                            break;
                        case 6:
                            // code block
                            break;
                        case 7:
                            // code block
                            break;
                        default:
                            // code block
                            break;
                    }
                    

                }
            }
        }

        public ProjectDetailViewModel(Project project)
        {

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
    }
}
