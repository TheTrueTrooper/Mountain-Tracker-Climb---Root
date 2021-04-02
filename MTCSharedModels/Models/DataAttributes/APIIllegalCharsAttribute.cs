namespace MTCSharedModels.Models
{
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true)]
    public class APIIllegalCharsAttribute : System.Attribute
    {
        public string ErrorMessage { get; set; }
        public char[] IllegalChars { get; set; }

        public APIIllegalCharsAttribute(string IllegalChars, string ParamName, string MessageOnAcceptance) : this(IllegalChars.ToCharArray(), ParamName, MessageOnAcceptance)
        {
        }

        public APIIllegalCharsAttribute(char[] IllegalChars, string ParamName, string MessageOnAcceptance)
        {
            this.IllegalChars = IllegalChars;
            ErrorMessage = $"{ParamName}:Your requests {ParamName} param has failed its check. {MessageOnAcceptance};";
        }
    }
}
