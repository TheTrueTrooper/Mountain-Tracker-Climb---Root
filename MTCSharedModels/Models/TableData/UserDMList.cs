using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class UserDMList
    {
        public UserInfoPrivate User { get; set; }
        public List<UserDM> AllMessages { get; set; } = new List<UserDM>();
    }
}
