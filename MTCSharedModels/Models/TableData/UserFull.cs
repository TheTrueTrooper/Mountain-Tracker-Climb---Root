using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class UserFull : UserInfoPublic
    {
        [APIPostRequired(nameof(PrimaryPersonalEmail)), APIEmail(nameof(PrimaryPersonalEmail))]
        public string PrimaryPersonalEmail { get; set; }
        [SQLInsertIgnore]
        public bool? EmailValidated { get; set; }
        [APIPostRequired(nameof(PrimaryPhone)), APIPhoneNumber(nameof(PrimaryPhone))]
        public string PrimaryPhone { get; set; }
        [SQLInsertIgnore]
        public bool? PhoneValidated { get; set; }
        [SQLInsertIgnore]
        public byte? AccessLevelID { get; set; }
        [SQLIgnore]
        public UserAccessLevel UserAccessLevel { get; set; }
        [SQLIgnore, APIPostRequired(nameof(Password)), APIIllegalChars(StaticVars.AlphaNumbericCheckWithDashesAndCommas, nameof(Password), StaticVars.AlphaNumbericErrorFixMessageWithDashesAndCommas), APIMinimumLength(8, nameof(Password)), APIMaximumLength(50, nameof(UserName))]
        public string Password { get; set; }
    }
}
