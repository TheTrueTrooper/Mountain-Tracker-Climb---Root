namespace MTCSharedModels.Models
{
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true)]
    public class APIAlwaysRequiredAttribute : System.Attribute
    {
        public string ErrorMessage { get; set; } = "Your request is missing or with out a param.";

        public APIAlwaysRequiredAttribute(){}

        public APIAlwaysRequiredAttribute(string ParamName)
        {
            this.ErrorMessage = $"Your request is missing or with out the {ParamName} param."; ;
        }
    }
}
