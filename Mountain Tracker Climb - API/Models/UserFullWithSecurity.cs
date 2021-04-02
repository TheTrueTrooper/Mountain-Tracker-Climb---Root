using MTCSharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mountain_Tracker_Climb___API.Models
{
    /// <summary>
    /// not included class that is keep at server level to keep safe 
    /// </summary>
    internal class UserFullWithSecurity : UserCreate
    {
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
    }
}