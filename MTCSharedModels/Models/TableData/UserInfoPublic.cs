namespace MTCSharedModels.Models
{
    public class UserInfoPublic : UserInfoPrivate
    {
        [APIPostRequired(nameof(FirstName))]
        [APIMinimumLength(1, nameof(FirstName))]
        [APIMaximumLength(50, nameof(FirstName))]
        [APIIllegalChars(StaticVars.AlphaCheck, nameof(FirstName), StaticVars.AlphaErrorFixMessage)]
        public string FirstName { get; set; }
        [APIPostRequired(nameof(MiddleName))]
        [APIMinimumLength(1, nameof(MiddleName))]
        [APIMaximumLength(50, nameof(MiddleName))]
        [APIIllegalChars(StaticVars.AlphaCheck, nameof(MiddleName), StaticVars.AlphaErrorFixMessage)]
        public string MiddleName { get; set; }
        [APIPostRequired(nameof(LastName))]
        [APIMinimumLength(1, nameof(LastName))]
        [APIMaximumLength(50, nameof(LastName))]
        [APIIllegalChars(StaticVars.AlphaCheck, nameof(LastName), StaticVars.AlphaErrorFixMessage)]
        public string LastName { get; set; }
        [SQLInsertIgnore]
        [APIMaximumLength(2500, nameof(Bio))]
        public string Bio { get; set; }
        [SQLInsertIgnore]
        public string ProfileURL { get; set; }
    }
}
