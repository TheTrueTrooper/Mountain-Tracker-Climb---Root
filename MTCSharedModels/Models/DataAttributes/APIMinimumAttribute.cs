using System;

namespace MTCSharedModels.Models
{
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true)]
    public class APIMinimumAttribute : System.Attribute
    {
        public double Minimum { get; set; }
        public string ErrorMessage { get; set; } = "Your request has a param that is too short. Please check with the documents.";

        public APIMinimumAttribute(int Minimum) : this(Convert.ToDouble(Minimum)){}

        public APIMinimumAttribute(int Minimum, string ParamName) : this(Convert.ToDouble(Minimum), ParamName){}

        public APIMinimumAttribute(double Minimum)
        {
            this.Minimum = Minimum;
        }

        public APIMinimumAttribute(double Minimum, string ParamName) : this(Minimum)
        {
            this.ErrorMessage = $"Your requests {ParamName} param is too short. It must be at least {Minimum} long.";
        }
    }
}
