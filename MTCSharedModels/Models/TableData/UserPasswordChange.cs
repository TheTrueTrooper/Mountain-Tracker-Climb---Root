namespace MTCSharedModels.Models
{
    public class UserPasswordChange
    {
        [APIAlwaysRequired(nameof(OldPassword))]
        [APIMinimumLength(8, nameof(OldPassword))]
        [APIMaximumLength(50, nameof(OldPassword))]
        [APIIllegalChars(StaticVars.AlphaNumbericCheckWithDashesAndCommas, nameof(OldPassword), StaticVars.AlphaNumbericErrorFixMessageWithDashesAndCommas)]
        public string OldPassword { get; set; }
        [APIAlwaysRequired(nameof(NewPassword))]
        [APIMinimumLength(8, nameof(NewPassword))]
        [APIMaximumLength(50, nameof(NewPassword))]
        [APIIllegalChars(StaticVars.AlphaNumbericCheckWithDashesAndCommas, nameof(NewPassword), StaticVars.AlphaNumbericErrorFixMessageWithDashesAndCommas)]
        [APIMatchingField(nameof(RepeatedPassword), nameof(NewPassword))]
        public string NewPassword{ get; set; }
        [APIAlwaysRequired(nameof(RepeatedPassword))]
        [APIMinimumLength(8, nameof(RepeatedPassword))]
        [APIMaximumLength(50, nameof(RepeatedPassword))]
        [APIIllegalChars(StaticVars.AlphaNumbericCheckWithDashesAndCommas, nameof(RepeatedPassword), StaticVars.AlphaNumbericErrorFixMessageWithDashesAndCommas)]
        public string RepeatedPassword { get; set; }
    }
}
