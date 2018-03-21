using System.Collections.Generic;
using FriendVIewer.DataProvider;
using FriendVIewer.DesignTimeData;
using FriendVIewer.Model;

namespace FriendVIewer.DesignTimeData
{
    public class DesignFriendDataProvider : IFriendDataProvider
    {
        public IEnumerable<Friend> LoadFriend()
        {
            yield return new DesignFriend();
            yield return new DesignFriend { FirstName = "Julia" };
            yield return new DesignFriend { FirstName = "Anna" };
            yield return new DesignFriend { FirstName = "Sara" };
        }
    }
}
