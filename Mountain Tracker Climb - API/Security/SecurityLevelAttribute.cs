using Mountain_Tracker_Climb___API.App_Start;
using Mountain_Tracker_Climb___API.DBModelContexts;
using Mountain_Tracker_Climb___API.Models;
using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Mountain_Tracker_Climb___API.Security
{
    public class SecurityLevelAttribute : ActionFilterAttribute
    {
        private static string LowestLevel;

        public static Dictionary<string, int> AccessLevels { get; private set; }
        public static Dictionary<int, string> AccessLevelNames { get; private set; }

        public int RequiredAccessLevelID { get; set; }
        public string RequiredAccessLevel { get; set; }

        static SecurityLevelAttribute()
        {
            AccessLevels = new Dictionary<string, int>();
            AccessLevelNames = new Dictionary<int, string>();
            using (UserAccessLevelDBContext AccessTable = new UserAccessLevelDBContext())
                foreach (UserAccessLevel UAL in AccessTable.GetUserAccessLevels())
                {
                    AccessLevels.Add(UAL.EnglishName, UAL.ID);
                    AccessLevelNames.Add(UAL.ID, UAL.EnglishName);
                }
            //dynamic set
            LowestLevel = AccessLevelNames[AccessLevels.Max(M => { return M.Value; })];
        }

        public SecurityLevelAttribute() : this(LowestLevel)
        {
        }

        public SecurityLevelAttribute(string RequiredAccessLevel)
        {
            RequiredAccessLevelID = AccessLevels[RequiredAccessLevel];
            this.RequiredAccessLevel = RequiredAccessLevel;
        }

        ActionResult MoveToLogin(string ErrorMessage)
        {
            ViewResult Return = new ViewResult()
            {
                ViewName = "~/Views/Login/Index.cshtml"
            };
            Return.ViewBag.Title = "Login";
            Return.ViewBag.Errors = new string[]{ ErrorMessage };
            return Return;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string IDToken = (string)filterContext.HttpContext.Session[StaticVars.IDToken];
            if (IDToken == null)
            {
                filterContext.Result = MoveToLogin("You have yet to login. Please login.");
            }
            else
            {
                //actionContext.
                //Get token back in encoded value
                try
                {
                    SecurityLevelAttribute LevelAttr = (SecurityLevelAttribute)filterContext.ActionDescriptor.GetCustomAttributes(typeof(SecurityLevelAttribute), true).FirstOrDefault();
                    if (LevelAttr == null)
                        LevelAttr = (SecurityLevelAttribute)filterContext.ActionDescriptor.ControllerDescriptor.ControllerType.GetCustomAttribute(typeof(SecurityLevelAttribute));
                    //IDToken = (string)filterContext.HttpContext.Session[StaticVars.Token];
                    //string IDToken = Encoding.UTF8.GetString(Convert.FromBase64String(RawToken));
                    int ID = 0;
                    string Token = null;
                    try
                    {
                        ID = Convert.ToInt32(IDToken.Substring(0, 8), 16);
                        Token = IDToken.Substring(8, IDToken.Length - 8);
                    }
                    catch
                    { 
                        filterContext.Result = MoveToLogin("Invalid token given. Please re-login."); 
                    }

                    if (Token.Length != 44)
                        filterContext.Result = MoveToLogin("Invalid token given. Please re-login.");

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
                        {
                            filterContext.HttpContext.Session.Clear();
                            filterContext.HttpContext.Session.Abandon();
                            filterContext.Result = MoveToLogin("Token is no longer valid, invalid, or lacks sufficient access. Please re-login to an account with access.");
                        }
                        //Pass any useful parses
                        filterContext.HttpContext.Session[StaticVars.UserID] = ID;
                        filterContext.HttpContext.Session[StaticVars.Token] = Token;
                        filterContext.HttpContext.Session[StaticVars.AccessLevelID] = Result.AccessLevelID;
                        Context.Dispose();
                    }
                }
                catch(Exception e)
                {
                    Trace.WriteLine("SecurityLevel Exception: " + e);
                    filterContext.Result = MoveToLogin("Invalid token given. Please re-login.");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}