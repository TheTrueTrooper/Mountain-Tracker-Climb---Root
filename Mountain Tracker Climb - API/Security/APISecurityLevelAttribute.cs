using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Mountain_Tracker_Climb___API.App_Start;
using Mountain_Tracker_Climb___API.DBModelContexts;
using Mountain_Tracker_Climb___API.Models;
using MTCSharedModels.Models;
using WebGrease;

namespace Mountain_Tracker_Climb___API.Security
{
    public class APISecurityLevelAttribute : ActionFilterAttribute
    {
        private static string LowestLevel;

        public static Dictionary<string, int> AccessLevels { get; private set; }

        public int RequiredAccessLevelID { get; set; }
        public string RequiredAccessLevel { get; set; }

        static APISecurityLevelAttribute()
        {
            AccessLevels = new Dictionary<string, int>();
            using (UserAccessLevelDBContext AccessTable = new UserAccessLevelDBContext())
                foreach (UserAccessLevel UAL in AccessTable.GetUserAccessLevels())
                {
                    AccessLevels.Add(UAL.EnglishName, UAL.ID);
                }
            //dynamic set
            LowestLevel = AccessLevels.Where(X => X.Value == AccessLevels.Max(M => { return M.Value; })).FirstOrDefault().Key;
        }

        public APISecurityLevelAttribute() : this(LowestLevel)
        {
        }

        public APISecurityLevelAttribute(string RequiredAccessLevel)
        {
            RequiredAccessLevelID = AccessLevels[RequiredAccessLevel];
            this.RequiredAccessLevel = RequiredAccessLevel;
        }

        HttpResponseMessage Generate401()
        {
            return new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = Generate401();
            }
            else
            {
                //actionContext.
                //Get token back in encoded value
                try
                {
                    APISecurityLevelAttribute LevelAttr = actionContext.ActionDescriptor.GetCustomAttributes<APISecurityLevelAttribute>(true).FirstOrDefault();
                    if (LevelAttr == null)
                        LevelAttr = (APISecurityLevelAttribute)actionContext.ActionDescriptor.ControllerDescriptor.ControllerType.GetCustomAttribute(typeof(APISecurityLevelAttribute));
                    string IDToken = null;
                    int ID = 0;
                    string Token = null;
                    try
                    {
                        IDToken = actionContext.Request.Headers.Authorization.Parameter;
                        //string IDToken = Encoding.UTF8.GetString(Convert.FromBase64String(RawToken));
                        ID = Convert.ToInt32(IDToken.Substring(0, 8), 16);
                        Token = IDToken.Substring(8, IDToken.Length - 8);
                    }
                    catch
                    {
                        actionContext.Response = Generate401();
                    }

                    if (Token.Length != 44)
                        actionContext.Response = Generate401();

                    //HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ID.ToString("X8") + Token);
                    //bool Success = false;
                    using (DBContext Context = new DBContext())
                    {
                        CheckTokenProcReturn Result = Context.TokenChecker.CheckToken(new CheckTokenWithAccessLevelProc()
                        {
                            UserID = ID,
                            UserToken = Token,
                            UserRequiredAccessLevelID = LevelAttr.RequiredAccessLevelID
                        });
                        //do the DB check.
                        if (!Result.Valid)
                            actionContext.Response = Generate401();

                        if (actionContext.Request.Properties.ContainsKey(StaticVars.UserID))
                            actionContext.Request.Properties[StaticVars.UserID] = ID;
                        else
                            actionContext.Request.Properties.Add(StaticVars.UserID, ID);

                        if (actionContext.Request.Properties.ContainsKey(StaticVars.IDToken))
                            actionContext.Request.Properties[StaticVars.IDToken] = ID;
                        else
                            actionContext.Request.Properties.Add(StaticVars.IDToken, ID);

                        if (actionContext.Request.Properties.ContainsKey(StaticVars.AccessLevelID))
                            actionContext.Request.Properties[StaticVars.AccessLevelID] = ID;
                        else
                            actionContext.Request.Properties.Add(StaticVars.AccessLevelID, ID);

                        Context.Dispose();
                    }
                    
                }
                catch(Exception e)
                {
                    Trace.WriteLine("APISecurityLevel Exception: " + e);
                    actionContext.Response = Generate401();
                }
            }
            base.OnActionExecuting(actionContext);
        }
    }
}