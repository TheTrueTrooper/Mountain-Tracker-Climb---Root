using System.Collections.Generic;

namespace MTCSharedModels.Models
{
    public class District
    {
        //public Region OwningRegion { get; set; } = null;
        [APIPostRequired(nameof(RegionID))]
        public int? RegionID { get; set; }
        [SQLIdentityID]
        public int? ID { get; set; }
        [APIPostRequired(nameof(EnglishFullName))]
        [APIMinimumLength(1, nameof(EnglishFullName))]
        [APIMaximumLength(100, nameof(EnglishFullName))]
        public string EnglishFullName { get; set; }
        [APIPostRequired(nameof(DistrictCode))]
        [APIMinimumLength(1, nameof(DistrictCode))]
        [APIMaximumLength(5, nameof(DistrictCode))]
        [APIIllegalChars(StaticVars.AlphaCheck, nameof(DistrictCode), StaticVars.AlphaErrorFixMessage)]
        public string DistrictCode { get; set; }
        [SQLIgnore]
        public List<DistrictZone> Zones { get; set; } = null;
    }
}
