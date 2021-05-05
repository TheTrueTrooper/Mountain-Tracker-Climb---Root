using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MTCSharedModels.Models
{
    public class CheckIfFriendProc
    {
        public int UserID { get; set; }
        public int FriendUserID { get; set; }
    }

    public class CheckIfFriendProcReturn
    {
        public bool IsFriend { get; set; }
    }
}