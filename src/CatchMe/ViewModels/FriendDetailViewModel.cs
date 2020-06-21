
using CatchMe.Models;

namespace CatchMe.ViewModels
{
    public class FriendDetailViewModel : BaseViewModel
    {
        public Friend Friend { get; set; }
        public FriendDetailViewModel(Friend friend = null)
        {
            Title = friend?.DisplayName;
            Friend = friend;
        }
    }
}
