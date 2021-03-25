namespace MTCSharedModels.Models
{
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true)]
    public class APIPostRequiredAttribute : System.Attribute
    {
        public string ErrorMessage { get; set; } = "Your request is missing or with out a param.";

        public APIPostRequiredAttribute(){}

        public APIPostRequiredAttribute(string ParamName)
        {
            this.ErrorMessage = $"Your request is missing or with out the {ParamName} param."; ;
        }
    }
}
