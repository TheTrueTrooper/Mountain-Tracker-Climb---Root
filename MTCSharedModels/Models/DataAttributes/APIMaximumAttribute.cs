using System;

namespace MTCSharedModels.Models
{
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true)]
    public class APIMaximumAttribute : System.Attribute
    {
        public double Maximum { get; set; }
        public string ErrorMessage { get; set; } = "Your request has a param that is too long. Please check with the documents.";

        public APIMaximumAttribute(int Maximum) : this(Convert.ToDouble(Maximum))
        { }

        public APIMaximumAttribute(int Maximum, string ParamName) : this(Convert.ToDouble(Maximum), ParamName)
        { }

        public APIMaximumAttribute(double Maximum)
        {
            this.Maximum = Maximum;
        }

        public APIMaximumAttribute(double Maximum, string ParamName) : this(Maximum)
        {
            this.ErrorMessage = $"Your requests {ParamName} param is too long. It must be at less than or equal to {Maximum} long.";
        }
    }
}
