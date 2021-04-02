using Mountain_Tracker_Climb___API.App_Start;
using Mountain_Tracker_Climb___API.DBModelContexts;
using Mountain_Tracker_Climb___API.Helpers;
using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mountain_Tracker_Climb___API.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (Session[StaticVars.IDToken] != null)
                return RedirectToAction("Index", "Account");

            ViewBag.Title = "Login";
            ViewBag.Errors = new string[0];
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserLogin Values)
        {
            if(Session[StaticVars.IDToken] != null)
                return RedirectToAction("Index", "Account");

            ControllerHelper.ClearObjectsEmptyStrings(Values);
            //if (Errors != null)
            //    ViewBag.Errors = Errors;
            List<string> Errors = ControllerHelper.CheckObjectForPostErrors(Values) ?? new List<string>();
            ViewBag.Title = "Login";

            if (Errors.Count() == 0)
            {

                UserLoginReturn Result = null;
                try
                {
                    using (DBContext DB = new DBContext())
                        Result = DB.UserTable.LoginWeb(Values);
                }
                catch
                {
                    const string ErrorString = "Login has failed due to a internal issue. Please try again later or contact the help desk.";
                    Errors.Add(ErrorString);
                }
                if (Result == null)
                {
                    const string ErrorString = "Login has failed. Either your password or user name being incorect. Please check both and then try again.";
                    Errors.Add(ErrorString);
                }
                if (Errors.Count() == 0)
                {
                    Session[StaticVars.IDToken] = Result.UserID.Value.ToString("X8") + Result.BearersToken;
                    return RedirectToAction("Index", "Account");
                }

            }
            ViewBag.Errors = Errors.ToArray();
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}
