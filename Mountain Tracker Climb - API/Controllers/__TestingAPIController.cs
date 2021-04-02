using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MTCSharedModels.Models;
using Mountain_Tracker_Climb___API.DBModelContexts;
using Mountain_Tracker_Climb___API.Helpers;

namespace Mountain_Tracker_Climb___API.Controllers
{
    public class TestingController : ApiController
    {
        [HttpGet]
        public UserCreate GetTest()
        {
            return new UserCreate();
        }
    }
}