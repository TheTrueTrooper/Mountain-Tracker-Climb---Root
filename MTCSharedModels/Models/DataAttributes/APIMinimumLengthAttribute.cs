namespace MTCSharedModels.Models
{
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true)]
    public class APIMinimumLengthAttribute : System.Attribute
    {
        public int Minimum { get; set; }
        public string ErrorMessage { get; set; } = "Your request has a param that is too short. Please check with the documents.";

        public APIMinimumLengthAttribute(int Minimum)
        {
            this.Minimum = Minimum;
        }

        public APIMinimumLengthAttribute(int Minimum, string ParamName) : this(Minimum)
        {
            this.ErrorMessage = $"Your requests {ParamName} param is too short. It must be at least {Minimum} long."; ;
        }
    }
}
