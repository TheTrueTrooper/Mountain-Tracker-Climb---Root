using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.Models
{
    internal class CreateTokenProc
    {
        public int UserID { get; set; }
        public string UserToken { get; set; }
    }

    internal class CreateTokenProc2 : CreateTokenProc
    {
        public int DaysValid { get; set; }
    }
}