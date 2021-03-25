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
        [APIPostRequired(nameof(EnglishFullName)), APIMinimumLength(1, nameof(EnglishFullName)), APIMaximumLength(100, nameof(EnglishFullName)), APIIllegalChars(StaticVars.AlphaNumbericErrorFixMessageWithDashes, nameof(EnglishFullName), StaticVars.AlphaNumbericErrorFixMessageWithDashes)]
        public string EnglishFullName { get; set; }
        [APIPostRequired(nameof(RegionCode)), APIMinimumLength(1, nameof(RegionCode)), APIMaximumLength(2, nameof(RegionCode)), APIIllegalChars(StaticVars.AlphaNumbericErrorFixMessageWithDashes, nameof(EnglishFullName), StaticVars.AlphaNumbericErrorFixMessageWithDashes)]
        public string RegionCode { get; set; }
        [SQLIgnore]
        public List<District> Districts { get; set; } = null;
    }
}
