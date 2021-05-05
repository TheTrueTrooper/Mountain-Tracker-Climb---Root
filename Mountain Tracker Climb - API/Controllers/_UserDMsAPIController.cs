using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MTCSharedModels.Models;
using Mountain_Tracker_Climb___API.Models;
using Mountain_Tracker_Climb___API.DBModelContexts;
using Mountain_Tracker_Climb___API.Helpers;
using Mountain_Tracker_Climb___API.Security;
using System.Data.SqlClient;
using Mountain_Tracker_Climb___API.App_Start;
using System.IO;
using System.Net.Http.Headers;
using System.Web;
using System.Threading.Tasks;
using System.Web.Http.Validation.Providers;

namespace Mountain_Tracker_Climb___API.Controllers
{
    //friends was lingo was converted to partners. this is the first level that that difference matters.
    public class UserDMsController : ApiController
    {

        //[NonAction]
        //void EnsureOwnerShip(int To, int From)
        //{
        //    object CurrentUserIDBoxed;
        //    Request.Properties.TryGetValue(StaticVars.UserID, out CurrentUserIDBoxed);

        //    if (CurrentUserIDBoxed == null && (int)CurrentUserIDBoxed != To && (int)CurrentUserIDBoxed != From)
        //        throw new HttpResponseException(HttpStatusCode.Unauthorized);
        //}

        [APISecurityLevel()]
        [HttpGet]
        public UserDMLists Get(int id)
        {
            this.EnsureOwnerShip(id);
            object CurrentUserIDBoxed;
            Request.Properties.TryGetValue(StaticVars.UserID, out CurrentUserIDBoxed);
            int UserID = (int)CurrentUserIDBoxed;
            UserDMLists List = new UserDMLists();
            IEnumerable<UserDM> DMsRaw = null;
            using (DBContext DBContext = new DBContext())
                DMsRaw = DBContext.UserDMTable.GetListOfMessages(id);
            foreach (UserDM DM in DMsRaw)
            {
                if (DM.UserFromID == id)
                {
                    if (!List.MessagesBetweenUser.ContainsKey(DM.UserToID.Value))
                    {
                        List.MessagesBetweenUser.Add(DM.UserToID.Value, new UserDMList());
                        using (DBContext DBContext = new DBContext())
                            List.MessagesBetweenUser[DM.UserToID.Value].User = MiscellaneousHelpers.ToPrivateUser(DBContext.UserTable.GetUser(DM.UserToID.Value));
                    }
                    List.MessagesBetweenUser[DM.UserToID.Value].AllMessages.Add(DM);
                }
                else
                {
                    if (!List.MessagesBetweenUser.ContainsKey(DM.UserFromID.Value))
                    {
                        List.MessagesBetweenUser.Add(DM.UserFromID.Value, new UserDMList());
                        using (DBContext DBContext = new DBContext())
                            List.MessagesBetweenUser[DM.UserFromID.Value].User = MiscellaneousHelpers.ToPrivateUser(DBContext.UserTable.GetUser(DM.UserFromID.Value));
                    }
                    List.MessagesBetweenUser[DM.UserFromID.Value].AllMessages.Add(DM);
                }
            }
            return List;
        }

        [APISecurityLevel()]
        [HttpGet]
        public UserDMList Get(int id, int WithUserID)
        {
            this.EnsureOwnerShip(id);
            UserDMList List = new UserDMList();
            IEnumerable<UserDM> DMsRaw = null;
            using (DBContext DBContext = new DBContext())
            {
                List.User = MiscellaneousHelpers.ToPrivateUser(DBContext.UserTable.GetUser(WithUserID));
                DMsRaw = DBContext.UserDMTable.GetListOfMessagesBewteenUsers(id, WithUserID);
            }
            foreach (UserDM DM in DMsRaw)
            {
                List.AllMessages.Add(DM);
            }
            return List;
        }

        [APISecurityLevel()]
        [HttpPut]
        public void Put(int id, [FromBody] UserDM Values)
        {
            ControllerHelper.CheckObjectForPostErrorException(Values);
            this.EnsureOwnerShip(Values.UserFromID.Value);

            try
            {
                using (DBContext DB = new DBContext())
                    DB.UserDMTable.UpdateMessage(id, Values);
            }
            catch (SqlException e)
            {
                throw new HttpResponseException(ControllerHelper.MakeHttpGenericSQLErrorResposnse(e));
            }
        }

        [APISecurityLevel()]
        [HttpPost]
        public void Post([FromBody]UserDM Values)
        {
            ControllerHelper.CheckObjectForPostErrorException(Values);
            this.EnsureOwnerShip(Values.UserFromID.Value);

            try
            {
                using (DBContext DB = new DBContext())
                    DB.UserDMTable.AddMessage(Values);
            }
            catch (SqlException e)
            {
                throw new HttpResponseException(ControllerHelper.MakeHttpGenericSQLErrorResposnse(e));
            }
        }

        [APISecurityLevel()]
        [HttpDelete]
        public void Delete(int MessageID, int UserFromID)
        {
            this.EnsureOwnerShip(UserFromID);

            try
            {
                using (DBContext DB = new DBContext())
                    DB.UserDMTable.DeleteMessage(MessageID, UserFromID);
            }
            catch (SqlException e)
            {
                throw new HttpResponseException(ControllerHelper.MakeHttpGenericSQLErrorResposnse(e));
            }
        }
    }
}