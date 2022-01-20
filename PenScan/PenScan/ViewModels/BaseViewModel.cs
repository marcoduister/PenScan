using PenScan.Data;
using PenScan.Models;
using PenScan.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace PenScan.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private static DataBase database = null;


        public static DataBase db()
        {
            if (database == null)
                database = new DataBase();
            return database;
        }

        private bool _isLoading { get; set; }
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                if (value != _isLoading)
                {
                    _isLoading = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
