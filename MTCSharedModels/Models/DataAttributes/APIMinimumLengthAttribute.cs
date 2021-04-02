namespace MTCSharedModels.Models
{
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true)]
    public class APIMinimumLengthAttribute : System.Attribute
    {
        public int Minimum { get; set; }
        public string ErrorMessage { get; set; }

        public APIMinimumLengthAttribute(int Minimum, string ParamName)
        {
            this.ErrorMessage = $"{ParamName}:Your requests {ParamName} param is too short. It must be at least {Minimum} long.;";
            this.Minimum = Minimum;
        }
    }
}
