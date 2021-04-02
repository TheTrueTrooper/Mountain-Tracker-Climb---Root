using System.Collections.Generic;

namespace MTCSharedModels.Models
{
    public class Country
    {
        public byte ID { get; set; }
        public string EnglishFullName { get; set; }
        public string CountryCode{ get; set; }
        [SQLIgnore]
        public List<ProvinceOrState> ProvincesOrStates { get; set; } = null;
    }
}
