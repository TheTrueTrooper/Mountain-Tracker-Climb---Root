namespace MTCSharedModels.Models
{
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true)]
    public class APIRegexCheckAttribute : System.Attribute
    {
        public string Regex { get; set; }
        public string ErrorMessage { get; set; }

        public APIRegexCheckAttribute(string Regex, string CheckIsFor, string ParamName)
        {
            this.Regex = Regex;
            ErrorMessage = $"{ParamName}:Your requests {ParamName} param has failed its check for {CheckIsFor} check.;";
        }

        public APIRegexCheckAttribute(string Regex, string CheckIsFor, string ParamName, string AdditionalComments)
        {
            this.Regex = Regex;
            ErrorMessage = $"{ParamName}:Your requests {ParamName} param has failed its check for {CheckIsFor} check. {AdditionalComments};";
        }
    }
}
