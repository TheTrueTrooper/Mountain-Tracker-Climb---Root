using Mountain_Tracker_Climb___API.App_Start;
using Mountain_Tracker_Climb___API.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mountain_Tracker_Climb___API.Controllers
{
    [SecurityLevel("Admin")]
    public class RouteQuickEditorController : Controller
    {
        // GET: BasicRouteEditor
        public ActionResult Index()
        {
            ViewBag.Title = "Basic Route Editor";
            return View();
        }
    }
}