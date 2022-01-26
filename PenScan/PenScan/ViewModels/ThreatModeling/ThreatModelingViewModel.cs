using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PenScan.ViewModels.ThreatModeling
{
    public class ThreatModelingViewModel :BaseViewModel
    {
        private ObservableCollection<Models.File> _FileList;
        private Models.File _SelectedFile;
        private bool _uploaded;
        private int ProjectId { get; set; }
        private int ProjectFaseId { get; set; }

        public bool uploaded
        {
            get { return _uploaded; }
            set
            {
                _uploaded = value;
                NotifyPropertyChanged("uploaded"); ;
            }
        }

        public Models.File SelectedFile
        {
            get { return _SelectedFile; }
            set
            {
                _SelectedFile = value;
                NotifyPropertyChanged("SelectedFile"); ;
            }
        }
        public ObservableCollection<Models.File> FileList
        {
            get { return _FileList; }
            set
            {
                _FileList = value;
                NotifyPropertyChanged("FileList"); ;
            }
        }

        public ThreatModelingViewModel(int projectId, int projectFaseId)
        {
            ProjectFaseId = projectFaseId;
            ProjectId = projectId;

            var List = db().GetAllThreatModelingFiles(projectId, projectFaseId);
            if (List.Count > 0)
            {
                FileList = List;
                uploaded = true;
            }
            else
            {
                FileList = new ObservableCollection<Models.File>();
            }
        }

        public ICommand AddFileCommand => new Command(AddFile);
        public ICommand SelectFileCommand => new Command(SelectFile);
        public ICommand SaveCommand => new Command(Save);


        public async void AddFile()
        {
            if (!uploaded)
            {
                if (SelectedFile != null)
                {
                    FileList.Add(SelectedFile);
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("no file", "Please select a file first ", "OK");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("sorry", "you have already uploaded files", "OK");
            }

        }
        public async void SelectFile()
        {
            // Opening the File Picker - Filter with Jpeg image

            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Select your file",
                    FileTypes = FilePickerFileType.Pdf
                });
                if (result != null)
                {
                    SelectedFile = new Models.File()
                    {
                        FileName = result.FileName,
                        FullPath = result.FullPath,
                        ContentType = result.ContentType,
                        ProjectId = ProjectId,
                        projectfaseId = ProjectFaseId

                    };
                }
            }
            catch (Exception ex)
            {
                
            }

        }
        public async void Save()
        {
            if (!uploaded)
            {
                if (FileList.Count != 0)
                {
                    var Id = db().AddThreatModelingFiles(FileList);
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("no file", "Please add files", "OK");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("sorry", "you have already uploaded files", "OK");
            }
        }
    }
}
