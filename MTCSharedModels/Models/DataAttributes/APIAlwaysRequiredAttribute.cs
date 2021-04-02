namespace MTCSharedModels.Models
{
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true)]
    public class APIAlwaysRequiredAttribute : System.Attribute
    {
        public string ErrorMessage { get; set; } = "Your request is missing or without a param.";

        public APIAlwaysRequiredAttribute(){}

        public APIAlwaysRequiredAttribute(string ParamName)
        {
            this.ErrorMessage = $"{ParamName}:Your request is missing or without the {ParamName} param.;";
        }
    }
}
