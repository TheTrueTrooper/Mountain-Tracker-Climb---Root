namespace MTCSharedModels.Models
{
    public class UserCreate : UserFull
    {
        [SQLIgnore, APIPostRequired(nameof(Password))]
        [APIIllegalChars(StaticVars.AlphaNumbericCheckWithDashesAndCommas, nameof(Password), StaticVars.AlphaNumbericErrorFixMessageWithDashesAndCommas)]
        [APIMinimumLength(8, nameof(Password))]
        [APIMaximumLength(50, nameof(UserName))]
        public string Password { get; set; }
    }
}
