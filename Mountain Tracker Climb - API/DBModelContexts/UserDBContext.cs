using MTCSharedModels.Models;
using Mountain_Tracker_Climb___API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.DBModelContexts
{
    internal class UserDBContext : RootDBContext<UserFullWithSecurity>
    {
        public override string DBTable => "dbo.Users";

        public UserDBContext() : base() { }

        public UserDBContext(IDBRootContext Context) : base(Context.DB) { }

        public IEnumerable<UserFullWithSecurity> GetListOfUsers()
        {
            return GetListOf();
        }

        public IEnumerable<UserFullWithSecurity> GetListOfUsers(int AccessLevelID)
        {
            return GetListOf($"AccessLevelID = {AccessLevelID}");
        }

        public UserFullWithSecurity GetUser(int ID)
        {
                return GetListOf($"ID = {ID}").FirstOrDefault();
        }

        public int AddUser(UserFullWithSecurity Values)
        {
            return InsertData(Values);
        }

        public int UpdateUser(int ID, UserFullWithSecurity Values)
        {
            return UpdateData(Values, $"ID = {ID}");
        }

        public int DeleteUser(int ID)
        {
            return DeleteData($"ID = {ID}");
        }
    }
}