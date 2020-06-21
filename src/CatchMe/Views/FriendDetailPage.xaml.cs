using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CatchMe.Models;
using CatchMe.ViewModels;

namespace CatchMe.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class FriendDetailPage : ContentPage
    {
        FriendDetailViewModel viewModel;

        public FriendDetailPage(FriendDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public FriendDetailPage()
        {
            InitializeComponent();

            var item = new Friend
            {
                DisplayName = "Ciccio 1"                
            };

            viewModel = new FriendDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}