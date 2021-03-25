using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Mountain_Tracker_Climb___API.DBModelContexts;
using MTCSharedModels.Models;

namespace Mountain_Tracker_Climb___API.Security
{
    public class APISecurityOwnerAttribute : ActionFilterAttribute
    {
        public string OwnerColumnSelect { get; set; }
        public bool ComplexSelect { get; set; } = false;

        public APISecurityOwnerAttribute(string OwnerColumnSelect)
        {
            this.OwnerColumnSelect = OwnerColumnSelect;
        }

        public APISecurityOwnerAttribute(string OwnerColumnSelect, bool ComplexSelect) : this(OwnerColumnSelect)
        {
            this.ComplexSelect = ComplexSelect;
        }

        HttpResponseMessage Generate401()
        {
            return new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //base.OnActionExecuting(actionContext);
        }
    }
}