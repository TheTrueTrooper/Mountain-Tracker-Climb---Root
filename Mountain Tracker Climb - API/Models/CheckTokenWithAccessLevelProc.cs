using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.Models
{
    public class CheckTokenWithAccessLevelProc : CheckTokenProc
    {
        public int UserRequiredAccessLevelID { get; set; }
    }

    public class CheckTokenWithAccessLevelProcReturn : CheckTokenProcReturn
    {
    }
}