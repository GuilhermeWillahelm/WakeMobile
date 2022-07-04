using System.ComponentModel;
using WakeMobile.ViewModels;
using Xamarin.Forms;

namespace WakeMobile.Views
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