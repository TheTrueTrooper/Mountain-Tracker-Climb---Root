namespace MTCSharedModels.Models
{
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true)]
    public class APIMaximumLengthAttribute : System.Attribute
    {
        public int Maximum { get; set; }
        public string ErrorMessage { get; set; }

        public APIMaximumLengthAttribute(int Maximum, string ParamName)
        {
            this.ErrorMessage = $"{ParamName}:Your requests {ParamName} param is too long. It must be less than or equal to {Maximum} long.;";
            this.Maximum = Maximum;
        }
    }
}
