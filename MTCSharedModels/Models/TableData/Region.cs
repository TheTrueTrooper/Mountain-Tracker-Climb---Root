using System.Collections.Generic;

namespace MTCSharedModels.Models
{
    public class Region
    {
        //public ProvinceOrState OwningProvinceOrState { get; set; }
        [APIPostRequired(nameof(ProvinceOrStateID))]
        public short? ProvinceOrStateID { get; set; }
        [SQLIdentityID]
        public int? ID { get; set; }
        [APIPostRequired(nameof(EnglishFullName))]
        [APIMinimumLength(1, nameof(EnglishFullName))]
        [APIMaximumLength(100, nameof(EnglishFullName))]
        public string EnglishFullName { get; set; }
        [APIPostRequired(nameof(RegionCode))]
        [APIMinimumLength(1, nameof(RegionCode))]
        [APIMaximumLength(5, nameof(RegionCode))]
        [APIIllegalChars(StaticVars.AlphaCheck, nameof(RegionCode), StaticVars.AlphaErrorFixMessage)]
        public string RegionCode { get; set; }
        [SQLIgnore]
        public List<District> Districts { get; set; } = null;
    }
}
