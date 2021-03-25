using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class UserPasswordChange
    {
        [APIAlwaysRequired]
        public int? ID { get; set; }
        [APIAlwaysRequired, APIMinimumLength(8, nameof(OldPassword)), APIMatchingField(nameof(NewPasswordPassword), nameof(OldPassword)), APIMaximumLength(50, nameof(OldPassword)), APIIllegalChars(StaticVars.AlphaCheck, nameof(OldPassword), StaticVars.AlphaErrorFixMessage)]
        public string OldPassword { get; set; }
        [APIAlwaysRequired, APIMinimumLength(8, nameof(NewPasswordPassword)), APIMaximumLength(50, nameof(NewPasswordPassword)), APIIllegalChars(StaticVars.AlphaCheck, nameof(NewPasswordPassword), StaticVars.AlphaErrorFixMessage)]
        public string NewPasswordPassword { get; set; }
    }
}
