using CatchMe.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatchMe.Services
{
    public class MockFriendRequestStore : IFriendRequestStore<FriendSession>
    {
        public Task<bool> AcceptAsync(FriendSession item)
        {
            return Task.FromResult<bool>(true);
        }

        public Task<bool> CreateAsync(string id)
        {
            return Task.FromResult<bool>(true);
        }

        public Task<bool> DisconnectAsync(FriendSession item)
        {
            return Task.FromResult<bool>(true);
        }

        public Task<IEnumerable<FriendSession>> GetAsync()
        {
            return Task.FromResult<IEnumerable<FriendSession>>(new List<FriendSession>());
        }
    }
}
