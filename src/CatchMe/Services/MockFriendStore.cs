using CatchMe.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatchMe.Services
{
    public class MockFriendStore : IFriendStore<Friend>
    {
        private IEnumerable<Friend> _friends = new List<Friend>();
        public Task<IEnumerable<Friend>> GetAsync()
        {
            return Task.FromResult<IEnumerable<Friend>>(_friends);
        }
    }
}
