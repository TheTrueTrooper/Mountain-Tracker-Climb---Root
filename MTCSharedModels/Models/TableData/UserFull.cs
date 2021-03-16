using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class UserFull : UserInfoPublic
    {
        [SQLIdentityID]
        public int? ID { get; set; }
        public string PrimaryPersonalEmail { get; set; }
        [SQLInsertIgnore]
        public bool? EmailValidated { get; set; }
        public string PrimaryPhone { get; set; }
        [SQLInsertIgnore]
        public bool? PhoneValidated { get; set; }
        [SQLInsertIgnore]
        public byte? AccessLevelID { get; set; }
        [SQLIgnore]
        public UserAccessLevel UserAccessLevel { get; set; }
        [SQLIgnore]
        public string Password { get; set; }
    }
}
