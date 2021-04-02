namespace MTCSharedModels.Models
{
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true)]
    public class APIPhoneNumberAttribute : System.Attribute
    {
        public string ErrorMessage { get; set; }

        public APIPhoneNumberAttribute(string ParamName)
        {
            ErrorMessage = $"{ParamName}:Your requests {ParamName} param has failed its Phone Number check. If you believe your email is valid please contact the help desk.;";
        }
    }
}
