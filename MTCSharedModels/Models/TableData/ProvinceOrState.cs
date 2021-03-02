using System.Collections.Generic;

namespace MTCSharedModels.Models
{
    public class ProvinceOrState
    {
        //public Country OwningCountry { get; set; } = null;
        public byte CountryID { get; set; }
        public short? ID { get; set; }
        public string EnglishFullName { get; set; }
        public string RegionCode { get; set; }
        [SQLIgnore]
        public List<Region> Regions { get; set; } = null;
    }
}
