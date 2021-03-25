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
    internal class UserDBContext : RootDBContext<UserFullWithSecurity>
    {
        UserLoginDBContext LoginStoredProc;
        GetUsersSaltDBContext GetUserSaltStoredProc;
        CreateTokenDBContext1 CreateTokenPhone;
        CreateTokenDBContext2 CreateTokenWeb;

        public override string DBTable => "dbo.Users";

        public UserDBContext() : base() 
        {
            LoginStoredProc = new UserLoginDBContext(this);
            GetUserSaltStoredProc = new GetUsersSaltDBContext(this);
            CreateTokenPhone = new CreateTokenDBContext1(this);
            CreateTokenWeb = new CreateTokenDBContext2(this);
        }

        public UserDBContext(IDBRootContext Context) : base(Context.DB) 
        {
            LoginStoredProc = new UserLoginDBContext(Context);
            GetUserSaltStoredProc = new GetUsersSaltDBContext(Context);
            CreateTokenPhone = new CreateTokenDBContext1(Context);
            CreateTokenWeb = new CreateTokenDBContext2(Context);
        }

        UserLoginReturn Login(UserLogin Login)
        {
            string Salt = GetUserSaltStoredProc.GetSalt(new UserGetSaltProc() { UserName = Login.UserName }).Salt;
            UserLoginProcReturn Result = LoginStoredProc.Login(new UserLoginProc() { UserName = Login.UserName, HashedPassword = SecurityHelper.PasswordToSaltedHash(Login.Password, Salt) });
            if (Result.Success == true)
            {
                UserLoginReturn TokenReturn = new UserLoginReturn()
                {
                    BearersToken = SecurityHelper.GetCode(),
                    UserID = Result.ID
                };

                return TokenReturn;
            }
            return null;
        }

        public UserLoginReturn LoginPhone(UserLogin Login)
        {
            UserLoginReturn Return = this.Login(Login);
            if(Return != null)
                CreateTokenPhone.CreateToken(new CreateTokenProc() { UserID = Return.UserID.Value, UserToken = Return.BearersToken });
            return Return;
        }

        public UserLoginReturn LoginWeb(UserLogin Login)
        {
            UserLoginReturn Return = this.Login(Login);
            if (Return != null)
                CreateTokenWeb.CreateToken(new CreateTokenProc2() { UserID = Return.UserID.Value, UserToken = Return.BearersToken, DaysValid = 1 });
            return Return;
        }

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