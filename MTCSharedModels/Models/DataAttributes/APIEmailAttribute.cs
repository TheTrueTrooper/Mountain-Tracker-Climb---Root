namespace MTCSharedModels.Models
{
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true)]
    public class APIEmailAttribute : System.Attribute
    {
        public string ErrorMessage { get; set; } = $"Your requests param has failed its Email check.";

        public APIEmailAttribute()
        {
        }

        public APIEmailAttribute(string ParamName)
        {
            ErrorMessage = $"Your requests {ParamName} param has failed its Email check. If you believe your email is valid please contact the help desk.";
        }
    }
}
