using Mountain_Tracker_Climb___API.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mountain_Tracker_Climb___API.Controllers
{
    [SecurityLevel()]
    public class MessagesController : Controller
    {
        // GET: Messages
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DirectMessage(int id)
        {
            ViewBag.OtherUserID = id;
            return View();
        }

        public ActionResult GroupMessage(int id)
        {
            ViewBag.GroupID = id;
            return View();
        }
    }
}