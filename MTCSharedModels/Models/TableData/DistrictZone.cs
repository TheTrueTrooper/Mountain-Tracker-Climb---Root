using System;
using System.Collections.Generic;
using System.Text;

namespace MTCSharedModels.Models
{
    public class DistrictZone
    {
        //public District OwningDistrict { get; set; } = null;
        [APIPostRequired(nameof(DistrictID))]
        public int? DistrictID { get; set; }
        [SQLIdentityID]
        public int? ID { get; set; }
        [APIPostRequired(nameof(EnglishFullName)), APIMinimumLength(1, nameof(EnglishFullName)), APIMaximumLength(100, nameof(EnglishFullName)), APIIllegalChars(StaticVars.AlphaNumbericErrorFixMessageWithDashes, nameof(EnglishFullName), StaticVars.AlphaNumbericErrorFixMessageWithDashes)]
        public string EnglishFullName { get; set; }
        [APIPostRequired(nameof(ZoneCode)), APIMinimumLength(1, nameof(ZoneCode)), APIMaximumLength(5, nameof(ZoneCode)), APIIllegalChars(StaticVars.AlphaNumbericErrorFixMessageWithDashes, nameof(EnglishFullName), StaticVars.AlphaNumbericErrorFixMessageWithDashes)]
        public string ZoneCode { get; set; }
        [SQLIgnore]
        public List<ZoneArea> Areas { get; set; } = null;
    }
}
