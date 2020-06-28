using System;

namespace CatchMe.Models
{
    public class Friend
    {
        public string ColorCode { get; set; }
        public string DisplayName { get; set; }
        public Location LastLocation { get; set; }
        public bool RequestReceived { get; set; }
        public bool RequestSent { get; set; }
        public int? Distance { get; set; }
        public Guid FriendSessionId { get; set; }
        public bool FriendSessionActive { get; set; }
        public Uri PictureUrl { get; set; }
        public decimal Speed { get; set; }
        public int Altitude { get; set; }
        public decimal Heading { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool Blocked { get; set; }
        public bool HeBlockedMe { get; set; }
    }
}