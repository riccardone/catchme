using CatchMe.Models;
using CatchMe.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CatchMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FriendsPage : ContentPage
    {
        FriendsViewModel viewModel;

        public FriendsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new FriendsViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var friend = (Friend)layout.BindingContext;
            await Navigation.PushAsync(new FriendDetailPage(new FriendDetailViewModel(friend)));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewFriendPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Friends.Count == 0)
                viewModel.IsBusy = true;
        }

        //async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    if (e.Item == null)
        //        return;

        //    await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

        //    //Deselect Item
        //    ((ListView)sender).SelectedItem = null;
        //}
    }
}
