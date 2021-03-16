using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class UserInfoPublic : UserInfoPrivate
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        [SQLInsertIgnore]
        public string Bio { get; set; }
        [SQLInsertIgnore]
        public string ProfileURL { get; set; }
    }
}
