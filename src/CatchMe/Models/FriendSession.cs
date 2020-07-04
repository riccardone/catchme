using System;

namespace CatchMe.Models
{
    public class FriendSession
    {
        public string Id { get; set; }
        public bool Active { get; set; }
        public Guid Owner { get; set; }
        public Guid Friend { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
