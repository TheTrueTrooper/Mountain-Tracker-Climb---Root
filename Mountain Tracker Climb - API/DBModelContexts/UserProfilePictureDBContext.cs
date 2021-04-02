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
    internal class UserProfilePictureDBContext : RootDBContext<UserProfilePicture>
    {

        public override string DBTable => "dbo.Users";

        public UserProfilePictureDBContext() : base() 
        {
        }

        public UserProfilePictureDBContext(IDBRootContext Context) : base(Context.DB) 
        {
        }


        public UserProfilePicture GetUserProfilePicture(int ID)
        {
            return GetListOf($"ID = {ID}").FirstOrDefault();
        }

        public int UpdateUserProfilePicture(int ID, UserProfilePicture Values)
        {
            return UpdateData(Values, $"ID = {ID}");
        }

        public int DeleteUserProfilePicture(int ID)
        {
            string Command = BasicUpdate($"ProfilePictureBytes = NULL", $"ID = {ID}");
            return ExecuteCustomNonQuery(Command);
        }
    }
}