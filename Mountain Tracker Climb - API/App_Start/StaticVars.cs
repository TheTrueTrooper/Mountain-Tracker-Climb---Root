using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.App_Start
{
    public static class StaticVars
    {

#if(DEBUG)
        internal static string DBConnectionsString { private set; get;  } = @"Data Source=(localdb)\ProjectsV13;Initial Catalog = ""Mountan Tracker Climb - DataBase""; Integrated Security = True; Pooling=False;Connect Timeout = 30";
#else
        internal static string DBConnectionsString { private set; get;  } = @"Data Source=WIN-S86LRV3L4JD\MTNTRACKERMSSQL;Initial Catalog=""Mountain Tracker Climb - DataBase"";User ID=ASPNETAPP;Password=zZ1XT6h7H3SI4fE7DS5yDC9Vn97!";
#endif
        public const string User = "User";
        public const string UserID = "UserID";
        public const string Token = "Token";
        public const string IDToken = "IDToken";
        public const string AccessLevelID= "AccessLevelID";
    }
}