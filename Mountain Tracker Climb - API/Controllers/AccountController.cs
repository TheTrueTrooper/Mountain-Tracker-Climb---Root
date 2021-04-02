using Mountain_Tracker_Climb___API.App_Start;
using Mountain_Tracker_Climb___API.DBModelContexts;
using Mountain_Tracker_Climb___API.Security;
using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mountain_Tracker_Climb___API.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Create()
        {
            if (Session[StaticVars.IDToken] != null)
                return RedirectToAction("Index", "Account");
            ViewBag.Title = "Create Account";
            UserFull User = null;
            return View(User);
        }

        [SecurityLevel()]
        public ActionResult Index()
        {
            ViewBag.Title = "Account";
            return View();
        }

        //[SecurityLevel()]
        //public ActionResult Edit()
        //{
        //    ViewBag.Title = "Edit";
        //    return View();
        //}
    }
}
