using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class UserInfoPrivate
    {
        public string UserName { get; set; }
        [SQLInsertIgnore]
        public bool? KeepPrivate { get; set; }
        [SQLInsertIgnore]
        public string ProfilePicturePath { get; set; }
        [SQLInsertIgnore]
        public string BannerPicturePath { get; set; }
    }
}
