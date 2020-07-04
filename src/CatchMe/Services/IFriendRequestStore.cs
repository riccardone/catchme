using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatchMe.Services
{
    public interface IFriendRequestStore<T>
    {
        Task<bool> AcceptAsync(T item);
        Task<bool> DisconnectAsync(T item);
        Task<bool> CreateAsync(string id);        
        Task<IEnumerable<T>> GetAsync();
    }
}
