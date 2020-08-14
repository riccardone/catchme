using CatchMe.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CatchMe.Services
{
    public class MockFriendStore : IFriendStore<Friend>
    {
        private IEnumerable<Friend> _friends = new List<Friend> {
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
                LastLocation = new Location { Latitude = 1.171818, Longitude = 52.35164 },
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
                DisplayName = "Miss Sara Tomasi",
                Distance = 5,
                FriendSessionActive = true,
                FriendSessionId = Guid.NewGuid(),
                Heading = 100,
                HeBlockedMe = false,
                LastLocation = new Location { Latitude = 41.890251, Longitude = 12.492373 },
                ModifiedAt = DateTime.Now,
                PictureUrl = new Uri("https://www.sologossip.it/wp-content/uploads/2019/10/Sara-Tommasi-650x433.jpg"),
                RequestReceived = false,
                RequestSent = true,
                Speed = 3
            }
            };


        public Task<IEnumerable<Friend>> GetAsync()
        {            
            return Task.FromResult<IEnumerable<Friend>>(_friends);
        }
    }
}
