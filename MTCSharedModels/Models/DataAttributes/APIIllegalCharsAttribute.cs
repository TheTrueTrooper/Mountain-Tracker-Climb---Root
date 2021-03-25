namespace MTCSharedModels.Models
{
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true)]
    public class APIIllegalCharsAttribute : System.Attribute
    {
        public string ErrorMessage { get; set; } = $"Your requests param has failed its Illegal Chars check.";
        public char[] IllegalChars { get; set; }

        public APIIllegalCharsAttribute(string IllegalChars) : this(IllegalChars.ToCharArray())
        {
        }

        public APIIllegalCharsAttribute(string IllegalChars, string ParamName) : this(IllegalChars.ToCharArray(), ParamName)
        {
        }

        public APIIllegalCharsAttribute(string IllegalChars, string ParamName, string MessageOnAcceptance) : this(IllegalChars.ToCharArray(), ParamName, MessageOnAcceptance)
        {
        }

        public APIIllegalCharsAttribute(char[] IllegalChars)
        {
            this.IllegalChars = IllegalChars;
        }

        public APIIllegalCharsAttribute(char[] IllegalChars, string ParamName) : this(IllegalChars, ParamName, "If you believe your email is valid please contact the help desk.")
        {
        }

        public APIIllegalCharsAttribute(char[] IllegalChars, string ParamName, string MessageOnAcceptance)
        {
            this.IllegalChars = IllegalChars;
            ErrorMessage = $"Your requests {ParamName} param has failed its check. {MessageOnAcceptance}";
        }
    }
}
