﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.App_Start
{
    public static class StaticVars
    {
#if(DEBUG)
        public static string DBConnectionsString { private set; get;  } = @"Data Source=(localdb)\ProjectsV13;Initial Catalog = ""Mountan Tracker Climb - DataBase""; Integrated Security = True; Pooling=False;Connect Timeout = 30";
#else
        //Insert useable shit here
#endif
    }
}