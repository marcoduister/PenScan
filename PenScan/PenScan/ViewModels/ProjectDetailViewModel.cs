using PenScan.Models;
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
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<ProjectPhase> projectPhases;

        public ObservableCollection<ProjectPhase> ProjectPhases
        {
            get { return projectPhases; }
            set
            {
                projectPhases = value;
            }
        }

        public ProjectDetailViewModel()
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
