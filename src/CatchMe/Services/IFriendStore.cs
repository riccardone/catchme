using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatchMe.Services
{
    public interface IFriendStore<T>
    { 
        Task<IEnumerable<T>> GetAsync();
    }
}
