using PenScan.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PenScan.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}