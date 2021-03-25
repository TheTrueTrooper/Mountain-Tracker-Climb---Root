using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class UserInfoPrivate
    {
        [SQLIdentityID]
        public int? ID { get; set; }
        [APIPostRequired(nameof(UserName)), APIMinimumLength(2, nameof(UserName)), APIMaximumLength(50, nameof(UserName)), APIRegexCheck(StaticVars.AlphaStartRegexCheck, StaticVars.AlphaStartRegexCheckName, nameof(UserName), StaticVars.AlphaStartRegexErrorMessageExtend), APIIllegalChars(StaticVars.AlphaNumbericCheckWithDashes, nameof(UserName), StaticVars.AlphaNumbericErrorFixMessageWithDashes)]
        public string UserName { get; set; }
        [SQLInsertIgnore]
        public bool? KeepPrivate { get; set; }
        [SQLInsertIgnore]
        public string ProfilePicturePath { get; set; }
        [SQLInsertIgnore]
        public string BannerPicturePath { get; set; }
    }
}
