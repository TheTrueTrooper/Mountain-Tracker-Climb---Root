using System;

namespace MTCSharedModels.Models
{
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true)]
    public class APIMaximumAttribute : System.Attribute
    {
        public double Maximum { get; set; }
        public string ErrorMessage { get; set; }

        public APIMaximumAttribute(int Maximum, string ParamName) : this(Convert.ToDouble(Maximum), ParamName)
        { }

        public APIMaximumAttribute(double Maximum, string ParamName)
        {
            this.ErrorMessage = $"{ParamName}:Your requests {ParamName} param is too long. It must be at less than or equal to {Maximum} long.;";
            this.Maximum = Maximum;
        }
    }
}
