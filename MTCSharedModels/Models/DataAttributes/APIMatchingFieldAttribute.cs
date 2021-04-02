namespace MTCSharedModels.Models
{
    [System.AttributeUsage(System.AttributeTargets.Property, Inherited = true)]
    public class APIMatchingFieldAttribute : System.Attribute
    {
        public string ErrorMessage { get; set; }
        public string FieldName { get; set; }

        public APIMatchingFieldAttribute(string FieldName, string ParamName)
        {
            this.FieldName = FieldName;
            this.ErrorMessage = $"{ParamName}:Your request's {ParamName} param dosen't match the {FieldName} param as required.;";
        }
    }
}
