using System;
using System.ComponentModel;
using Xamarin.Forms;

using CatchMe.Models;

namespace CatchMe.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewFriendPage : ContentPage
    {
        public Friend Friend { get; set; }

        public NewFriendPage()
        {
            InitializeComponent();

            Friend = new Friend
            {
                DisplayName = "Item name"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddFriend", Friend);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}