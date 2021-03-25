using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.Models
{
    internal class UserGetSaltProc
    {
        public string UserName { get; set; }
    }

    internal class UserGetSaltProcReturn
    {
        public string Salt { get; set; }
    }
}