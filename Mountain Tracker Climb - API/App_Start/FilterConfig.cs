using System.Web;
using System.Web.Mvc;

namespace Mountain_Tracker_Climb___API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
