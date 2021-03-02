using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.Models
{
    public class UserLogin
    {
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Salt { get; set; }
    }
}