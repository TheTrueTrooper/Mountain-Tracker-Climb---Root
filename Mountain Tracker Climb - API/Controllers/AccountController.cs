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
        [HttpGet]
        [Route("Account/Create")]
        public ActionResult Create()
        {
            if (Session[StaticVars.IDToken] != null)
                return RedirectToAction("Index", "Account");
            ViewBag.Title = "Create Account";
            UserFull User = null;
            return View(User);
        }

        [HttpGet]
        [SecurityLevel()]
        public ActionResult Index()
        {
            ViewBag.Title = "Account";
            return View();
        }

        [HttpGet]
        [SecurityLevel()]
        [Route("Account/{ID}")]
        public ActionResult ProfileView(int ID)
        {
            ViewBag.Title = "Profile View";
            ViewBag.UserID = ID;
            return View();
        }

        [HttpGet]
        [SecurityLevel()]
        [Route("Account/Partners")]
        public ActionResult Partners()
        {
            ViewBag.Title = "Profile View";
            return View();
        }

        [HttpGet]
        [SecurityLevel()]
        [Route("Account/ProfileSearch")]
        public ActionResult ProfileSearch(string Search)
        {
            ViewBag.Title = "Profile Search";
            ViewBag.SearchName = Search;
            return View();
        }

        [HttpGet]
        [Route("Account/AccountNotFound")]
        public ActionResult AccountNotFound()
        {
            ViewBag.Title = "Account Not Found";
            return View();
        }
    }
}
