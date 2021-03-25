using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.Models
{
    public class CheckTokenProc
    {
        public int UserID { get; set; }
        public string UserToken { get; set; }
    }

    public class CheckTokenProcReturn
    {
        public bool Valid { get; set; }
        public int AccessLevelID { get; set; }
    }
}