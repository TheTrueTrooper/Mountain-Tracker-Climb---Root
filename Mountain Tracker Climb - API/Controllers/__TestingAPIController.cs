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
        public string GetSalt()
        {
            string SaltValue = SecurityHelper.GetCode(); // "9r6ylzybFpClyRzSq8J1f9onNJV6MpviRuaNu/pgn+M="; //SecurityHelper.GetCode();
            string Password = "Mycookkies";
            string Value = SecurityHelper.PasswordToSaltedHash(Password, SaltValue);
            return Value;
        }
    }
}