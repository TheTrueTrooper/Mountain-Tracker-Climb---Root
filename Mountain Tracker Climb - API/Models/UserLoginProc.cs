using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.Models
{
    internal class UserLoginProc
    {
        public string UserName { get; set; }
        public string HashedPassword { get; set; }
    }
    public class UserLoginProcReturn
    {
        public bool? Success { get; set; }
        public int? ID { get; set; }
    }
}