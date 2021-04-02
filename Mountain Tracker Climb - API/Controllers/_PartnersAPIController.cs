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

namespace Mountain_Tracker_Climb___API.Controllers
{
    [APISecurityLevel()]
    public class PartnersController : ApiController
    {
        [NonAction]
        void EnsureOwnerShip(int id)
        {
            object CurrentUserIDBoxed;
            Request.Properties.TryGetValue(StaticVars.UserID, out CurrentUserIDBoxed);
            object AccessLevelIDBoxed;
            Request.Properties.TryGetValue(StaticVars.AccessLevelID, out AccessLevelIDBoxed);

            if (CurrentUserIDBoxed == null && ((int)CurrentUserIDBoxed != id || (AccessLevelIDBoxed == null && (int)CurrentUserIDBoxed > APISecurityLevelAttribute.AccessLevels["Moderater"])))
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }                 
    }
}