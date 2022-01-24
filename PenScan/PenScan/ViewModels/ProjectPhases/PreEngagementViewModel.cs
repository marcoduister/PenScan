using Plugin.Media;
using PenScan.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace PenScan.ViewModels.ProjectPhases
{
    public class PreEngagementViewModel : BaseViewModel
    {
        private bool _Contractsigned;
        private int _ProjectId;
        private ImageSource _ContractImage;
        private Models.Contract _contract;
        private string _FilePath;

        public string FilePath
        {
            get { return _FilePath; }
            set
            {
                _FilePath = value;
                NotifyPropertyChanged("FilePath");
            }
        }
        public Models.Contract contract
        {
            get { return _contract; }
            set
            {
                _contract = value;
                NotifyPropertyChanged("contract");
            }
        }
        public ImageSource ContractImage
        {
            get { return _ContractImage; }
            set
            {
                _ContractImage = value;
                NotifyPropertyChanged("ContractImage");
            }
        }
        public bool Contractsigned
        {
            get { return _Contractsigned; }
            set
            {
                _Contractsigned = value;
                NotifyPropertyChanged("Contractsigned");
            }
        }
        public int ProjectId
        {
            get { return _ProjectId; }
            set
            {
                _ProjectId = value;
                NotifyPropertyChanged("ProjectId");
            }
        }

        public PreEngagementViewModel(int projectId)
        {
            contract = new Models.Contract();
            ProjectId = projectId;
            contract.ProjectId = ProjectId;
        }

        public ICommand ConfirmCommand => new Command(Confirm);
        public ICommand TakeSignatureCommand => new Command(TakesSignatureImage);

        public async void TakesSignatureImage()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable )
            {
                if (!CrossMedia.Current.IsTakePhotoSupported)
                {
                    await App.Current.MainPage.DisplayAlert("geen camera", "u heeft geen camera", "OK");

                    return;
                }
                
            }

            var photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                Directory = "PenscanMap",
                Name = "Contract" + ProjectId
            });

            if (photo == null)
            {
                return;
            }
            else
            {
                var Localcontract = contract;
                Localcontract.signature = photo.Path;
                contract = Localcontract;


                Contractsigned = true;
            }
                

            ContractImage = ImageSource.FromStream(() => photo.GetStream());
        }

        public async void Confirm()
        {
            if (ContractImage == null)
            {
                contract.ProjectId = ProjectId;
                contract.Confirmd = Contractsigned;
                var Id = db().InsertContract(contract);
                if (Id != null)
                {
                    await App.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter all values", "OK");
                }
            }
        }
    }
}
