using System;
using System.Collections.Generic;
using System.ComponentModel;
using WakeMobile.Models;
using WakeMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WakeMobile.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}