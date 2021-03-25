namespace MTCSharedModels.Models
{
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true)]
    public class APIMaximumLengthAttribute : System.Attribute
    {
        public int Maximum { get; set; }
        public string ErrorMessage { get; set; } = "Your request has a param that is too long. Please check with the documents.";

        public APIMaximumLengthAttribute(int Maximum)
        {
            this.Maximum = Maximum;
        }

        public APIMaximumLengthAttribute(int Maximum, string ParamName) : this(Maximum)
        {
            this.ErrorMessage = $"Your requests {ParamName} param is too long. It must be less than or equal to {Maximum} long."; ;
        }
    }
}
