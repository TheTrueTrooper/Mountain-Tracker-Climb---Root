namespace MTCSharedModels.Models
{
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true)]
    public class APIPostRequiredAttribute : System.Attribute
    {
        public string ErrorMessage { get; set; }

        public APIPostRequiredAttribute(string ParamName)
        {
            this.ErrorMessage = $"{ParamName}:Your request is missing or without the {ParamName} param.;"; ;
        }
    }
}
