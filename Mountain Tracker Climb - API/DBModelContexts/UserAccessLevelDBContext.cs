using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Mountain_Tracker_Climb___API.DBModelContexts
{
    internal class UserAccessLevelDBContext : RootDBContext<UserAccessLevel>
    {
        public UserAccessLevelDBContext() : base() { }

        public UserAccessLevelDBContext(IDBRootContext Context) : base(Context.DB) { }

        public UserAccessLevel GetZoneArea(int ID)
        {
            return GetListOf($"ID = {ID}").FirstOrDefault();
        }
    }
}