using System;

namespace MTCSharedModels.Models
{
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true)]
    public class APIMinimumAttribute : System.Attribute
    {
        public double Minimum { get; set; }
        public string ErrorMessage { get; set; }

        public APIMinimumAttribute(int Minimum, string ParamName):this(Convert.ToDouble(Minimum), ParamName)
        {
        }
        
        public APIMinimumAttribute(double Minimum, string ParamName)
        {
            this.ErrorMessage = $"{ParamName}:Your requests {ParamName} param is too short. It must be at least {Minimum} long.;";
            this.Minimum = Minimum;
        }
    }
}
