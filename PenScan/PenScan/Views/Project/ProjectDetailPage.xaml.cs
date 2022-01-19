﻿using PenScan.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PenScan.Views.Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectDetailPage : ContentPage
    {
        public ProjectDetailPage()
        {
            InitializeComponent();
            BindingContext = new ProjectDetailViewModel();
        }
    }
}