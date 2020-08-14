using CatchMe.Models;
using CatchMe.Services;
using CatchMe.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace CatchMe.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Friend> Friends { get; set; }
        IFriendStore<Friend> _ds;

        public ICommand ViewFriendsCommand { get; set; }

        public MainViewModel(INavigation navigation, IFriendStore<Friend> friendStore)
        {
            _ds = friendStore;
            var friends = _ds.GetAsync().Result;
            Friends = new ObservableCollection<Friend>(friends);
            ViewFriendsCommand = new Command<Friend>(friend =>
            {
                navigation.PushAsync(new FriendDetailPage(new FriendDetailViewModel(friend)));
            });
        }
    }
}
