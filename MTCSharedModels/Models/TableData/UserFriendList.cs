using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class UserFriendList
    {
        public List<UserInfoPublic> Friends { get; set; } = new List<UserInfoPublic>();
        public List<UserFriend> FriendsAdded { get; set; } = new List<UserFriend>();
        public List<UserFriend> FriendsAccepted { get; set; } = new List<UserFriend>();
        public List<UserInfoPrivate> FriendRequesteds { get; set; } = new List<UserInfoPrivate>();
        public List<UserFriend> RequestsTo { get; set; } = new List<UserFriend>();
        public List<UserInfoPrivate> FriendRequests { get; set; } = new List<UserInfoPrivate>();
        public List<UserFriend> RequestsFrom { get; set; } = new List<UserFriend>();
    }
}
