using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models.TableData
{
    class UserFullInfo : UserInfo
    {
        public string PrimaryPhone { get; set; }
        public bool? EmailValidated { get; set; }
        public string PrimaryPersonalEmail { get; set; }
        public bool? PhoneValidated { get; set; }
    }
}
