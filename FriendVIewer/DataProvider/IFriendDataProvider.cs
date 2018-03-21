using System.Collections.Generic;
using FriendVIewer.Model;

namespace FriendVIewer.DataProvider
{
    public interface IFriendDataProvider
    {
        IEnumerable<Friend> LoadFriend();
    }
}