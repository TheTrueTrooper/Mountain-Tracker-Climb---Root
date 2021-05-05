using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.Models
{
    public class AcceptFriendRequestProc
    {
        public int UserFromID { get; set; }
        public int UserToID { get; set; }
    }
}