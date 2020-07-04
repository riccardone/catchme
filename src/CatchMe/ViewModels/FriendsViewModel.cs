using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using CatchMe.Models;
using CatchMe.Views;

namespace CatchMe.ViewModels
{
    public class FriendsViewModel : BaseViewModel
    {
        public ObservableCollection<Friend> Friends { get; set; }
        public Command LoadItemsCommand { get; set; }

        public FriendsViewModel()
        {
            Title = "Friends";
            Friends = new ObservableCollection<Friend>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {              
                throw new NotImplementedException("add item is called FriendsViewModel");
                //var newItem = item as Item;
                //Items.Add(newItem);
                //await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Friends.Clear();
                var items = await FriendsDataStore.GetAsync();
                foreach (var item in items)
                {
                    Friends.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}