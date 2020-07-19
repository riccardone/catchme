using CatchMe.Models;
using CatchMe.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CatchMe.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Friend> Friends { get; set; }

        public ICommand ViewFriendsCommand { get; set; }

        public MainViewModel(INavigation navigation)
        {
            // TODO get real friends
            var friends = new List<Friend> {
            new Friend
            {
                ColorCode = Color.Blue.ToHex(),
                Altitude = 100,
                Blocked = false,
                CreatedAt = DateTime.Now,
                DisplayName = "Mr Ric",
                Distance = 5,
                FriendSessionActive = true,
                FriendSessionId = Guid.NewGuid(),
                Heading = 100,
                HeBlockedMe = false,
                LastLocation = new Location { Latitude = -33.981818, Longitude = -54.14164 },
                ModifiedAt = DateTime.Now,
                PictureUrl = new Uri("https://i2.wp.com/www.dinuzzo.co.uk/wp-content/uploads/2014/07/FB_20150122_16_30_10_Saved_Picture.jpg"),
                RequestReceived = false,
                RequestSent = true,
                Speed = 3
            },
            new Friend
            {
                ColorCode = Color.Red.ToHex(),
                Altitude = 100,
                Blocked = false,
                CreatedAt = DateTime.Now,
                DisplayName = "Sara",
                Distance = 5,
                FriendSessionActive = true,
                FriendSessionId = Guid.NewGuid(),
                Heading = 100,
                HeBlockedMe = false,
                LastLocation = new Location { Latitude = 100.90, Longitude = 1.5 },
                ModifiedAt = DateTime.Now,
                PictureUrl = new Uri("https://www.sologossip.it/wp-content/uploads/2019/10/Sara-Tommasi-650x433.jpg"),
                RequestReceived = false,
                RequestSent = true,
                Speed = 3
            }
            };
            Friends = new ObservableCollection<Friend>(friends);

            ViewFriendsCommand = new Command<Friend>(friend =>
            {
                navigation.PushAsync(new FriendDetailPage(new FriendDetailViewModel(friend)));
            });
        }
    }
}
