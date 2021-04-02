using MTCSharedModels.Models;
using Mountain_Tracker_Climb___API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mountain_Tracker_Climb___API.Helpers;
using Mountain_Tracker_Climb___API.Security;
using Mountain_Tracker_Climb___API.DBModelContexts.StoredProcs;

namespace Mountain_Tracker_Climb___API.DBModelContexts
{
    internal class UserBannerPictureDBContext : RootDBContext<UserBannerPicture>
    {

        public override string DBTable => "dbo.Users";

        public UserBannerPictureDBContext() : base() 
        {
        }

        public UserBannerPictureDBContext(IDBRootContext Context) : base(Context.DB) 
        {
        }


        public UserBannerPicture GetUserBannerPicture(int ID)
        {
            return GetListOf($"ID = {ID}").FirstOrDefault();
        }

        public int UpdateUserBannerPicture(int ID, UserBannerPicture Values)
        {
            return UpdateData(Values, $"ID = {ID}");
        }

        public int DeleteUserBannerPicture(int ID)
        {
            string Command = BasicUpdate($"BannerPictureBytes = NULL", $"ID = {ID}");
            return ExecuteCustomNonQuery(Command);
        }
    }
}